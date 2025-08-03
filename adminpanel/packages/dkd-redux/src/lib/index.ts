/**
 * redux-toolkit-generic
 * A generic Redux Toolkit package for managing entity state
 * 
 * This package provides a set of utilities for creating and managing
 * generic entity stores in Redux, with built-in support for:
 * - Type-safe CRUD operations
 * - Optimized state management
 * - React hooks for easy integration
 * - Entity versioning
 */

// Core functionality
export { createGenericSlice, createInitialGenericState } from './slices/createGenericSlice';
export type { CreateGenericSliceOptions } from './slices/createGenericSlice';

// Store configuration
export { 
  configureGenericStore,
  createInitialState,
  hasVersioning
} from './store/configureStore';
export type { GenericStoreOptions } from './store/configureStore';

// Entity store factory
export { createEntityStore } from './store/createEntityStore';
export type { CreateEntityStoreOptions } from './store/createEntityStore';

// Hooks for React integration
export { useEntityStore } from './hooks';
export type { UseEntityStoreResult } from './hooks';

// Core types
export type {
  // Entity types
  BaseEntity,
  GenericState,
  QueryParams,
  StoreOptions,
  
  // Action types
  EntityActions,
  
  // State types
  ReduxState,
  
  // Utility types
  AsyncStatus,
  EntitySelector,
  
  // Version history types
  VersionHistoryEntry,
  VersioningState
} from './types';

// Store types and configuration
export type {
  RootState,
  EntitySliceActions
} from './store/types';