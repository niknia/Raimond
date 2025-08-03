import axios from 'axios';
import type {
  AxiosRequestConfig,
  InternalAxiosRequestConfig,
  AxiosInstance,
  AxiosResponse,
  AxiosError,
} from 'axios';
import { stringify } from 'qs';
import isFunction from 'lodash/isFunction';
import cloneDeep from 'lodash/cloneDeep';
import type { CreateAxiosOptions } from './AxiosTransform';
import { AxiosCanceler } from './AxiosCancel';
import { ContentTypeEnum } from '../types';
import type { VAxiosRequestConfig } from '../types';

export interface RequestOptions {
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

export interface Result<T = unknown> {
  code: number;
  type?: 'success' | 'error' | 'warning';
  message: string;
  data?: T;
}

export interface AxiosRequestConfigRetry extends AxiosRequestConfig {
  retryCount?: number;
  retry?: boolean;
  requestOptions?: RequestOptions;
}

// Axios module
export class VAxios {
  // axios handle
  private instance: AxiosInstance;

  // axios options
  private readonly options: CreateAxiosOptions;

  constructor(options: CreateAxiosOptions) {
    this.options = options;
    this.instance = axios.create(options);
    this.setupInterceptors();
  }

  // Create axios handle
  private createAxios(config: CreateAxiosOptions): void {
    this.instance = axios.create(config);
  }

  // Get data processing
  private getTransform() {
    const { transform } = this.options;
    return transform;
  }

  // Get handle
  getAxios(): AxiosInstance {
    return this.instance;
  }

  // Configuration axios
  configAxios(config: CreateAxiosOptions) {
    if (!this.instance) {
      return;
    }
    this.createAxios(config);
  }

  // Set common header information
  setHeader(headers: Record<string, string>): void {
    if (!this.instance) {
      return;
    }
    Object.assign(this.instance.defaults.headers, headers);
  }

  // Set interceptor
  private setupInterceptors() {
    const transform = this.getTransform();
    if (!transform) {
      return;
    }
    const {
      requestInterceptors,
      requestInterceptorsCatch,
      responseInterceptors,
      responseInterceptorsCatch,
    } = transform;
    const axiosCanceler = new AxiosCanceler();

    // Request configuration processing
    this.instance.interceptors.request.use(
      async (config: InternalAxiosRequestConfig) => {
        // @ts-ignore
        const { ignoreRepeatRequest } = config.requestOptions;
        const ignoreRepeat =
          ignoreRepeatRequest ??
          this.options.requestOptions?.ignoreRepeatRequest;
        if (!ignoreRepeat) {
          axiosCanceler.addPending(config, () => {
            // Cancel function will be called when needed
          });
        }

        if (requestInterceptors && isFunction(requestInterceptors)) {
          const processedConfig = await requestInterceptors(config, this.options);
          return processedConfig;
        }

        return config;
      },
      undefined
    );

    // Request error handling
    if (requestInterceptorsCatch && isFunction(requestInterceptorsCatch)) {
      this.instance.interceptors.request.use(
        undefined,
        requestInterceptorsCatch
      );
    }

    // Response result processing
    this.instance.interceptors.response.use(async (res: AxiosResponse) => {
      if (res) axiosCanceler.removePending(res.config);
      if (responseInterceptors && isFunction(responseInterceptors)) {
        const processedResponse = await responseInterceptors(res);
        return processedResponse;
      }
      return res;
    }, undefined);

    // Response error handling
    if (responseInterceptorsCatch && isFunction(responseInterceptorsCatch)) {
      this.instance.interceptors.response.use(
        undefined,
        responseInterceptorsCatch
      );
    }
    

  }

  // Support Form Data
  supportFormData(config: AxiosRequestConfig) {
    const headers = config.headers || this.options.headers;
    const contentType = headers?.['Content-Type'] || headers?.['content-type'];

    if (
      contentType !== ContentTypeEnum.FORM_URLENCODED ||
      !Reflect.has(config, 'data') ||
      config.method?.toUpperCase() === 'GET'
    ) {
      return config;
    }

    return {
      ...config,
      data: stringify(config.data, { arrayFormat: 'brackets' }),
    };
  }

  get<T = unknown>(
    requestConfig: VAxiosRequestConfig,
    options?: RequestOptions
  ): Promise<T> {
    requestConfig.url =
      requestConfig.url || (typeof requestConfig.uri === 'string' ? requestConfig.uri : requestConfig.uri?.toUriFormat().value);
    return this.request({ ...requestConfig, method: 'GET' }, options);
  }

  post<T = unknown>(
    requestConfig: VAxiosRequestConfig,
    options?: RequestOptions
  ): Promise<T> {
    requestConfig.url =
      requestConfig.url || (typeof requestConfig.uri === 'string' ? requestConfig.uri : requestConfig.uri?.toUriFormat().value);
    return this.request({ ...requestConfig, method: 'POST' }, options);
  }

  put<T = unknown>(
    requestConfig: VAxiosRequestConfig,
    options?: RequestOptions
  ): Promise<T> {
    requestConfig.url =
      requestConfig.url || (typeof requestConfig.uri === 'string' ? requestConfig.uri : requestConfig.uri?.toUriFormat().value);
    return this.request({ ...requestConfig, method: 'PUT' }, options);
  }

  delete<T = unknown>(
    requestConfig: VAxiosRequestConfig,
    options?: RequestOptions
  ): Promise<T> {
    requestConfig.url =
      requestConfig.url || (typeof requestConfig.uri === 'string' ? requestConfig.uri : requestConfig.uri?.toUriFormat().value);
    return this.request({ ...requestConfig, method: 'DELETE' }, options);
  }

  patch<T = unknown>(
    requestConfig: VAxiosRequestConfig,
    options?: RequestOptions
  ): Promise<T> {
    requestConfig.url =
      requestConfig.url || (typeof requestConfig.uri === 'string' ? requestConfig.uri : requestConfig.uri?.toUriFormat().value);
    return this.request({ ...requestConfig, method: 'PATCH' }, options);
  }

  // ask
  async request<T = unknown>(
    config: AxiosRequestConfigRetry,
    options?: RequestOptions
  ): Promise<T> {
    let conf: CreateAxiosOptions = cloneDeep(config);
    const transform = this.getTransform();

    const { requestOptions } = this.options;

    const opt: RequestOptions = { ...requestOptions, ...options };

    const { beforeRequestHook, requestCatchHook, transformRequestHook } =
      transform || {};
    if (beforeRequestHook && isFunction(beforeRequestHook)) {
      conf = beforeRequestHook(conf, opt);
    }
    conf.requestOptions = opt;

    conf = this.supportFormData(conf);

    return new Promise((resolve, reject) => {
      this.instance
        .request<unknown, AxiosResponse<Result>>(!config.retryCount ? conf : config)
        .then((res: AxiosResponse<Result>) => {
          if (transformRequestHook && isFunction(transformRequestHook)) {
            try {
              const ret = transformRequestHook(res, opt);
              resolve(ret as T);
            } catch (err) {
              reject(err || new Error('Request error!'));
            }
            return;
          }
          resolve(res as unknown as T);
        })
        .catch((e: Error | AxiosError) => {
          if (requestCatchHook && isFunction(requestCatchHook)) {
            reject(requestCatchHook(e, opt));
            return;
          }
          if (axios.isAxiosError(e)) {
            // Override the Axios error message here
          }
          reject(e);
        });
    });
  }
}
