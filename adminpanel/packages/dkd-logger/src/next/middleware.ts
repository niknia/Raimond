import { type NextRequest, NextResponse } from 'next/server';
import { DefaultLogger } from '../logger';
import type { LoggerOptions } from '../types';

/**
 * NextJS middleware for request logging with SkyWalking integration
 */
export function createLoggerMiddleware(options: LoggerOptions = {}) {
  const logger = new DefaultLogger(options);
  
  return function loggerMiddleware(req: NextRequest) {
    const start = Date.now();
    const requestId = crypto.randomUUID();
    
    // Log request
    logger.info(`Request started: ${req.method} ${req.nextUrl.pathname}`, {
      method: req.method,
      url: req.nextUrl.toString(),
      requestId,
      headers: Object.fromEntries(req.headers as unknown as Iterable<[string, string]>),
    });
    
    // Continue with the request
    const response = NextResponse.next();
    
    // Log response after it's sent
    const duration = Date.now() - start;
    logger.info(`Request completed: ${req.method} ${req.nextUrl.pathname}`, {
      method: req.method,
      url: req.nextUrl.toString(),
      requestId,
      statusCode: response.status,
      duration: `${duration}ms`,
    });
    
    return response;
  };
}