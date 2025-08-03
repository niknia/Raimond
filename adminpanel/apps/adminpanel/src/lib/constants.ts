// src/constants.ts
export const BASE_URL = 
  process.env.NODE_ENV === 'production'
    ? process.env.NEXT_PUBLIC_BASE_URL_PROD
    : process.env.NEXT_PUBLIC_BASE_URL_DEV;

export const API_URL = 
  process.env.NODE_ENV === 'production'
    ? process.env.NEXT_PUBLIC_API_URL_PROD
    : process.env.NEXT_PUBLIC_API_URL_DEV;

export const AUTH_ROUTES = {
  LOGIN: '/login',
  REGISTER: '/register',
  FORGOT_PASSWORD: '/forgot-password',
  CALLBACK: '/auth/callback',
};

export const COOKIE_OPTIONS = {
  secure: process.env.NODE_ENV === 'production',
  sameSite: 'lax' as const,
  path: '/',
  domain: process.env.NODE_ENV === 'production' ? BASE_URL : undefined,
  maxAge: 60 * 60 * 24 * 7, // 1 week
};