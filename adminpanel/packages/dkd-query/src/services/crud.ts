import type { BaseEntity, IEndpointConfig, Result, ResultPage } from '../types/base';
import type { IServiceConfig } from '../types/services';
import { BaseApiService } from './base';


export class CrudService<T extends BaseEntity, U = unknown> extends BaseApiService<T, U> {
  constructor(config: IServiceConfig<T, U>) {
    super(config);
    this.validateRequiredEndpoints();
  }

  private validateRequiredEndpoints() {
    const requiredEndpoints: (keyof IEndpointConfig<T>)[] = [
      'getAll', 'getById', 'create', 'update', 'delete', 'getPaginated'
    ];

    for (const endpoint of requiredEndpoints) {
      if (!this.config.endpoints[endpoint]) {
        throw new Error(`Missing required endpoint: ${endpoint}`);
      }
    }
  }

  async getAll(): Promise<Result<T[]>> {
    return this.get<Result<T[]>>(this.config.endpoints.getAll);
  }

  async getById(id: number): Promise<T> {
    return this.get<T>(this.config.endpoints.getById(id));
  }

  async create(data: Partial<T>): Promise<T> {
    return this.post<T>(this.config.endpoints.create, data);
  }

  async update(data: T): Promise<T> {
    return this.put<T>(this.config.endpoints.update(data.id), data);
  }

  async delete(id: number): Promise<void> {
    await this.deleteRequest(this.config.endpoints.delete(id));
  }

  async getPaginated(params: { page: number; limit: number }): Promise<ResultPage<T>> {
    const paramsString = new URLSearchParams(params as unknown as Record<string, string>).toString();
    const endpoint = this.config.endpoints.getPaginated(paramsString);
    const result = await this.get<ResultPage<T>>(endpoint);
    return {
      ...result,
      result: {
        ...result.result,
        pageIndex: params.page,
        pageSize: params.limit,
      },
    };
  }
}