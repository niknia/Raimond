import { format } from 'date-fns/format';
import { isValid } from 'date-fns/isValid';
import { parseISO } from 'date-fns/parseISO';
import isString from 'lodash/isString';
import isObject from 'lodash/isObject';
import type { UriExtension } from '../types';

const DATE_TIME_FORMAT = 'yyyy-MM-dd HH:mm:ss';

interface TimestampConfig {
  _t: number;
}

/**
 * Creates a new UriString instance
 * @param value The URI string value
 * @returns A new UriString instance
 */
export function createUriString(value: string): UriString {
  return new UriString(value);
}

/**
 * Adds timestamp to request parameters
 * @param join Whether to add timestamp
 * @param restful Whether to return as restful format
 */
export function joinTimestamp(join: boolean, restful = false): string | TimestampConfig {
  if (!join) {
    return restful ? '' : { _t: 0 };
  }
  const now = new Date().getTime();
  if (restful) {
    return `?_t=${now}`;
  }
  return { _t: now };
}

interface RequestData {
  [key: string]: any;
}

/**
 * Formats date objects in request parameters
 * @param params Request parameters
 */
export function formatRequestDate(params: RequestData): void {
  if (!isObject(params)) {
    return;
  }

  Object.entries(params).forEach(([key, value]) => {
    if (value instanceof Date && isValid(value)) {
      params[key] = format(value, DATE_TIME_FORMAT);
    } else if (typeof value === 'string') {
      try {
        const parsedDate = parseISO(value);
        if (isValid(parsedDate)) {
          params[key] = format(parsedDate, DATE_TIME_FORMAT);
        } else {
          params[key] = value.trim();
        }
      } catch {
        params[key] = value.trim();
      }
    } else if (isObject(value)) {
      formatRequestDate(value as RequestData);
    }
  });
}

/**
 * Converts object to URL parameters
 * @param baseUrl Base URL
 * @param obj Object to convert
 */
export function setObjToUrlParams(baseUrl: string, obj: Record<string, any>): string {
  const parameters = Object.entries(obj)
    .map(([key, value]) => `${key}=${encodeURIComponent(value)}`)
    .join('&');

  return baseUrl.includes('?') 
    ? `${baseUrl}${parameters}`
    : `${baseUrl.replace(/\/?$/, '?')}${parameters}`;
}

/**
 * Convert object to query string
 * @param obj object
 * @returns
 */
export function toQueryFormat(obj: any): string {
  const keyValuePairs = [];
  for (const key in obj) {
    if (Object.prototype.hasOwnProperty.call(obj, key)) {
      const value = obj[key];
      if (Array.isArray(value)) {
        for (const subValue of value) {
          keyValuePairs.push(`${key}=${encodeURIComponent(subValue)}`);
        }
      } else {
        keyValuePairs.push(`${key}=${encodeURIComponent(value)}`);
      }
    }
  }
  return `?${keyValuePairs.join('&')}`;
}

export class UriString {
  private value: string;

  constructor(value: string) {
    this.value = value;
  }

  toUriFormat(): UriExtension {
    const segments = this.value.split('-');
    const uriType = segments.shift() || '';
    const value = segments.join('/').replace(/-/g, '/');
    return {
      _uriType: uriType,
      value,
      toString() {
        return this.value;
      },
    };
  }
  
  toPath(): string {
    return this.value.replace(/-/g, '/');
  }


  toString(): string {
    return this.value;
  }
}