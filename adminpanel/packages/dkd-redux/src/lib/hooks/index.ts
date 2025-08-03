import { useSelector } from 'react-redux';
import type { Draft } from '@reduxjs/toolkit';
import type { BaseEntity, GenericState, VersionHistoryEntry } from '../types';

export interface UseEntityStoreResult<T extends BaseEntity> {
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

export const useEntityStore = <T extends BaseEntity>(sliceName: string): UseEntityStoreResult<T> => {
  return useSelector((state: { [key: string]: GenericState<T> }) => state[sliceName]);
}; 