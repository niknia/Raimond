import type { BaseEntity, Result } from '@dkd-query';

export interface MenuMeta {
  title: string;
  icon: string | null;
}

export interface MenuItem extends BaseEntity {
  id: number;
  parentId: number | null;
  code: string;
  pCode: string;
  path: string;
  component: string;
  name: string;
  ordinal: number;
  hidden: boolean;
  meta: MenuMeta;
  children: MenuItem[];
}

export interface MenuResponse {
  version: string;
  statusCode: number;
  message: string;
  result: MenuItem[];
}

export interface MenuError {
  success: false;
  message: string;
  error?: unknown;
}

export type MenuResult = Result<MenuItem[]>;

export interface MenuQueryParams {
  page?: number;
  limit?: number;
  search?: string;
  sort?: string;
  order?: 'asc' | 'desc';
}
