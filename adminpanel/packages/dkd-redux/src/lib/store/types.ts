import type { BaseEntity, GenericState } from '../types';
import type { PayloadAction } from '@reduxjs/toolkit';

export interface RootState {
  [key: string]: GenericState<BaseEntity>;
}

export interface EntitySliceActions<T extends BaseEntity> {
  createEntity: (entity: Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>) => PayloadAction<Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>>;
  updateEntity: (params: { id: string; changes: Partial<T> }) => PayloadAction<{ id: string; changes: Partial<T> }>;
  deleteEntity: (id: string) => PayloadAction<string>;
  setEntities: (entities: T[]) => PayloadAction<T[]>;
  setLoading: (loading: boolean) => PayloadAction<boolean>;
  setError: (error: string | null) => PayloadAction<string | null>;
} 