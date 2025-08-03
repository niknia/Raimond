import { LogEntry, LogLevel, Transport } from '../types';

/**
 * Console transport options
 */
export interface ConsoleTransportOptions {
  /**
   * Whether to use colors in console output
   * @default true
   */
  useColors?: boolean;
  
  /**
   * Whether to log stack traces for errors
   * @default true
   */
  logStackTraces?: boolean;
  
  /**
   * Custom formatter for log messages
   */
  formatter?: (entry: LogEntry) => string;
}

/**
 * Default color mapping for different log levels
 */
const LOG_LEVEL_COLORS = {
  [LogLevel.DEBUG]: '\x1b[36m', // cyan
  [LogLevel.INFO]: '\x1b[32m',  // green
  [LogLevel.WARN]: '\x1b[33m',  // yellow
  [LogLevel.ERROR]: '\x1b[31m', // red
  [LogLevel.FATAL]: '\x1b[35m', // magenta
};

const RESET_COLOR = '\x1b[0m';

/**
 * Default log formatter
 */
function defaultFormatter(entry: LogEntry, useColors: boolean): string {
  const { level, message, timestamp, context, error } = entry;
  
  // Format timestamp
  const time = timestamp.toISOString();
  
  // Format level with appropriate color
  const levelStr = useColors 
    ? `${LOG_LEVEL_COLORS[level]}${level.toUpperCase()}${RESET_COLOR}`
    : level.toUpperCase();
  
  // Basic formatted message
  let formattedMessage = `[${time}] ${levelStr}: ${message}`;
  
  // Add context if available
  if (context && Object.keys(context).length > 0) {
    formattedMessage += `\n  Context: ${JSON.stringify(context, null, 2)}`;
  }
  
  // Add error if available
  if (error) {
    formattedMessage += `\n  Error: ${error.message}`;
    if (error.stack) {
      formattedMessage += `\n  Stack: ${error.stack}`;
    }
  }
  
  return formattedMessage;
}

/**
 * Console transport implementation for the logger
 */
export class ConsoleTransport implements Transport {
  private options: ConsoleTransportOptions;
  
  constructor(options: ConsoleTransportOptions = {}) {
    this.options = {
      useColors: true,
      logStackTraces: true,
      ...options,
    };
  }
  
  log(entry: LogEntry): void {
    const { level } = entry;
    const message = this.options.formatter 
      ? this.options.formatter(entry) 
      : defaultFormatter(entry, this.options.useColors || false);
    
    switch (level) {
      case LogLevel.DEBUG:
        console.debug(message);
        break;
      case LogLevel.INFO:
        console.info(message);
        break;
      case LogLevel.WARN:
        console.warn(message);
        break;
      case LogLevel.ERROR:
      case LogLevel.FATAL:
        console.error(message);
        break;
      default:
        console.log(message);
    }
  }
  
  flush(): Promise<void> {
    // Console doesn't need flushing
    return Promise.resolve();
  }
}