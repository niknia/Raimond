import { DefaultLogger } from './logger';
import { LoggerOptions } from './types';

declare global {
  var globalLogger: DefaultLogger;
  
  interface Window {
    logger: DefaultLogger;
  }
  
  function debug(message: string, context?: Record<string, any>): void;
  function info(message: string, context?: Record<string, any>): void;
  function warn(message: string, context?: Record<string, any>): void;
  function error(message: string, context?: Record<string, any>, error?: Error): void;
  function fatal(message: string, context?: Record<string, any>, error?: Error): void;
}

let logger: DefaultLogger;

export function initializeGlobalLogger(options: LoggerOptions = {}): void {
  logger = new DefaultLogger(options);
  
  // Set up global logger instance
  if (typeof window !== 'undefined') {
    window.logger = logger;
  }
  if (typeof global !== 'undefined') {
    (global as any).globalLogger = logger;
  }
  
  // Set up global logging functions
  const globalFunctions = {
    debug: (message: string, context?: Record<string, any>) => logger.debug(message, context),
    info: (message: string, context?: Record<string, any>) => logger.info(message, context),
    warn: (message: string, context?: Record<string, any>) => logger.warn(message, context),
    error: (message: string, context?: Record<string, any>, error?: Error) => logger.error(message, context, error),
    fatal: (message: string, context?: Record<string, any>, error?: Error) => logger.fatal(message, context, error),
  };
  
  // Add to both window and global scope
  if (typeof window !== 'undefined') {
    Object.assign(window, globalFunctions);
  }
  if (typeof global !== 'undefined') {
    Object.assign(global, globalFunctions);
  }
}

export function getLogger(): DefaultLogger {
  if (!logger) {
    initializeGlobalLogger();
  }
  return logger;
}