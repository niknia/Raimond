import { createSlice, type Slice } from '@reduxjs/toolkit';
import type { Draft, PayloadAction } from '@reduxjs/toolkit';
import { v4 as uuidv4 } from 'uuid';
import type { 
  BaseEntity, 
  GenericState, 
  QueryParams,
  StoreOptions 
} from '../types';

/**
 * Options for creating a generic slice
 */
export interface CreateGenericSliceOptions<T extends BaseEntity> {
  /**
   * The name of the slice
   */
  name: string;
  /**
   * Optional extraReducers for async/thunk support
   */
  extraReducers?: any;
}

/**
 * Creates initial state for the generic slice
 */
export const createInitialGenericState = <T extends BaseEntity>(): GenericState<T> => ({
  entities: {},
  ids: [],
  loading: false,
  error: null,
  lastSync: null,
  currentVersion: 1,
  history: {},
  enabled: true,
  maxVersionsPerEntity: 10
});

/**
 * Creates a generic slice with CRUD operations
 */
export const createGenericSlice = <T extends BaseEntity>({
  name,
  extraReducers
}: CreateGenericSliceOptions<T>): Slice<GenericState<T>> => {
  const initialState = createInitialGenericState<T>();

  return createSlice({
    name,
    initialState,
    reducers: {
      // Create entity
      createEntity(state, action: PayloadAction<Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>>) {
        const timestamp = Date.now();
        const entity = {
          ...action.payload,
          id: uuidv4(),
          createdAt: timestamp,
          updatedAt: timestamp,
          version: 1
        } as Draft<T>;
        
        state.entities[entity.id] = entity;
        state.ids.push(entity.id);
        state.currentVersion++;
      },

      // Update entity
      updateEntity(state, action: PayloadAction<{ id: string; changes: Partial<T> }>) {
        const { id, changes } = action.payload;
        const timestamp = Date.now();
        
        if (state.entities[id]) {
          const oldEntity = state.entities[id];
          const newEntity = {
            ...oldEntity,
            ...changes,
            updatedAt: timestamp,
            version: oldEntity.version + 1
          } as Draft<T>;

          if (state.enabled) {
            if (!state.history[id]) {
              state.history[id] = [];
            }
            state.history[id].push({
              entityId: id,
              timestamp,
              version: oldEntity.version,
              snapshot: oldEntity,
              changeType: 'update'
            });

            // Keep only the last N versions
            if (state.history[id].length > state.maxVersionsPerEntity) {
              state.history[id] = state.history[id].slice(-state.maxVersionsPerEntity);
            }
          }

          state.entities[id] = newEntity;
          state.currentVersion++;
        }
      },

      // Delete entity
      deleteEntity(state, action: PayloadAction<string>) {
        const id = action.payload;
        if (state.entities[id]) {
          if (state.enabled) {
            if (!state.history[id]) {
              state.history[id] = [];
            }
            state.history[id].push({
              entityId: id,
              timestamp: Date.now(),
              version: state.entities[id].version,
              snapshot: state.entities[id],
              changeType: 'delete'
            });
          }

          delete state.entities[id];
          state.ids = state.ids.filter(entityId => entityId !== id);
          state.currentVersion++;
        }
      },

      // Set multiple entities
      setEntities(state, action: PayloadAction<T[]>) {
        const newEntities: Record<string, Draft<T>> = {};
        const newIds: string[] = [];
        
        for (const entity of action.payload) {
          newEntities[entity.id] = entity as Draft<T>;
          newIds.push(entity.id);
        }
        
        state.entities = newEntities;
        state.ids = newIds;
        state.lastSync = Date.now();
        state.currentVersion++;
      },

      // Set loading state
      setLoading(state, action: PayloadAction<boolean>) {
        state.loading = action.payload;
      },

      // Set error state
      setError(state, action: PayloadAction<string | null>) {
        state.error = action.payload;
      }
    },
    ...(extraReducers ? { extraReducers } : {})
  });
}; 