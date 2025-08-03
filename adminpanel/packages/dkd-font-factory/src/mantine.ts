
import { FarsiFont } from './types';
import { DEFAULT_FONT, FARSI_FONTS } from './fonts';

/**
 * Get font configuration for Mantine UI
 * 
 * @param font Font configuration or font name
 * @returns Font configuration object for Mantine UI createTheme
 */
export function getMantineFont(font: FarsiFont | string) {
  const fontToUse = typeof font === 'string' 
    ? (FARSI_FONTS as Record<string, FarsiFont>)[font] || DEFAULT_FONT
    : font;
  
  return {
    fontFamily: `${fontToUse.family}, ${fontToUse.fallback}`,
  };
}

/**
 * Generate Mantine theme configuration for Persian fonts
 * 
 * @example
 * ```ts
 * import { createTheme } from '@mantine/core';
 * import { getMantineTheme } from 'farsi-font-factory';
 * 
 * const theme = createTheme({
 *   ...getMantineTheme('Vazirmatn'),
 *   // other theme options
 * });
 * ```
 */
export function getMantineTheme(font: FarsiFont | string = DEFAULT_FONT) {
  const fontToUse = typeof font === 'string' 
    ? (FARSI_FONTS as Record<string, FarsiFont>)[font] || DEFAULT_FONT
    : font;
  
  return {
    fontFamily: `${fontToUse.family}, ${fontToUse.fallback}`,
    dir: 'rtl',
    headings: {
      fontFamily: `${fontToUse.family}, ${fontToUse.fallback}`,
    },
  };
}

/**
 * Create a theme object with RTL support for multiple fonts
 * 
 * @example
 * ```tsx
 * // _app.tsx or equivalent
 * import { MantineProvider } from '@mantine/core';
 * import { createFarsiMantineTheme, Vazirmatn, IRANSansX } from 'farsi-font-factory';
 * import 'farsi-font-factory/styles.css';
 * 
 * const theme = createFarsiMantineTheme({
 *   primaryFont: Vazirmatn,
 *   headingFont: IRANSansX,
 *   // other theme options
 * });
 * 
 * export default function App({ Component, pageProps }) {
 *   return (
 *     <MantineProvider theme={theme}>
 *       <Component {...pageProps} />
 *     </MantineProvider>
 *   );
 * }
 * ```
 */
export function createFarsiMantineTheme(options: {
  primaryFont?: FarsiFont | string;
  headingFont?: FarsiFont | string;
  rtl?: boolean;
  [key: string]: any;
}) {
  const { 
    primaryFont = DEFAULT_FONT, 
    headingFont = primaryFont, 
    rtl = true, 
    ...rest 
  } = options;
  
  const primaryFontObj = typeof primaryFont === 'string' 
    ? (FARSI_FONTS as Record<string, FarsiFont>)[primaryFont] || DEFAULT_FONT
    : primaryFont;
  
  const headingFontObj = typeof headingFont === 'string' 
    ? (FARSI_FONTS as Record<string, FarsiFont>)[headingFont] || primaryFontObj
    : headingFont;
  
  return {
    fontFamily: `${primaryFontObj.family}, ${primaryFontObj.fallback}`,
    dir: rtl ? 'rtl' : 'ltr',
    headings: {
      fontFamily: `${headingFontObj.family}, ${headingFontObj.fallback}`,
    },
    components: {
      Text: {
        defaultProps: {
          ff: `${primaryFontObj.family}, ${primaryFontObj.fallback}`,
        },
      },
      Button: {
        defaultProps: {
          ff: `${primaryFontObj.family}, ${primaryFontObj.fallback}`,
        },
      },
      Input: {
        defaultProps: {
          ff: `${primaryFontObj.family}, ${primaryFontObj.fallback}`,
        },
      },
    },
    ...rest,
  };
}

/**
 * Generates Mantine UI 7 specific theme options for Persian fonts
 * Compatible with Mantine 7's createTheme function
 * 
 * @example
 * ```ts
 * import { createTheme } from '@mantine/core';
 * import { mantineV7Theme, IRANSansX } from 'farsi-font-factory';
 * 
 * const theme = createTheme({
 *   ...mantineV7Theme(IRANSansX),
 *   // other theme options
 * });
 * ```
 */
export function mantineV7Theme(font: FarsiFont | string = DEFAULT_FONT) {
  const fontToUse = typeof font === 'string' 
    ? (FARSI_FONTS as Record<string, FarsiFont>)[font] || DEFAULT_FONT
    : font;
    
  return {
    fontFamily: `${fontToUse.family}, ${fontToUse.fallback}`,
    dir: 'rtl',
    headings: {
      fontFamily: `${fontToUse.family}, ${fontToUse.fallback}`,
    },
    components: {
      Text: {
        defaultProps: {
          ff: `${fontToUse.family}, ${fontToUse.fallback}`,
        },
      },
      Button: {
        defaultProps: {
          ff: `${fontToUse.family}, ${fontToUse.fallback}`,
        },
      },
      Input: {
        defaultProps: {
          ff: `${fontToUse.family}, ${fontToUse.fallback}`,
        },
      },
    },
  };
}
