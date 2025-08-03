import { useCallback } from 'react';
import type { Draft } from '@reduxjs/toolkit';
import type { BaseEntity, GenericState, QueryParams } from '../types';

export interface EntityQueries<T extends BaseEntity> {
  getById: (id: string) => T | Draft<T> | undefined;
  getAll: () => (T | Draft<T>)[];
  query: (params: QueryParams) => (T | Draft<T>)[];
}

export function useEntityQueries<T extends BaseEntity>(
  state: GenericState<T>
): EntityQueries<T> {
  // Get entity by ID
  const getById = useCallback(
    (id: string) => state.entities[id],
    [state.entities]
  );

  // Get all entities
  const getAll = useCallback(
    () => state.ids.map(id => state.entities[id]),
    [state.ids, state.entities]
  );

  // Query entities with filters and sorting
  const query = useCallback(
    (params: QueryParams) => {
      let results = getAll();

      // Apply filters
      if (params.filters) {
        results = results.filter(entity => {
          return Object.entries(params.filters || {}).every(([key, value]) => {
            const entityKey = key as keyof (T | Draft<T>);
            return entity[entityKey] === value;
          });
        });
      }

      // Apply sorting
      const sort = params.sort || [];
      if (sort.length > 0) {
        results.sort((a, b) => {
          for (const { field, direction } of sort) {
            const fieldKey = field as keyof (T | Draft<T>);
            const aValue = a[fieldKey];
            const bValue = b[fieldKey];
            if (aValue !== bValue) {
              return direction === 'asc' 
                ? (aValue < bValue ? -1 : 1)
                : (aValue < bValue ? 1 : -1);
            }
          }
          return 0;
        });
      }

      return results;
    },
    [getAll]
  );

  return {
    getById,
    getAll,
    query
  };
} 