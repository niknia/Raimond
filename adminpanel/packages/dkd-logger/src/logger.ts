import { type Logger, type LogEntry, LogLevel, type LoggerOptions, type Transport } from './types';
import { ConsoleTransport } from './transports/console';
import { SkywalkingTransport } from './transports/skywalking';

/**
 * Default logger implementation
 */
export class DefaultLogger implements Logger {
  private options: LoggerOptions;
  private transports: Transport[] = [];
  
  constructor(options: LoggerOptions = {}) {
    this.options = {
      minLevel: LogLevel.INFO,
      ...options,
    };
    
    this.initTransports();
  }
  
  private initTransports(): void {
    // Clear any existing transports
    this.transports = [];
    
    // Determine if we're in development or production
    const isDev = this.isDevelopment();
    
    if (isDev) {
      // In development, use console transport
      this.transports.push(new ConsoleTransport());
    } else {
      // In production, use SkyWalking transport if configured
      if (this.options.skywalking) {
        this.transports.push(new SkywalkingTransport(this.options.skywalking));
      } else {
        // Fallback to console transport in production if SkyWalking not configured
        this.transports.push(new ConsoleTransport({ useColors: false }));
      }
    }
    
    // Add any custom transports
    if (this.options.customTransports) {
      this.transports.push(...this.options.customTransports);
    }
  }
  
  private isDevelopment(): boolean {
    // Check for explicit mode settings
    if (this.options.forceDevelopment === true) {
      return true;
    }
    
    if (this.options.forceProduction === true) {
      return false;
    }
    
    // Try to detect NextJS environment
    if (typeof process !== 'undefined') {
      // Using bracket notation due to noPropertyAccessFromIndexSignature compiler option
      return process.env['NODE_ENV'] === 'development' 
        || process.env['NEXT_PUBLIC_NODE_ENV'] === 'development';
    }
    
    // Default to production if we can't determine
    return false;
  }
  
  /**
   * Creates a log entry and sends it to all transports
   */
  private createAndSendLog(level: LogLevel, message: string, context?: Record<string, any>, error?: Error): void {
    // Skip if below minimum log level
    if (this.shouldSkipLog(level)) {
      return;
    }
    
    const entry: LogEntry = {
      level,
      message,
      timestamp: new Date(),
      context,
      error,
    };
    
    // Send to all transports
    for (const transport of this.transports) {
      try {
        transport.log(entry);
      } catch (err) {
        console.error('Error sending log to transport:', err);
      }
    }
  }
  
  private shouldSkipLog(level: LogLevel): boolean {
    const levels = Object.values(LogLevel);
    const minLevelIndex = levels.indexOf(this.options.minLevel || LogLevel.INFO);
    const currentLevelIndex = levels.indexOf(level);
    
    return currentLevelIndex < minLevelIndex;
  }
  
  // Logger interface implementation
  debug(message: string, context?: Record<string, any>): void {
    this.createAndSendLog(LogLevel.DEBUG, message, context);
  }
  
  info(message: string, context?: Record<string, any>): void {
    this.createAndSendLog(LogLevel.INFO, message, context);
  }
  
  warn(message: string, context?: Record<string, any>): void {
    this.createAndSendLog(LogLevel.WARN, message, context);
  }
  
  error(message: string, context?: Record<string, any>, error?: Error): void {
    this.createAndSendLog(LogLevel.ERROR, message, context, error);
  }
  
  fatal(message: string, context?: Record<string, any>, error?: Error): void {
    this.createAndSendLog(LogLevel.FATAL, message, context, error);
  }
  
  log(level: LogLevel, message: string, context?: Record<string, any>, error?: Error): void {
    this.createAndSendLog(level, message, context, error);
  }
  
  async flush(): Promise<void> {
    await Promise.all(this.transports.map(transport => {
      if (transport.flush) {
        return transport.flush();
      }
      return Promise.resolve();
    }));
  }
}