/**
 * Available log levels
 */
export enum LogLevel {
  DEBUG = 'debug',
  INFO = 'info',
  WARN = 'warn',
  ERROR = 'error',
  FATAL = 'fatal',
}

/**
 * Log entry structure
 */
export interface LogEntry {
  level: LogLevel;
  message: string;
  timestamp: Date;
  context?: Record<string, any>;
  error?: Error;
}

/**
 * Logger configuration options
 */
export interface LoggerOptions {
  /**
   * Minimum log level to output
   * @default LogLevel.INFO
   */
  minLevel?: LogLevel;
  
  /**
   * Force development mode (console output)
   * @default false
   */
  forceDevelopment?: boolean;
  
  /**
   * Force production mode (SkyWalking output)
   * @default false
   */
  forceProduction?: boolean;
  
  /**
   * SkyWalking configuration
   */
  skywalking?: SkywalkingOptions;
  
  /**
   * Custom transports for log entries
   */
  customTransports?: Transport[];
  
  /**
   * Format function for log message
   */
  formatter?: (entry: LogEntry) => string;
}

/**
 * SkyWalking configuration
 */
export interface SkywalkingOptions {
  /**
   * SkyWalking collector service address
   * @example "http://skywalking-collector:12800"
   */
  collectorAddress: string;
  
  /**
   * Service name to report to SkyWalking
   */
  serviceName: string;
  
  /**
   * Service instance name
   * @default hostname
   */
  serviceInstance?: string;
}

/**
 * Transport interface for log entries
 */
export interface Transport {
  /**
   * Log a message using this transport
   */
  log(entry: LogEntry): void;
  
  /**
   * Optional method to flush any pending logs
   */
  flush?(): Promise<void>;
}

/**
 * Logger interface
 */
export interface Logger {
  debug(message: string, context?: Record<string, any>): void;
  info(message: string, context?: Record<string, any>): void;
  warn(message: string, context?: Record<string, any>): void;
  error(message: string, context?: Record<string, any>, error?: Error): void;
  fatal(message: string, context?: Record<string, any>, error?: Error): void;
  
  /**
   * Log an entry with custom level
   */
  log(level: LogLevel, message: string, context?: Record<string, any>, error?: Error): void;
  
  /**
   * Flush all transports
   */
  flush(): Promise<void>;
}