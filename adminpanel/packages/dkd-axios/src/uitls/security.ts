import { twMerge } from "tailwind-merge";
import { verify } from "jsonwebtoken";
import crypto from "crypto";
import Cookies from 'js-cookie';

// CSRF Protection
export const csrf = {
  generateToken: (): string => {
    return crypto.randomBytes(32).toString('hex');
  },
  
  validateToken: (token: string, storedToken: string): boolean => {
    return token === storedToken;
  },
  
  getTokenFromHeader: (headers: Headers): string | null => {
    return headers.get('X-CSRF-Token');
  },

  setToken: (): void => {
    const token = crypto.randomBytes(32).toString('hex');
    Cookies.set('csrf_token', token, {
      secure: process.env.NODE_ENV === 'production',
      sameSite: 'strict',
      httpOnly: true,
      path: '/'
    });
  },

  getToken: (): string | undefined => {
    return Cookies.get('csrf_token');
  }
};

// Session Security
export const sessionSecurity = {
  generateSessionId: (): string => {
    return crypto.randomBytes(16).toString('hex');
  },
  
  validateSession: (sessionId: string, storedSessionId: string): boolean => {
    return sessionId === storedSessionId;
  },
  
  getSessionFromHeader: (headers: Headers): string | null => {
    return headers.get('X-Session-Id');
  },

  setSession: (sessionId: string): void => {
    Cookies.set('session_id', sessionId, {
      secure: process.env.NODE_ENV === 'production',
      sameSite: 'strict',
      httpOnly: true,
      path: '/'
    });
  },

  getSession: (): string | undefined => {
    return Cookies.get('session_id');
  }
};

// Cookie Security
export const cookieSecurity = {
  setSecureCookie: (name: string, value: string, options: {
    maxAge?: number;
    path?: string;
    domain?: string;
  } = {}): void => {
    Cookies.set(name, value, {
      secure: process.env.NODE_ENV === 'production',
      sameSite: 'strict',
      httpOnly: true,
      path: options.path || '/',
      ...(options.maxAge && { expires: new Date(Date.now() + options.maxAge) }),
      ...(options.domain && { domain: options.domain })
    });
  },

  removeCookie: (name: string, options: {
    path?: string;
    domain?: string;
  } = {}): void => {
    Cookies.remove(name, {
      path: options.path || '/',
      ...(options.domain && { domain: options.domain })
    });
  }
};

// Account Lockout
export const accountLockout = {
  MAX_ATTEMPTS: 5,
  LOCKOUT_DURATION: 30 * 60 * 1000, // 30 minutes
  ATTEMPTS_KEY_PREFIX: 'login_attempts_',
  LOCKOUT_KEY_PREFIX: 'account_locked_',

  recordFailedAttempt: (account: string): void => {
    const attemptsKey = accountLockout.ATTEMPTS_KEY_PREFIX + account;
    const attempts = Number.parseInt(localStorage.getItem(attemptsKey) || '0');
    
    if (attempts >= accountLockout.MAX_ATTEMPTS - 1) {
      accountLockout.private.lockAccount(account);
    } else {
      localStorage.setItem(attemptsKey, (attempts + 1).toString());
    }
  },

  resetAttempts: (account: string): void => {
    const attemptsKey = accountLockout.ATTEMPTS_KEY_PREFIX + account;
    localStorage.removeItem(attemptsKey);
    accountLockout.private.unlockAccount(account);
  },

  isAccountLocked: (account: string): boolean => {
    const lockoutKey = accountLockout.LOCKOUT_KEY_PREFIX + account;
    const lockoutTime = localStorage.getItem(lockoutKey);
    
    if (!lockoutTime) return false;
    
    const now = Date.now();
    const lockoutEnd = Number.parseInt(lockoutTime);
    
    if (now >= lockoutEnd) {
      accountLockout.private.unlockAccount(account);
      return false;
    }
    
    return true;
  },

  getLockoutTimeRemaining: (account: string): number => {
    const lockoutKey = accountLockout.LOCKOUT_KEY_PREFIX + account;
    const lockoutTime = localStorage.getItem(lockoutKey);
    
    if (!lockoutTime) return 0;
    
    const now = Date.now();
    const lockoutEnd = Number.parseInt(lockoutTime);
    const remaining = lockoutEnd - now;
    
    return remaining > 0 ? remaining : 0;
  },

  private: {
    lockAccount: (account: string): void => {
      const lockoutKey = accountLockout.LOCKOUT_KEY_PREFIX + account;
      const lockoutEnd = Date.now() + accountLockout.LOCKOUT_DURATION;
      localStorage.setItem(lockoutKey, lockoutEnd.toString());
    },

    unlockAccount: (account: string): void => {
      const lockoutKey = accountLockout.LOCKOUT_KEY_PREFIX + account;
      localStorage.removeItem(lockoutKey);
    }
  }
};

