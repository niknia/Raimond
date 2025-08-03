import { FarsiFont } from './types';
import { FARSI_FONTS } from './fonts';

/**
 * Generate CSS @font-face rules for specified fonts
 */
export function generateFontFaces(fonts: (FarsiFont | string)[]): string {
  return fonts.map(fontItem => {
    const font = typeof fontItem === 'string' 
      ? (FARSI_FONTS as Record<string, FarsiFont>)[fontItem] || null
      : fontItem;
    
    if (!font) return '';
    
    return font.weights.map(weight => {
      // Get font file path for the specified weight
      const fontPath = `./assets/fonts/${font.name.toLowerCase()}/${font.name}`;
      let fontFileName = font.fontFiles?.[weight];
      
      if (!fontFileName) {
        // Use standardized weight naming
        switch(weight) {
          case 100: fontFileName = `${fontPath}-Thin`; break;
          case 200: fontFileName = `${fontPath}-ExtraLight`; break;
          case 300: fontFileName = `${fontPath}-Light`; break;
          case 400: fontFileName = `${fontPath}-Regular`; break;
          case 500: fontFileName = `${fontPath}-Medium`; break;
          case 600: fontFileName = `${fontPath}-SemiBold`; break;
          case 700: fontFileName = `${fontPath}-Bold`; break;
          case 800: fontFileName = `${fontPath}-ExtraBold`; break;
          case 900: fontFileName = `${fontPath}-Black`; break;
          default: fontFileName = `${fontPath}-Regular`;
        }
      }

      return `@font-face {
  font-family: '${font.family}';
  font-style: normal;
  font-weight: ${weight};
  font-display: swap;
  src: url('${fontFileName}.woff2') format('woff2');
  unicode-range: U+0600-06FF, U+200C-200E, U+2010-2011, U+FB50-FDFF, U+FE80-FEFC;
}`;
    }).join('\n\n');
  }).join('\n\n');
}

/**
 * Generate CSS for font utility classes
 */
export function generateFontClasses(fonts: (FarsiFont | string)[]): string {
  return fonts.map(fontItem => {
    const font = typeof fontItem === 'string' 
      ? (FARSI_FONTS as Record<string, FarsiFont>)[fontItem] || null
      : fontItem;
    
    if (!font) return '';
    
    // Generate utility class with font family and fallback
    return `.${font.className} {
  font-family: '${font.family}', ${font.fallback};
}`;
  }).join('\n\n');
}

/**
 * Generate a complete CSS file with all fonts
 */
export function generateFontCss(fonts: (FarsiFont | string)[] = Object.keys(FARSI_FONTS)): string {
  const fontFaces = generateFontFaces(fonts);
  const fontClasses = generateFontClasses(fonts);
  
  return `/**
 * farsi-font-factory
 * Generated font styles
 */

/* Font faces */
${fontFaces}

/* Font utility classes */
${fontClasses}

/* RTL base settings */
[dir="rtl"] {
  text-align: right;
}

html[dir="rtl"] body {
  font-family: 'Vazirmatn', sans-serif;
}
`;
}

/**
 * Generate CSS for Tailwind v4 config
 */
export function generateTailwindConfig(fonts: (FarsiFont | string)[] = Object.keys(FARSI_FONTS)): Record<string, string> {
  const fontConfig: Record<string, string> = {};
  
  fonts.forEach(fontItem => {
    const font = typeof fontItem === 'string' 
      ? (FARSI_FONTS as Record<string, FarsiFont>)[fontItem] || null
      : fontItem;
    
    if (!font) return;
    
    const variableName = font.variableName.startsWith('--') 
      ? font.variableName.substring(2) 
      : font.variableName;
    
    fontConfig[font.className.replace('font-', '')] = `var(--${variableName})`;
  });
  
  return fontConfig;
}