import { useCallback } from 'react';
import { useDispatch } from 'react-redux';
import type { BaseEntity } from '../types';
import type { EntitySliceActions } from '../store/types';

export interface EntityOperations<T extends BaseEntity> {
  create: (entity: Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>) => void;
  update: (id: string, changes: Partial<T>) => void;
  delete: (id: string) => void;
  setEntities: (entities: T[]) => void;
}

export function useEntityOperations<T extends BaseEntity>(
  actions: EntitySliceActions<T>
): EntityOperations<T> {
  const dispatch = useDispatch();

  const create = useCallback(
    (entity: Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>) => {
      dispatch(actions.createEntity(entity));
    },
    [dispatch, actions]
  );

  const update = useCallback(
    (id: string, changes: Partial<T>) => {
      dispatch(actions.updateEntity({ id, changes }));
    },
    [dispatch, actions]
  );

  const deleteEntity = useCallback(
    (id: string) => {
      dispatch(actions.deleteEntity(id));
    },
    [dispatch, actions]
  );

  const setEntities = useCallback(
    (entities: T[]) => {
      dispatch(actions.setEntities(entities));
    },
    [dispatch, actions]
  );

  return {
    create,
    update,
    delete: deleteEntity,
    setEntities
  };
} 