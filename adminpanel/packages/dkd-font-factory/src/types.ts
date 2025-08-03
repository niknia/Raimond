
export interface FontOptions {
  subsets?: string[];
  display?: 'auto' | 'block' | 'swap' | 'fallback' | 'optional';
  weight?: string | string[];
  variable?: boolean;
}

export type FarsiFont = {
  name: string;
  family: string;
  weights: number[];
  styles: ('normal' | 'italic')[];
  fallback: string;
  className: string;
  variableName: string;
  fontFiles?: Record<number, string>; // Maps weight to filename
};

export type FontConfig = {
  name: string;
  options?: FontOptions;
};

export interface FontLoaderOptions {
  adjustFontFallback?: boolean;
  injectToRoot?: boolean;
}
