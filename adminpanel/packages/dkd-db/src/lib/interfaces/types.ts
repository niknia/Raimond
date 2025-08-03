import type { Database } from '@nozbe/watermelondb';

/**
 * Base entity interface that all entities must implement
 */
export interface EntityModel {
  id: string;
  createdAt?: number;
  updatedAt?: number;
  version?: number;
}

/**
 * Query options for filtering, sorting and pagination
 */
export interface QueryOptions {
  filter?: Record<string, unknown>;
  sort?: Array<{
    field: string;
    direction: 'asc' | 'desc';
  }>;
  limit?: number;
  offset?: number;
  query?: any[]; // Custom query clauses from Q (any type to avoid circular dependencies)
}

/**
 * Repository configuration options
 */
export interface RepositoryConfig {
  database: Database;
  modelName: string;
  versionTracking?: boolean;
}

// Generic state interface for Redux store
export interface GenericState<T> {
  data: Record<string, T>;
  status: AsyncStatus;
  error: string | null;
  lastUpdated: number | null;
}

// Async operation status
export type AsyncStatus = 'idle' | 'loading' | 'succeeded' | 'failed';

// Query parameters for fetching entities
export interface QueryParams {
  filter?: Record<string, unknown>;
  sort?: Array<{
    field: string;
    direction: 'asc' | 'desc';
  }>;
  page?: number;
  limit?: number;
}

// Store options for configuring entity store
export interface StoreOptions {
  name: string;
  initialState?: Record<string, unknown>;
  reducers?: Record<string, unknown>;
  selectors?: Record<string, unknown>;
}

// Entity actions interface
export interface EntityActions<T> {
  add: (entity: T) => void;
  update: (id: string, changes: Partial<T>) => void;
  remove: (id: string) => void;
  setAll: (entities: T[]) => void;
  clear: () => void;
}

// Redux state interface
export interface ReduxState {
  [key: string]: unknown;
}

// Entity selector interface
export interface EntitySelector<T> {
  selectAll: () => T[];
  selectById: (id: string) => T | undefined;
  selectIds: () => string[];
  selectTotal: () => number;
  selectEntities: () => Record<string, T>;
} 