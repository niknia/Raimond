import Cookies from 'js-cookie';
import { request } from './index';
import type { AuthResponse, VAxiosRequestConfig } from '../types';

export const getAccessToken = () => {
  return Cookies.get('accessToken');
};

export const getRefreshToken = () => {
  return Cookies.get('refreshToken');
};

export const setTokens = (accessToken: string, refreshToken: string) => {
  Cookies.set('accessToken', accessToken);
  Cookies.set('refreshToken', refreshToken);
};

export const clearTokens = () => {
  Cookies.remove('accessToken');
  Cookies.remove('refreshToken');
};

export const refreshAccessToken = async () => {
  const refreshToken = getRefreshToken();
  if (!refreshToken) throw new Error('No refresh token');

  const config: VAxiosRequestConfig = {
    url: '/auth/refresh',
    method: 'POST',
    data: { refreshToken }
  };
  const response = await request.post<AuthResponse>(config);
  if (!response.token || !response.refreshToken) {
    throw new Error('Invalid token response');
  }
  setTokens(response.token, response.refreshToken);
  return response.token;
}; 