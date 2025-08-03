/**
 * Core types for redux-toolkit-generic
 */

import type { Draft, Middleware } from '@reduxjs/toolkit';

// Base entity that all models must extend
export interface BaseEntity {
  id: string;
  createdAt: number;
  updatedAt: number;
  version: number;
}

// Generic state interface
export interface GenericState<T extends BaseEntity> {
  entities: Record<string, T | Draft<T>>;
  ids: string[];
  loading: boolean;
  error: string | null;
  lastSync: number | null;
  currentVersion: number;
  history: Record<string, VersionHistoryEntry<T>[]>;
  enabled: boolean;
  maxVersionsPerEntity: number;
}

// Query parameters for filtering and pagination
export interface QueryParams {
  limit?: number;
  offset?: number;
  filters?: Record<string, unknown>;
  sort?: Array<{
    field: string;
    direction: 'asc' | 'desc';
  }>;
}

// Store configuration options
export interface StoreOptions {
  enableVersioning?: boolean;
  maxVersionsPerEntity?: number;
  middleware?: Middleware[];
  extraReducers?: unknown;
}

// Action types
export interface EntityActions<T extends BaseEntity> {
  createEntity: (entity: Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>) => void;
  updateEntity: (params: { id: string; changes: Partial<T> }) => void;
  deleteEntity: (id: string) => void;
  setEntities: (entities: T[]) => void;
  setLoading: (loading: boolean) => void;
  setError: (error: string | null) => void;
}

// Version history entry type
export interface VersionHistoryEntry<T extends BaseEntity> {
  entityId: string;
  timestamp: number;
  version: number;
  snapshot: T | Draft<T>;
  changeType: 'create' | 'update' | 'delete';
  metadata?: Record<string, unknown>;
}

// Versioning state interface
export interface VersioningState<T extends BaseEntity> {
  history: Record<string, VersionHistoryEntry<T>[]>;
  enabled: boolean;
  maxVersionsPerEntity: number;
}

// Redux state type
export interface ReduxState {
  [key: string]: GenericState<BaseEntity>;
}

// Async operation status
export type AsyncStatus = 'idle' | 'loading' | 'succeeded' | 'failed';

// Entity selector type
export type EntitySelector<T extends BaseEntity> = (state: ReduxState) => T | Draft<T>;