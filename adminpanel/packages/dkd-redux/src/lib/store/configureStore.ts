import { configureStore, combineReducers } from '@reduxjs/toolkit';
import type { Middleware, AnyAction, Reducer } from '@reduxjs/toolkit';
import type { BaseEntity, GenericState } from '../types';

export interface GenericStoreOptions {
  middleware?: Middleware[];
  devTools?: boolean;
}

// حالت جدید: دریافت یک شیء از reducerها یا یک reducer تکی
export const configureGenericStore = <T extends BaseEntity>(
  reducers: { [key: string]: Reducer<any, AnyAction> } | Reducer<any, AnyAction>,
  preloadedState?: any,
  { middleware = [], devTools = true }: GenericStoreOptions = {}
) => {
  const rootReducer =
    typeof reducers === 'function' ? reducers : combineReducers(reducers);

  return configureStore({
    reducer: rootReducer,
    preloadedState,
    middleware: (getDefaultMiddleware) =>
      getDefaultMiddleware().concat(middleware),
    devTools
  });
};

export const createInitialState = <T extends BaseEntity>(): GenericState<T> => ({
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

export const hasVersioning = <T extends BaseEntity>(state: GenericState<T>): boolean => {
  return state.enabled && state.maxVersionsPerEntity > 0;
}; 