import type { Database, Model } from '@nozbe/watermelondb';
import { useCallback, useMemo, useState } from 'react';
import type { EntityModel, QueryOptions } from './interfaces/types.js';
import { GenericRepository } from './core/genericRepository.js';

/**
 * Hook for creating a repository instance
 */
export function useCreateRepository<T extends EntityModel, M extends Model>(
  database: Database,
  modelName: string
) {
  return useMemo(() => {
    return new GenericRepository<T, M>(database, modelName);
  }, [database, modelName]);
}

/**
 * Hook to fetch and manage a collection of entities from a WatermelonDB repository
 */
export function useRepository<T extends EntityModel, M extends Model>(
  database: Database,
  modelName: string
) {
  const repository = useCreateRepository<T, M>(database, modelName);
  const [error, setError] = useState<Error | null>(null);
  const [loading, setLoading] = useState(false);

  const getAll = useCallback(async (queryOptions?: QueryOptions) => {
    try {
      setLoading(true);
      return await repository.getAll(queryOptions);
    } catch (err) {
      setError(err instanceof Error ? err : new Error('Unknown error'));
      return [];
    } finally {
      setLoading(false);
    }
  }, [repository]);

  const getById = useCallback(async (id: string) => {
    try {
      setLoading(true);
      return await repository.getById(id);
    } catch (err) {
      setError(err instanceof Error ? err : new Error('Unknown error'));
      return null;
    } finally {
      setLoading(false);
    }
  }, [repository]);

  const create = useCallback(async (entity: Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>) => {
    try {
      setLoading(true);
      return await repository.create(entity);
    } catch (err) {
      setError(err instanceof Error ? err : new Error('Unknown error'));
      throw err;
    } finally {
      setLoading(false);
    }
  }, [repository]);

  const update = useCallback(async (id: string, changes: Partial<Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>>) => {
    try {
      setLoading(true);
      return await repository.update(id, changes);
    } catch (err) {
      setError(err instanceof Error ? err : new Error('Unknown error'));
      throw err;
    } finally {
      setLoading(false);
    }
  }, [repository]);

  const remove = useCallback(async (id: string) => {
    try {
      setLoading(true);
      return await repository.delete(id);
    } catch (err) {
      setError(err instanceof Error ? err : new Error('Unknown error'));
      return false;
    } finally {
      setLoading(false);
    }
  }, [repository]);

  return {
    repository,
    error,
    loading,
    getAll,
    getById,
    create,
    update,
    remove
  };
}

/**
 * Hook to fetch and manage a single entity from a WatermelonDB repository
 */
export function useEntity<T extends EntityModel, M extends Model>(
  database: Database,
  modelName: string,
  id: string
) {
  const { getById, update, remove, error, loading } = useRepository<T, M>(database, modelName);
  const [entity, setEntity] = useState<T | null>(null);

  const refresh = useCallback(async () => {
    const result = await getById(id);
    setEntity(result);
    return result;
  }, [getById, id]);

  const updateEntity = useCallback(async (changes: Partial<Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>>) => {
    const result = await update(id, changes);
    setEntity(result);
    return result;
  }, [update, id]);

  const removeEntity = useCallback(async () => {
    const result = await remove(id);
    if (result) {
      setEntity(null);
    }
    return result;
  }, [remove, id]);

  return {
    entity,
    error,
    loading,
    refresh,
    update: updateEntity,
    remove: removeEntity
  };
}
