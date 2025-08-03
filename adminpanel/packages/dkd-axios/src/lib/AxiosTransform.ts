import type {
  AxiosRequestConfig,
  InternalAxiosRequestConfig,
  AxiosResponse,
  AxiosError,
} from 'axios';
import type { RequestOptions } from './Axios';
import type { Result } from './Axios';

/**
 * Custom configuration for creating Axios instance
 */
export interface CreateAxiosOptions extends AxiosRequestConfig {
  /**
   * Authentication scheme (e.g., 'Bearer')
   * @see https://developer.mozilla.org/en-US/docs/Web/HTTP/Authentication#authentication_schemes
   */
  authenticationScheme?: string;
  
  /**
   * Data transformation hooks
   */
  transform?: AxiosTransform;
  
  /**
   * Request configuration options
   */
  requestOptions?: RequestOptions;
}

/**
 * Axios transformation hooks for request/response processing
 */
export interface AxiosTransform {
  /**
   * Hook that runs before the request is sent
   * @param config The request configuration
   * @param options Request options
   */
  beforeRequestHook?: (
    config: AxiosRequestConfig,
    options: RequestOptions
  ) => AxiosRequestConfig;

  /**
   * Hook that transforms the response data
   * @param res The response object
   * @param options Request options
   */
  transformRequestHook?: <T>(
    res: AxiosResponse<Result<T>>,
    options: RequestOptions
  ) => T | Result<T> | undefined;

  /**
   * Hook that handles request failures
   * @param error The error object
   * @param options Request options
   */
  requestCatchHook?: (
    error: Error | AxiosError,
    options: RequestOptions
  ) => Promise<unknown>;

  /**
   * Interceptor that runs before the request
   * @param config The request configuration
   * @param options Axios creation options
   */
  requestInterceptors?: (
    config: InternalAxiosRequestConfig,
    options: CreateAxiosOptions
  ) => Promise<InternalAxiosRequestConfig> | InternalAxiosRequestConfig;

  /**
   * Interceptor that runs after the response
   * @param response The response object
   */
  responseInterceptors?: <T>(
    response: AxiosResponse<T>
  ) => Promise<AxiosResponse<T>> | AxiosResponse<T>;

  /**
   * Error handler for request interceptor
   * @param error The error object
   */
  requestInterceptorsCatch?: (error: AxiosError) => void;

  /**
   * Error handler for response interceptor
   * @param error The error object
   */
  responseInterceptorsCatch?: (error: AxiosError) => void;
}
