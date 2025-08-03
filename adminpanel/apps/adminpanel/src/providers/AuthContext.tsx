"use client";

import React, { createContext, useContext, useState, useCallback, useEffect } from 'react';
import type { ReactNode } from 'react';
import Cookies from 'js-cookie';

interface AuthContextType {
  isAuthenticated: boolean;
  isLoading: boolean;
  user: any;
  login: (credentials: LoginCredentials) => Promise<void>;
  logout: () => Promise<void>;
}

interface LoginCredentials {
  account: string;
  password: string;
}

interface AuthProviderProps {
  children: ReactNode;
}

const AuthContext = createContext<AuthContextType | null>(null);

export function AuthProvider({ children }: AuthProviderProps) {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [user, setUser] = useState<any>(null);
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
    console.log('jsonPayload', jsonPayload);
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
    //Cookies.remove('accessToken');
    //Cookies.remove('refreshToken');
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
      console.log('accessToken:', token);
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
    setIsLoading(true);
    console.log('AUTH CONTEXT: Attempting login with credentials:', credentials);
    try {
      const res = await fetch('/api/auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(credentials),
        credentials: 'include',
      });
      console.log('AUTH CONTEXT: Login API response status:', res.status);
      if (!res.ok) {
        const data = await res.json();
        console.log('AUTH CONTEXT: Login failed, error:', data.error);
        throw new Error(data.error || 'Login failed');
      }
      // پس از لاگین موفق، توکن را از کوکی بخوان و وضعیت را به‌روزرسانی کن
      const token = Cookies.get('accessToken');
      if (token) {
        updateAuthState(token);
      }
    } catch (error) {
      setIsAuthenticated(false);
      console.log('AUTH CONTEXT: Login error:', error);
      throw error;
    } finally {
      setIsLoading(false);
    }
  }, [updateAuthState]);

  const logout = useCallback(async () => {
    console.log('AUTH CONTEXT: Logging out...');
    try {
      await fetch('/api/auth/logout', {
        method: 'POST',
        credentials: 'include',
      });
      console.log('AUTH CONTEXT: Logout API called');
    } finally {
      setUser(null);
      setIsAuthenticated(false);
      console.log('AUTH CONTEXT: User set to null, isAuthenticated set to false');
    }
  }, []);

  return (
    <AuthContext.Provider
      value={{
        isAuthenticated,
        isLoading,
        user,
        login,
        logout,
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