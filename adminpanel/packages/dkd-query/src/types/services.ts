import type { UriString } from '@dkd-axios';
import type { BaseEntity, IEndpointConfig, Result } from './base';

export interface ICrudService<T extends BaseEntity, U = unknown> {
  baseUrl: string;
  getAll(): Promise<Result<T[]>>;
  getById(id: number): Promise<T>;
  create(data: Partial<T>): Promise<T>;
  update(data: T): Promise<T>;
  delete(id: number): Promise<void>;
  getPaginated(params: { page: number; limit: number }): Promise<{ data: T[]; total: number }>;
}

export interface IServiceConfig<T, U = unknown> {
  baseUrl: string;
  endpoints: IEndpointConfig<T> & U;
}