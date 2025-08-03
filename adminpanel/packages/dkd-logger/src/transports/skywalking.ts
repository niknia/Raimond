import { type LogEntry, LogLevel, type SkywalkingOptions, type Transport } from '../types';

/**
 * SkyWalking transport using native fetch API
 */
export class SkywalkingTransport implements Transport {
  private options: SkywalkingOptions;
  private pendingLogs: Array<Promise<void>> = [];
  private isInitialized = false;
  private initializationError: Error | null = null;
  private instanceId: string;
  
  constructor(options: SkywalkingOptions) {
    this.options = options;
    this.instanceId = options.serviceInstance || this.generateInstanceId();
    this.initTransport().catch(err => {
      this.initializationError = err;
      console.warn('SkyWalking transport initialization failed, falling back to console:', err.message);
    });
  }
  
  private generateInstanceId(): string {
    return `instance-${Math.random().toString(36).substring(2, 15)}`;
  }
  
  private async initTransport(): Promise<void> {
    if (this.isInitialized || this.initializationError) {
      return;
    }

    try {
      // Validate collector address
      const url = new URL('/v3/logs', this.options.collectorAddress);
      await fetch(url.toString(), {
        method: 'HEAD',
      });
      
      this.isInitialized = true;
    } catch (error) {
      this.initializationError = error as Error;
      console.warn('SkyWalking transport initialization failed, falling back to console logging');
    }
  }
  
  log(entry: LogEntry): void {
    if (this.initializationError) {
      this.logToConsole(entry);
      return;
    }

    if (!this.isInitialized) {
      this.pendingLogs.push(
        this.initTransport()
          .then(() => this.sendLog(entry))
          .catch(() => this.logToConsole(entry))
      );
      return;
    }

    this.sendLog(entry);
  }
  
  private logToConsole(entry: LogEntry): void {
    const { level, message, context, error } = entry;
    const timestamp = entry.timestamp.toISOString();
    
    let consoleMessage = `[${timestamp}] ${level.toUpperCase()}: ${message}`;
    if (context) {
      consoleMessage += `\nContext: ${JSON.stringify(context, null, 2)}`;
    }
    if (error) {
      consoleMessage += `\nError: ${error.message}\nStack: ${error.stack}`;
    }
    
    switch (level) {
      case LogLevel.DEBUG:
        console.debug(consoleMessage);
        break;
      case LogLevel.INFO:
        console.info(consoleMessage);
        break;
      case LogLevel.WARN:
        console.warn(consoleMessage);
        break;
      case LogLevel.ERROR:
      case LogLevel.FATAL:
        console.error(consoleMessage);
        break;
      default:
        console.log(consoleMessage);
    }
  }
  
  private async sendLog(entry: LogEntry): Promise<void> {
    const { level, message, timestamp, context, error } = entry;
    
    try {
      const url = new URL('/v3/logs', this.options.collectorAddress);
      
      const logData = {
        service: this.options.serviceName,
        serviceInstance: this.instanceId,
        timestamp: timestamp.getTime(),
        level: this.mapLogLevel(level),
        body: {
          text: {
            text: message,
          },
        },
        tags: context || {},
      };
      
      if (error) {
        logData.tags['error'] = {
          message: error.message,
          stack: error.stack,
        };
      }
      
      const promise = fetch(url.toString(), {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(logData),
      }).then(() => {}).catch((err: Error) => {
        console.warn('Failed to send log to SkyWalking, falling back to console:', err.message);
        this.logToConsole(entry);
      });
      
      this.pendingLogs.push(promise);
      
      if (this.pendingLogs.length > 100) {
        this.pendingLogs = this.pendingLogs.filter(p => !p.catch(() => {}));
      }
    } catch (err) {
      this.logToConsole(entry);
    }
  }
  
  private mapLogLevel(level: LogLevel): string {
    switch (level) {
      case LogLevel.DEBUG:
        return 'DEBUG';
      case LogLevel.INFO:
        return 'INFO';
      case LogLevel.WARN:
        return 'WARN';
      case LogLevel.ERROR:
        return 'ERROR';
      case LogLevel.FATAL:
        return 'FATAL';
      default:
        return 'INFO';
    }
  }
  
  async flush(): Promise<void> {
    if (this.pendingLogs.length === 0) {
      return;
    }
    
    try {
      await Promise.all(this.pendingLogs);
      this.pendingLogs = [];
    } catch (error) {
      console.warn('Error flushing SkyWalking logs:', error);
    }
  }
}