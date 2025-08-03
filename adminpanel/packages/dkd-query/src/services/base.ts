import { request } from '@dkd-axios';
import type { VAxiosRequestConfig, UriString } from '@dkd-axios';
import type { BaseEntity } from '../types/base';
import type { IServiceConfig } from '../types/services';


export abstract class BaseApiService<T extends BaseEntity, U = unknown> {
  protected readonly config: IServiceConfig<T, U>;

  constructor(config: IServiceConfig<T, U>) {
    this.config = config;
  }

  protected async get<R>(endpoint: string, params?: Record<string, unknown>): Promise<R> {
    const response = await request.get<R>({ url: endpoint, params });
    return response;
  }

  protected async post<R>(endpoint: string, data?: unknown): Promise<R> {
    const response = await request.post<R>({ url: endpoint, data });
    return response;
  }

  protected async put<R>(endpoint: string, data?: unknown): Promise<R> {
    const response = await request.put<R>({ url: endpoint, data });
    return response;
  }

  protected async deleteRequest(endpoint: string): Promise<void> {
    await request.delete({ url: endpoint });
  }

  get baseUrl(): string {
    return this.config.baseUrl;
  }
}