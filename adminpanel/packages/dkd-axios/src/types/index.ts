import type { UriString } from '../uitls';
import type { AxiosRequestConfig, InternalAxiosRequestConfig } from 'axios';

export enum ContentTypeEnum {
  JSON = 'application/json;charset=UTF-8',
  FORM_URLENCODED = 'application/x-www-form-urlencoded;charset=UTF-8',
  FORM_DATA = 'multipart/form-data;charset=UTF-8',
}

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

export interface VAxiosRequestConfig extends AxiosRequestConfig {
  uri?: UriString;
  url?: string;
  _retry?: boolean;
  requestOptions?: RequestOptions;
  data?: unknown;
}

export interface VAxiosInternalRequestConfig extends InternalAxiosRequestConfig {
  _retry?: boolean;
  requestOptions?: RequestOptions;
}

export interface AuthResponse {
  token: string;
  refreshToken?: string;
  expire?: string;
  refreshExpire?: string;
  user?: {
    id: string;
    username: string;
    name: string;
    roleIds: string;
    loginType: string;
  };
}

export interface UriExtension {
  _uriType: string;
  value: string;
  toString(): string;
}

export type Recordable<T = unknown> = Record<string, T>; 