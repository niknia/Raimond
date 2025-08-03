// src/utils/endpointBuilder.ts
import { UriString } from '@dkd-axios';
import { IEndpointConfig } from '../types/base';

export const buildResourceEndpoints = <T>(
  resourceName: string | UriString
): IEndpointConfig<T> => {
  const basePath = typeof resourceName === 'string' 
    ? new UriString(resourceName).toPath()
    : resourceName.toPath();
    console.log("return Base From1",basePath);
  return {
    getAll: `${basePath}/list`,
    getById: (id: string | number) => `${basePath}/${id}`,
    create: basePath,
    update: (id: string | number) => `${basePath}/${id}`,
    delete: (id: string | number) => `${basePath}/${id}`,
    getPaginated: (params: string) => `${basePath}/page?${params}`,
  };
};

export const buildCustomEndpoint = (
  endpointName: string | UriString,
  suffix?: string
): string => {
  const basePath = typeof endpointName === 'string' 
    ? new UriString(endpointName).toPath()
    : endpointName.toPath();
  console.log("return Base From",basePath);
  return suffix ? `${basePath}/${suffix}` : basePath;
};