import { type ClassValue, clsx } from "clsx"
import { twMerge } from "tailwind-merge"

/**
 * Utility function to combine tailwind classes with proper precedence
 */
export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs));
}

/**
 * Check if the current document direction is RTL
 */
export function isRTL(): boolean {
  if (typeof document === 'undefined') return false;
  return document.dir === 'rtl' || document.documentElement.dir === 'rtl';
}

/**
 * Get current document direction
 */
export function getDirection(): 'ltr' | 'rtl' {
  return isRTL() ? 'rtl' : 'ltr';
} 