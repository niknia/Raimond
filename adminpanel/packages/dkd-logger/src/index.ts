import { initializeGlobalLogger } from './global';
export * from './types';
export * from './logger';
export * from './transports/console';
export * from './transports/skywalking';
export * from './next/middleware';
export * from './next/withLogger';
export * from './global';

// Initialize global logger by default
initializeGlobalLogger();

// Re-export for TypeScript support
export { LogLevel } from './types';

export default initializeGlobalLogger;