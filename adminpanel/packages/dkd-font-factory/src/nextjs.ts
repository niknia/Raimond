import { FarsiFont, FontConfig, FontLoaderOptions } from './types';
import { DEFAULT_FONT, FARSI_FONTS } from './fonts';

/**
 * Get font configuration for Next.js
 * 
 * @param fontConfig Font configuration or font name
 * @returns Font configuration object
 */
export function getFontConfig(fontConfig: FontConfig | string): {
  fontFamily: string;
  fontStyle: string;
  fontWeight: string;
  src: string;
} {
  const defaultOptions = {
    subsets: ['arabic'],
    display: 'swap' as const,
    weight: ['400', '700'],
    variable: false,
  };

  let fontName = typeof fontConfig === 'string' ? fontConfig : fontConfig.name;
  const options = typeof fontConfig === 'object' ? { ...defaultOptions, ...fontConfig.options } : defaultOptions;

  // Get font from available fonts
  const font = (FARSI_FONTS as Record<string, FarsiFont>)[fontName] || DEFAULT_FONT;

  // Generate font config
  return {
    fontFamily: font.family,
    fontStyle: 'normal',
    fontWeight: typeof options.weight === 'string' 
      ? options.weight 
      : options.weight.join(' '),
    src: `url(./assets/fonts/${font.fontFiles?.[400] || font.name}.woff2) format('woff2')`,
  };
}

/**
 * Add font to Next.js application
 * 
 * @example
 * ```ts
 * // app/layout.tsx
 * import { Vazirmatn, addFarsiFontToNext } from 'farsi-font-factory';
 * 
 * const vazirmatnFont = addFarsiFontToNext(Vazirmatn);
 * 
 * export default function RootLayout({ children }) {
 *  return (
 *    <html lang="fa" dir="rtl" className={vazirmatnFont.className}>
 *      <body>{children}</body>
 *    </html>
 *  );
 * }
 * ```
 */
export function addFarsiFontToNext(font: FarsiFont | string, options?: FontLoaderOptions) {
  const fontToUse = typeof font === 'string' 
    ? (FARSI_FONTS as Record<string, FarsiFont>)[font] || DEFAULT_FONT
    : font;
  
  // Return object with font class name for easier integration
  return {
    className: fontToUse.className,
    variable: fontToUse.variableName,
    fontFamily: fontToUse.family,
    style: { fontFamily: `${fontToUse.family}, ${fontToUse.fallback}` }
  };
}

/**
 * Generate Tailwind configuration for Persian fonts
 * 
 * @example
 * ```ts
 * // tailwind.config.js
 * const { getTailwindFontConfig } = require('farsi-font-factory');
 * 
 * module.exports = {
 *   theme: {
 *     extend: {
 *       fontFamily: getTailwindFontConfig(['Vazirmatn', 'IRANSansX']),
 *     },
 *   },
 * };
 * ```
 */
export function getTailwindFontConfig(fonts: (FarsiFont | string)[]) {
  const config: Record<string, string[]> = {};
  
  fonts.forEach((fontItem) => {
    const font = typeof fontItem === 'string' 
      ? (FARSI_FONTS as Record<string, FarsiFont>)[fontItem] || DEFAULT_FONT
      : fontItem;
    
    // Remove 'font-' prefix from class name for tailwind
    const key = font.className.replace('font-', '');
    config[key] = [font.family, font.fallback];
  });
  
  return config;
}

/**
 * Generate Tailwind v4 configuration for Persian fonts
 * Uses CSS variables for better compatibility with Tailwind v4
 * 
 * @example
 * ```ts
 * // tailwind.config.js
 * const { getTailwindV4FontConfig } = require('farsi-font-factory');
 * 
 * module.exports = {
 *   theme: {
 *     extend: {
 *       fontFamily: getTailwindV4FontConfig(['Vazirmatn', 'IRANSansX']),
 *     },
 *   },
 * };
 * ```
 */
export function getTailwindV4FontConfig(fonts: (FarsiFont | string)[] = Object.keys(FARSI_FONTS)) {
  const config: Record<string, string> = {};
  
  fonts.forEach((fontItem) => {
    const font = typeof fontItem === 'string' 
      ? (FARSI_FONTS as Record<string, FarsiFont>)[fontItem] || DEFAULT_FONT
      : fontItem;
    
    // Remove 'font-' prefix from class name for tailwind
    const key = font.className.replace('font-', '');
    // Use CSS variable format for Tailwind v4
    config[key] = `var(${font.variableName})`;
  });
  
  return config;
}

/**
 * Get Tailwind font configuration with proper TypeScript types
 * Supports both individual font configurations and combined sans/mono setup
 * Also handles font loading and downloading
 * 
 * @param fonts Array of font names or FarsiFont objects
 * @param options Configuration options
 * @returns Tailwind font configuration object
 */
export function getTailwindFontConfigV2(
  fonts: (FarsiFont | string)[],
  options: { 
    mode?: 'combined' | 'individual';
    includeSystemFonts?: boolean;
    downloadFonts?: boolean;
  } = { mode: 'combined', includeSystemFonts: true, downloadFonts: true }
): Record<string, string[]> {
  const config: Record<string, string[]> = {};
  
  // Process each font
  for (const fontItem of fonts) {
    const font = typeof fontItem === 'string' 
      ? (FARSI_FONTS as Record<string, FarsiFont>)[fontItem] || DEFAULT_FONT
      : fontItem;
    
    if (options.mode === 'individual') {
      // Individual font configuration
      const key = font.className.replace('font-', '');
      config[key] = [font.family, font.fallback];
    }

    // Handle font loading and downloading
    if (options.downloadFonts && font.fontFiles) {
      // Create font face declarations
      const fontFaces = Object.entries(font.fontFiles).map(([weight, filename]) => {
        return `
          @font-face {
            font-family: '${font.family}';
            font-style: normal;
            font-weight: ${weight};
            font-display: swap;
            src: url('/fonts/${filename}.woff2') format('woff2');
          }
        `;
      }).join('\n');

      // Add font faces to document
      if (typeof document !== 'undefined') {
        const style = document.createElement('style');
        style.textContent = fontFaces;
        document.head.appendChild(style);
      }
    }
  }

  if (options.mode === 'combined') {
    // Combined configuration with system fonts
    const fontFamilies = fonts.map(font => {
      if (typeof font === 'string') {
        const farsiFont = (FARSI_FONTS as Record<string, FarsiFont>)[font] || DEFAULT_FONT;
        return farsiFont.family;
      }
      return font.family;
    });

    config.sans = options.includeSystemFonts 
      ? [...fontFamilies, 'system-ui', 'sans-serif']
      : fontFamilies;
    
    config.mono = ['Roboto Mono', 'monospace'];
  }

  return config;
}
