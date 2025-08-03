"use client";

import React, { createContext, useContext, useState, useCallback, useEffect } from 'react';
import type { ReactNode } from 'react';
import { request } from '../lib';
import Cookies from 'js-cookie';
import type { AuthResponse, VAxiosRequestConfig } from '../types';
import type { AxiosError } from 'axios';
import { csrf } from '../uitls/security';
import { axiosConfig } from '../lib/config';

interface AuthContextType {
  isAuthenticated: boolean;
  isLoading: boolean;
  user: AuthResponse['user'] | null;
  login: (credentials: LoginCredentials) => Promise<void>;
  logout: () => Promise<void>;
  refreshToken: () => Promise<void>;
}

interface LoginCredentials {
  account: string;
  password: string;
}

interface Result<T> {
  version: string;
  statusCode: number;
  message: string;
  result: T;
}

interface AuthProviderProps {
  children: ReactNode;
}

const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: AuthProviderProps) {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [isLoading, setIsLoading] = useState(true);
  const [user, setUser] = useState<AuthResponse['user'] | null>(null);
  const [isInitialized, setIsInitialized] = useState(false);

  const updateAuthState = useCallback((token: string) => {
    try {
      const base64Url = token.split('.')[1];
      const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      const jsonPayload = decodeURIComponent(
        atob(base64)
          .split('')
          .map(c => `%${`00${c.charCodeAt(0).toString(16)}`.slice(-2)}`)
          .join('')
      );
      
      const tokenData = JSON.parse(jsonPayload);
      const user = {
        id: tokenData.nameid,
        username: tokenData.unique_name,
        name: tokenData.name,
        roleIds: tokenData.roleids,
        loginType: tokenData.loginer
      };
      setUser(user);
      setIsAuthenticated(true);
      return true;
    } catch (error) {
      Cookies.remove('accessToken');
      Cookies.remove('refreshToken');
      setUser(null);
      setIsAuthenticated(false);
      return false;
    }
  }, []);

  // Check initial auth state
  useEffect(() => {
    const checkAuth = async () => {
      try {
        const token = Cookies.get('accessToken');
        if (token) {
          const success = updateAuthState(token);
        } else {
        }
      } catch (error) {
        Cookies.remove('accessToken');
        Cookies.remove('refreshToken');
        setUser(null);
        setIsAuthenticated(false);
      } finally {
        setIsLoading(false);
        setIsInitialized(true);
      }
    };

    checkAuth();
  }, [updateAuthState]);

  const login = useCallback(async (credentials: LoginCredentials) => {
    if (!isInitialized) return;
    
    try {
      setIsLoading(true);
      
      const { baseUrl } = axiosConfig.getConfig();
      
      if (!baseUrl) {
        throw new Error('API endpoint is not configured. Please set baseUrl in axiosConfig.');
      }

      // Generate and set CSRF token
      csrf.setToken();
      const csrfToken = csrf.getToken();

      const config: VAxiosRequestConfig = {
        baseURL: baseUrl,
        url: 'auth/api/session',
        method: 'POST',
        data: credentials,
        headers: {
          'Content-Type': 'application/json',
          'accept': 'text/plain',
          'X-CSRF-Token': csrfToken || ''
        }
      };
      
      
      try {
        const response = await request.post<Result<AuthResponse>>(config);
        
        if (!response || !response.statusCode || response.statusCode !== 201 || !response.result) {
          throw new Error(response?.message || 'Login failed');
        }

        const { token, refreshToken, expire, refreshExpire } = response.result;
        
        if (!token) {
          throw new Error('No token received');
        }
        
        // Store tokens with proper options
        Cookies.set('accessToken', token, {
          secure: process.env.NODE_ENV === 'production',
          sameSite: 'strict',
          path: '/',
          ...(expire && { expires: new Date(expire) })
        });

        if (refreshToken) {
          Cookies.set('refreshToken', refreshToken, {
            secure: process.env.NODE_ENV === 'production',
            sameSite: 'strict',
            path: '/',
            ...(refreshExpire && { expires: new Date(refreshExpire) })
          });
        }
        
        // Update auth state
        const success = updateAuthState(token);
        if (!success) {
          throw new Error('Failed to update auth state');
        }
        

      } catch (requestError) {

        if (requestError && typeof requestError === 'object' && 'response' in requestError) {
          const axiosError = requestError as AxiosError;
          console.error('Error response:', axiosError.response?.data);
          console.error('Error status:', axiosError.response?.status);
          const errorMessage = typeof axiosError.response?.data === 'object' && axiosError.response?.data 
            ? (axiosError.response.data as { message?: string }).message 
            : 'Login request failed';
          throw new Error(errorMessage);
        }
        throw requestError;
      }
    } catch (error) {
      console.error('Login error:', error);
      if (error instanceof Error) {
        throw new Error(`Login failed: ${error.message}`);
      }
      throw new Error('Login failed: Unknown error');
    } finally {
      setIsLoading(false);
    }
  }, [isInitialized, updateAuthState]);

  const logout = useCallback(async () => {
    try {
      const { baseUrl } = axiosConfig.getConfig();
      const config: VAxiosRequestConfig = {
        baseURL: baseUrl,
        url: 'auth/api/session',
        method: 'DELETE'
      };
      await request.delete(config);
    } finally {
      Cookies.remove('accessToken');
      Cookies.remove('refreshToken');
      setUser(null);
      setIsAuthenticated(false);
    }
  }, []);

  const refreshToken = useCallback(async () => {
    try {
      const accessToken = Cookies.get('accessToken');
      if (!accessToken) throw new Error('No access token');

      const { baseUrl } = axiosConfig.getConfig();
      const config: VAxiosRequestConfig = {
        baseURL: baseUrl,
        url: 'auth/api/session/refresh',
        method: 'POST',
        headers: {
          'Authorization': `Bearer ${accessToken}`,
          'Content-Type': 'application/json',
          'accept': 'text/plain'
        }
      };
      const response = await request.post<Result<AuthResponse>>(config);
      
      if (response.statusCode !== 201) {
        throw new Error(response.message || 'Token refresh failed');
      }

      const { token, refreshToken, expire, refreshExpire } = response.result;
      Cookies.set('accessToken', token, {
        secure: process.env.NODE_ENV === 'production',
        sameSite: 'strict',
        path: '/',
        ...(expire && { expires: new Date(expire) })
      });

      if (refreshToken) {
        Cookies.set('refreshToken', refreshToken, {
          secure: process.env.NODE_ENV === 'production',
          sameSite: 'strict',
          path: '/',
          ...(refreshExpire && { expires: new Date(refreshExpire) })
        });
      }
    } catch (error) {
      logout();
      throw error;
    }
  }, [logout]);

  return (
    <AuthContext.Provider
      value={{
        isAuthenticated,
        isLoading,
        user,
        login,
        logout,
        refreshToken,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider');
  }
  return context;
}; 