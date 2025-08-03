import { createHash } from 'crypto';
import type { NextRequest } from 'next/server';

interface RateLimitConfig {
  windowSize: number;
  maxAttempts: number;
}

interface RateLimitStore {
  [key: string]: {
    count: number;
    resetTime: number;
  };
}

interface RateLimitResult {
  blocked: boolean;
  remaining: number;
  reset: number;
  message?: string;
}

class RateLimiter {
  private static instance: RateLimiter;
  private store: RateLimitStore;
  private config: RateLimitConfig;

  private constructor(config: RateLimitConfig) {
    this.store = {};
    this.config = config;
  }

  public static getInstance(config: RateLimitConfig): RateLimiter {
    if (!RateLimiter.instance) {
      RateLimiter.instance = new RateLimiter(config);
    }
    return RateLimiter.instance;
  }

  public async checkLimit(request: NextRequest): Promise<RateLimitResult> {
    const ip = request.headers.get('x-forwarded-for')?.split(',')[0] ?? '127.0.0.1';
    const body = await request.json().catch(() => ({}));
    const account = body?.account as string ?? '';
    
    // Create a unique key based on IP and account
    const key = createHash('sha256')
      .update(ip + account)
      .digest('hex');

    const now = Date.now();
    const windowStart = now - this.config.windowSize;

    // Clean up old entries
    for (const k in this.store) {
      if (this.store[k].resetTime < windowStart) {
        delete this.store[k];
      }
    }

    // Get or create entry
    if (!this.store[key]) {
      this.store[key] = {
        count: 0,
        resetTime: now + this.config.windowSize,
      };
    }

    // If the window has expired, reset the counter
    if (this.store[key].resetTime < now) {
      this.store[key].count = 0;
      this.store[key].resetTime = now + this.config.windowSize;
    }

    this.store[key].count++;

    const remaining = this.config.maxAttempts - this.store[key].count;
    const reset = Math.ceil((this.store[key].resetTime - now) / 1000);

    if (this.store[key].count > this.config.maxAttempts) {
      return {
        blocked: true,
        remaining: 0,
        reset,
        message: `Too many requests. Please try again in ${Math.ceil(reset / 60)} minutes.`
      };
    }

    return {
      blocked: false,
      remaining,
      reset
    };
  }

  public reset(key: string): void {
    delete this.store[key];
  }
}

// Default configuration
const defaultConfig: RateLimitConfig = {
  windowSize: 15 * 60 * 1000, // 15 minutes
  maxAttempts: 5 // 5 attempts per window
};

export const rateLimiter = RateLimiter.getInstance(defaultConfig);

// Error class for rate limit exceeded
export class RateLimitExceededError extends Error {
  constructor(message = 'Rate limit exceeded') {
    super(message);
    this.name = 'RateLimitExceededError';
  }
}

// Middleware function to check rate limit
export const checkRateLimit = async (request: NextRequest): Promise<void> => {
  const result = await rateLimiter.checkLimit(request);
  if (result.blocked) {
    throw new RateLimitExceededError(result.message);
  }
}; 