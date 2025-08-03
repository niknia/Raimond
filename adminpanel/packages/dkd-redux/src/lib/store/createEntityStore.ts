import { configureStore, combineReducers } from '@reduxjs/toolkit';
import { createGenericSlice } from '../slices/createGenericSlice';
import type { BaseEntity } from '../types';

/**
 * Configuration options for creating an entity store
 */
export interface CreateEntityStoreOptions<T extends BaseEntity> {
  /**
   * The name of the slice
   */
  name: string;

  /**
   * Function to fetch entities from API
   */
  fetchEntities?: () => Promise<T[]>;
  /**
   * Function to create a new entity
   */
  createEntity?: (entity: Omit<T, 'id' | 'createdAt' | 'updatedAt' | 'version'>) => Promise<T>;
  /**
   * Function to update an existing entity
   */
  updateEntity?: (id: string, entity: Partial<T>) => Promise<T>;
  /**
   * Function to delete an entity
   */
  deleteEntity?: (id: string) => Promise<void>;
  /**
   * Optional extraReducers for async/thunk support
   */
  extraReducers?: any;
}

/**
 * Creates a complete entity store with all necessary actions and thunks
 * اکنون می‌توانید چند اسلایس را با هم ترکیب کنید و extraReducers را نیز ارسال نمایید.
 */
export function createEntityStore<T extends BaseEntity>(options: CreateEntityStoreOptions<T> | CreateEntityStoreOptions<T>[]) {
  if (Array.isArray(options)) {
    // حالت چند اسلایس
    const reducers: { [key: string]: any } = {};
    const slices: any[] = [];
    options.forEach(opt => {
      const slice = createGenericSlice<T>({ name: opt.name, extraReducers: opt.extraReducers });
      reducers[opt.name] = slice.reducer;
      slices.push(slice);
    });
    const store = configureStore({
      reducer: combineReducers(reducers),
      devTools: true
    });
    return {
      slices,
      store,
      actions: slices.reduce((acc, slice) => ({ ...acc, [slice.name]: slice.actions }), {}),
      types: {
        RootState: store.getState(),
        AppDispatch: store.dispatch
      }
    };
  } else {
    // حالت تک اسلایس
    const slice = createGenericSlice<T>({ name: options.name, extraReducers: options.extraReducers });
    const store = configureStore({
      reducer: {
        [options.name]: slice.reducer
      },
      devTools: true
    });
    return {
      slice,
      store,
      actions: slice.actions,
      types: {
        RootState: store.getState(),
        AppDispatch: store.dispatch
      }
    };
  }
} 