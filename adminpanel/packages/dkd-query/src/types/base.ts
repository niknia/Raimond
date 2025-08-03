export interface BaseEntity {
  id: number | string;
}

export interface Result<T>{
  version: string;
  result: T[];
  message: string;
  statusCode?:number;
  isError?:boolean;
}

export interface ResultPage<T>{
  version: string;
  statusCode: number;
  message: string;
  result: {
    data: T[];
    rowsCount: number;
    pageIndex: number;
    pageSize: number;
    pageCount: number;
    totalCount: number;
    xData: any;
  };
  isError?:boolean;
}

export interface IEndpointConfig<T> {
  getAll: string;
  getById: (id: string | number) => string;
  create: string;
  update: (id: string | number) => string;
  delete: (id: string | number) => string;
  getPaginated: (params: string) => string;
  [key: string]: any; // For custom endpoints
}