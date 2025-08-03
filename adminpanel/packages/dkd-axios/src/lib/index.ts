// The axios configuration can be changed according to the project. You only need to change this file, and other files can be left unchanged.
import isString from 'lodash/isString';
import merge from 'lodash/merge';
import type { InternalAxiosRequestConfig, AxiosError } from 'axios';
import { AxiosHeaders } from 'axios';
import type { AxiosTransform, CreateAxiosOptions } from './AxiosTransform';
import { VAxios } from './Axios';
import { joinTimestamp, formatRequestDate, setObjToUrlParams, csrf } from '../uitls';
import { ContentTypeEnum } from '../types';
import { getAccessToken, refreshAccessToken, clearTokens } from './auth';
import type { VAxiosInternalRequestConfig } from '../types';
import { axiosConfig } from './config';

interface CustomError extends Error {
  code?: number | string;
  data?: unknown;
}

interface RequestOptions {
  apiUrl?: string;
  isJoinPrefix?: boolean;
  urlPrefix?: string;
  isReturnNativeResponse?: boolean;
  isTransformResponse?: boolean;
  joinParamsToUrl?: boolean;
  formatDate?: boolean;
  joinTime?: boolean;
  ignoreRepeatRequest?: boolean;
  withToken?: boolean;
  retry?: {
    count: number;
    delay: number;
  };
}

export interface ExtendedAxiosRequestConfig extends InternalAxiosRequestConfig {
  retryCount?: number;
  requestOptions?: RequestOptions;
}

//Data processing makes it easy to distinguish between multiple processing methods
const transform: AxiosTransform = {
  // Process the request data. If the data is not in the expected format, an error can be thrown directly
  transformRequestHook: (res, options) => {
    const { isTransformResponse, isReturnNativeResponse } = options;

    //If 204 has no content, return directly
    const method = res.config.method?.toLowerCase();
    if (
      res.status === 201 ||
      res.status === 204 ||
      method === 'put' ||
      method === 'patch'
    ) {
      return res.data;
    }
    // Whether to return the native response header. For example: use this attribute when you need to obtain the response header.
    if (isReturnNativeResponse) {
      return res.data;
    }
    // Without any processing, return directly
    // Used when page code may need to directly obtain code, data, message and other information.
    if (!isTransformResponse) {
      return res.data;
    }
    //Return on error
    const { data } = res;
    if (!data) {
      throw new Error('Request interface error');
    }

    // The code here is a unified field in the background, which needs to be modified to the project's own interface return format in types.ts.
    const { code, message } = data;

    //The logic here can be modified according to the project
    const hasSuccess = data && code === 0;
    if (hasSuccess) {
      return data.data;
    }

    const error = new Error(message || `Request failed with code: ${code}`) as CustomError;
    error.code = code;
    error.data = data;
    throw error;
  },

  // Pre-request processing configuration
  beforeRequestHook: (config, options) => {
    const {
      apiUrl,
      isJoinPrefix,
      urlPrefix,
      joinParamsToUrl,
      formatDate,
      joinTime = true,
    } = options;

    const { baseUrl, apiPrefix } = axiosConfig.getConfig();

    //Add interface prefix
    if (isJoinPrefix && urlPrefix && isString(urlPrefix)) {
      config.url = `${urlPrefix}${config.url}`;
    }

    // Splice baseUrl
    if (apiUrl && isString(apiUrl)) {
      config.url = `${apiUrl}${config.url}`;
    } else {
      // Use config values if no specific apiUrl provided
      config.url = `${baseUrl}${apiPrefix}${config.url}`;
    }
    const params = config.params || {};
    const data = config.data || false;

    if (formatDate && data && !isString(data)) {
      formatRequestDate(data);
    }
    if (config.method?.toUpperCase() === 'GET') {
      if (!isString(params)) {
        // Add a timestamp parameter to the get request to avoid getting data from the cache.
        config.params = Object.assign(
          params || {},
          joinTimestamp(joinTime, false)
        );
      } else {
        // Compatible with restful style
        config.url = `${config.url + params}${joinTimestamp(joinTime, true)}`;
        config.params = undefined;
      }
    } else if (!isString(params)) {
      if (formatDate) {
        formatRequestDate(params);
      }
      if (
        Reflect.has(config, 'data') &&
        config.data &&
        (Object.keys(config.data).length > 0 || data instanceof FormData)
      ) {
        config.data = data;
        config.params = params;
      } else {
        // For non-GET requests, if no data is provided, params will be treated as data.
        config.data = params;
        config.params = undefined;
      }
      if (joinParamsToUrl) {
        config.url = setObjToUrlParams(config.url as string, {
          ...config.params,
          ...config.data,
        });
      }
    } else {
      // Compatible with restful style
      config.url += params;
      config.params = undefined;
    }
    return config;
  },

  //Request interceptor processing
  requestInterceptors: (config, options) => {
    const { withToken } = axiosConfig.getConfig().requestOptions;
    
    // Add CSRF token to all requests
    const csrfToken = csrf.getToken();
    if (csrfToken) {
      config.headers['X-CSRF-Token'] = csrfToken;
    }

    // Add authorization header if token exists and withToken is true
    if (withToken) {
      const token = getAccessToken();
      if (token) {
        config.headers.Authorization = `Bearer ${token}`;
      }
    }
    return config;
  },

  //Response interceptor processing
  responseInterceptors: (res) => {
    return res;
  },

  //Response error handling
  responseInterceptorsCatch: async (error) => {
    const config = error.config as VAxiosInternalRequestConfig | undefined;
    const { retry } = axiosConfig.getConfig().requestOptions;
    
    // اگر خطای 401 بود و درخواست retry نشده بود
    if (error.response?.status === 401 && config && !config._retry) {
      config._retry = true;
      
      try {
        // تلاش برای refresh token
        const newToken = await refreshAccessToken();
        
        // تکرار درخواست با توکن جدید
        if (config) {
          config.headers.Authorization = `Bearer ${newToken}`;
          return request.request(config);
        }
      } catch (refreshError) {
        // اگر refresh token هم ناموفق بود، کاربر را logout می‌کنیم
        clearTokens();
        window.location.href = '/login';
        return Promise.reject(refreshError);
      }
    }
    
    return Promise.reject(error);
  },
};

function createAxios(opt?: Partial<CreateAxiosOptions>) {
  const config = axiosConfig.getConfig();
  return new VAxios(
    merge(
      <CreateAxiosOptions>{
        authenticationScheme: 'Bearer',
        timeout: config.timeout,
        withCredentials: config.withCredentials,
        headers: config.headers,
        transform,
        requestOptions: {
          apiUrl: config.baseUrl,
          isJoinPrefix: config.requestOptions.isJoinPrefix,
          urlPrefix: config.apiPrefix,
          isReturnNativeResponse: config.requestOptions.isReturnNativeResponse,
          isTransformResponse: config.requestOptions.isTransformResponse,
          joinParamsToUrl: config.requestOptions.joinParamsToUrl,
          formatDate: config.requestOptions.formatDate,
          joinTime: config.requestOptions.joinTime,
          ignoreRepeatRequest: config.requestOptions.ignoreRepeatRequest,
          withToken: config.requestOptions.withToken,
          retry: config.requestOptions.retry,
        },
      },
      opt || {}
    )
  );
}

export const request = createAxios();