// Secure storage utilities
export const secureStorage = {
  setItem: (key: string, value: any) => {
    try {
      const stringValue = typeof value === 'object' ? JSON.stringify(value) : String(value);
      localStorage.setItem(key, stringValue);
    } catch (error) {
      console.error('Error storing data:', error);
    }
  },
  
  getItem: (key: string) => {
    try {
      const value = localStorage.getItem(key);
      return value ? JSON.parse(value) : null;
    } catch (error) {
      console.error('Error retrieving data:', error);
      return null;
    }
  },
  
  removeItem: (key: string) => {
    try {
      localStorage.removeItem(key);
    } catch (error) {
      console.error('Error removing data:', error);
    }
  }
};

// XSS prevention
export const sanitizeHTML = (str: string): string => {
  const div = document.createElement('div');
  div.textContent = str;
  return div.innerHTML;
};

// Password strength checker
export const checkPasswordStrength = (password: string): {
  score: number;
  feedback: string;
} => {
  let score = 0;
  const feedback: string[] = [];

  if (password.length >= 8) score++;
  if (password.match(/[a-z]/) && password.match(/[A-Z]/)) score++;
  if (password.match(/\d/)) score++;
  if (password.match(/[^a-zA-Z\d]/)) score++;
  if (password.length >= 12) score++;

  if (score < 2) feedback.push("رمز عبور ضعیف است");
  else if (score < 4) feedback.push("رمز عبور متوسط است");
  else feedback.push("رمز عبور قوی است");

  return {
    score,
    feedback: feedback.join(". ")
  };
};

// Email validator
export const isValidEmail = (email: string): boolean => {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailRegex.test(email);
};

// Generate random string for CSRF tokens etc.
export const generateRandomString = (length: number): string => {
  const charset = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
  let result = '';
  const randomValues = new Uint32Array(length);
  crypto.getRandomValues(randomValues);
  for (let i = 0; i < length; i++) {
    result += charset[randomValues[i] % charset.length];
  }
  return result;
};

// Token validation
export function validateToken(token: string | null): boolean {
  if (!token) return false;
  
  try {
    verify(token, process.env.JWT_SECRET || "your-secret-key");
    return true;
  } catch {
    return false;
  }
}

// Security headers for Next.js API routes
export const securityHeaders = {
  'X-Content-Type-Options': 'nosniff',
  'X-Frame-Options': 'DENY',
  'X-XSS-Protection': '1; mode=block',
  'Referrer-Policy': 'strict-origin-when-cross-origin',
  'Permissions-Policy': 'geolocation=(), microphone=(), camera=()',
  'Strict-Transport-Security': 'max-age=31536000; includeSubDomains',
  'Content-Security-Policy': [
    "default-src 'self'",
    "script-src 'self' 'unsafe-inline' 'unsafe-eval'",
    "style-src 'self' 'unsafe-inline'",
    "img-src 'self' data: blob:",
    "font-src 'self'",
    "connect-src 'self' http://87.107.165.236:60080",
    "frame-src 'self'",
    "object-src 'none'",
    "base-uri 'self'",
    "form-action 'self'",
    "frame-ancestors 'self'",
    "upgrade-insecure-requests",
  ].join('; ')
}; 