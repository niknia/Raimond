import { ContentTypeEnum } from '../types';

export interface AxiosConfig {
  baseUrl: string;
  apiPrefix: string;
  timeout: number;
  withCredentials: boolean;
  headers: Record<string, string>;
  requestOptions: {
    isJoinPrefix: boolean;
    isReturnNativeResponse: boolean;
    isTransformResponse: boolean;
    joinParamsToUrl: boolean;
    formatDate: boolean;
    joinTime: boolean;
    ignoreRepeatRequest: boolean;
    withToken: boolean;
    retry: {
      count: number;
      delay: number;
    };
  };
}

const defaultConfig: AxiosConfig = {
  baseUrl: '',
  apiPrefix: '',
  timeout: 10000,
  withCredentials: false,
  headers: { 'Content-Type': ContentTypeEnum.JSON },
  requestOptions: {
    isJoinPrefix: true,
    isReturnNativeResponse: true,
    isTransformResponse: true,
    joinParamsToUrl: false,
    formatDate: true,
    joinTime: true,
    ignoreRepeatRequest: true,
    withToken: true,
    retry: {
      count: 3,
      delay: 1000,
    },
  },
};

class AxiosConfigManager {
  private static instance: AxiosConfigManager;
  private config: AxiosConfig;

  private constructor() {
    this.config = { ...defaultConfig };
  }

  public static getInstance(): AxiosConfigManager {
    if (!AxiosConfigManager.instance) {
      AxiosConfigManager.instance = new AxiosConfigManager();
    }
    return AxiosConfigManager.instance;
  }

  public setConfig(newConfig: Partial<AxiosConfig>): void {
    this.config = {
      ...this.config,
      ...newConfig,
      requestOptions: {
        ...this.config.requestOptions,
        ...(newConfig.requestOptions || {}),
      },
    };
  }

  public getConfig(): AxiosConfig {
    return this.config;
  }

  public resetConfig(): void {
    this.config = { ...defaultConfig };
  }
}

export const axiosConfig = AxiosConfigManager.getInstance(); 