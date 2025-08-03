
import { FarsiFont } from './types';

// Collection of Persian fonts
export const Vazirmatn: FarsiFont = {
  name: 'Vazirmatn',
  family: 'Vazirmatn',
  weights: [100, 200, 300, 400, 500, 600, 700, 800, 900],
  styles: ['normal'],
  fallback: 'sans-serif',
  className: 'font-vazirmatn',
  variableName: '--font-vazirmatn',
  fontFiles: {
    100: 'Vazirmatn-Thin',
    200: 'Vazirmatn-ExtraLight',
    300: 'Vazirmatn-Light',
    400: 'Vazirmatn-Regular',
    500: 'Vazirmatn-Medium',
    600: 'Vazirmatn-SemiBold',
    700: 'Vazirmatn-Bold',
    800: 'Vazirmatn-ExtraBold',
    900: 'Vazirmatn-Black'
  }
};

export const Sahel: FarsiFont = {
  name: 'Sahel',
  family: 'Sahel',
  weights: [300, 400, 500, 600, 900],
  styles: ['normal'],
  fallback: 'sans-serif',
  className: 'font-sahel',
  variableName: '--font-sahel',
  fontFiles: {
    300: 'Sahel-Light',
    400: 'Sahel',
    500: 'Sahel-Medium',
    600: 'Sahel-SemiBold',
    900: 'Sahel-Black'
  }
};

export const Samim: FarsiFont = {
  name: 'Samim',
  family: 'Samim',
  weights: [400, 500, 700],
  styles: ['normal'],
  fallback: 'sans-serif',
  className: 'font-samim',
  variableName: '--font-samim',
  fontFiles: {
    400: 'Samim',
    500: 'Samim-Medium',
    700: 'Samim-Bold'
  }
};

export const IRANSansX: FarsiFont = {
  name: 'IRANSansX',
  family: 'IRANSansX',
  weights: [100, 200, 300, 400, 500, 600, 700, 800, 900],
  styles: ['normal'],
  fallback: 'sans-serif',
  className: 'font-iransansx',
  variableName: '--font-iransansx',
  fontFiles: {
    100: 'IRANSansXFaNum-Thin',
    200: 'IRANSansXFaNum-UltraLight',
    300: 'IRANSansXFaNum-Light',
    400: 'IRANSansXFaNum-Regular',
    500: 'IRANSansXFaNum-Medium',
    600: 'IRANSansXFaNum-DemiBold',
    700: 'IRANSansXFaNum-Bold',
    800: 'IRANSansXFaNum-ExtraBold',
    900: 'IRANSansXFaNum-Black',
  }
};

// Export all available fonts
export const FARSI_FONTS = {
  Vazirmatn,
  Sahel,
  Samim,
  IRANSansX,
};

// Export default font
export const DEFAULT_FONT = Vazirmatn;
