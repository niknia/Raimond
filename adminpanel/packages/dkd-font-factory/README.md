# Farsi Font Factory

A collection of beautiful Persian (Farsi) fonts optimized for Next.js projects. The package includes local font files, eliminating the need for an internet connection during development or build.

## Features

- 📦 Popular Persian fonts included locally in the package
- ⚡ Optimized for Next.js and React
- 🔄 ES2020 and ESM compatible
- 🎨 Tailwind CSS integration
- 🖌️ Mantine UI integration
- 📏 TypeScript support
- 🌐 No external CDN dependencies - works offline

## Installation

```bash
npm install farsi-font-factory
# or
yarn add farsi-font-factory
# or
pnpm add farsi-font-factory
```

## Available Fonts

- Vazirmatn (Default)
- IRANSansX
- Sahel
- Samim
- Tanha
- Nahid

## Usage with Next.js

### App Router

```tsx
// app/layout.tsx
import { Vazirmatn, addFarsiFontToNext } from 'farsi-font-factory';
import 'farsi-font-factory/styles.css'; // Import the CSS with font definitions

const vazirmatnFont = addFarsiFontToNext(Vazirmatn);

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="fa" dir="rtl" className={vazirmatnFont.className}>
      <body>{children}</body>
    </html>
  );
}
```

### Pages Router

```tsx
// pages/_document.tsx
import Document, { Html, Head, Main, NextScript } from 'next/document';
import { generateFontFaces } from 'farsi-font-factory';

// Generate CSS for Vazirmatn font
const fontFaceCSS = generateFontFaces(['Vazirmatn']);

class MyDocument extends Document {
  render() {
    return (
      <Html lang="fa" dir="rtl">
        <Head>
          <style dangerouslySetInnerHTML={{ __html: fontFaceCSS }} />
        </Head>
        <body>
          <Main />
          <NextScript />
        </body>
      </Html>
    );
  }
}

export default MyDocument;
```

## Usage with Tailwind CSS

```js
// tailwind.config.js
const { getTailwindFontConfig } = require('farsi-font-factory');

module.exports = {
  theme: {
    extend: {
      fontFamily: getTailwindFontConfig(['Vazirmatn', 'IRANSansX']),
    },
  },
  plugins: [],
};
```

Then use the fonts in your components:

```tsx
<div className="font-vazirmatn">
  متن به زبان فارسی
</div>

<div className="font-iransansx">
  متن دیگر به زبان فارسی
</div>
```

## Usage with Mantine UI 7

### Basic Integration

```tsx
// _app.tsx or similar
import { MantineProvider } from '@mantine/core';
import { getMantineTheme, Vazirmatn } from 'farsi-font-factory';
import 'farsi-font-factory/styles.css'; // Import the CSS with font definitions

export default function App({ Component, pageProps }) {
  return (
    <MantineProvider theme={getMantineTheme(Vazirmatn)}>
      <Component {...pageProps} />
    </MantineProvider>
  );
}
```

### Advanced Theme Customization

```tsx
import { MantineProvider } from '@mantine/core';
import { createFarsiMantineTheme, Vazirmatn, IRANSansX } from 'farsi-font-factory';
import 'farsi-font-factory/styles.css';

const theme = createFarsiMantineTheme({
  primaryFont: Vazirmatn,
  headingFont: IRANSansX,
  // Other Mantine theme options
  primaryColor: 'blue',
  colors: {
    // Your custom colors
  },
});

export default function App({ Component, pageProps }) {
  return (
    <MantineProvider theme={theme}>
      <Component {...pageProps} />
    </MantineProvider>
  );
}
```

### Using with createTheme

```tsx
// theme.ts
import { createTheme } from '@mantine/core';
import { getMantineFont, Vazirmatn } from 'farsi-font-factory';

export const theme = createTheme({
  ...getMantineFont(Vazirmatn),
  dir: 'rtl',
  // Other theme options
  primaryColor: 'blue',
});

// _app.tsx
import { MantineProvider } from '@mantine/core';
import { theme } from './theme';
import 'farsi-font-factory/styles.css';

export default function App({ Component, pageProps }) {
  return (
    <MantineProvider theme={theme}>
      <Component {...pageProps} />
    </MantineProvider>
  );
}
```

## Local Font Files

This package includes all font files locally in the `assets/fonts` directory. The font files are automatically copied during build, so no internet connection is required for development or production.

## API Reference

### Functions

#### `addFarsiFontToNext(font, options?)`

Add a Persian font to your Next.js application with proper configurations.

```tsx
import { Vazirmatn, addFarsiFontToNext } from 'farsi-font-factory';

const vazirmatnFont = addFarsiFontToNext(Vazirmatn);
// or
const vazirmatnFont = addFarsiFontToNext('Vazirmatn');
```

#### `getTailwindFontConfig(fonts)`

Generate Tailwind CSS configuration for specified fonts.

```js
import { getTailwindFontConfig } from 'farsi-font-factory';

const fontConfig = getTailwindFontConfig(['Vazirmatn', 'IRANSansX']);
```

#### `generateFontFaces(fonts)`

Generate CSS `@font-face` rules for specified fonts.

```js
import { generateFontFaces } from 'farsi-font-factory';

const css = generateFontFaces(['Vazirmatn', 'Sahel']);
```

#### `generateFontCss(fonts?)`

Generate a complete CSS file with all font faces and utility classes.

```js
import { generateFontCss } from 'farsi-font-factory';

// Generate CSS for all fonts
const allFontsCss = generateFontCss();

// Generate CSS for specific fonts
const specificFontsCss = generateFontCss(['Vazirmatn', 'IRANSansX']);
```

#### `getMantineTheme(font?)`

Generate Mantine UI theme configuration with a specific Persian font.

```ts
import { getMantineTheme, Vazirmatn } from 'farsi-font-factory';

const theme = getMantineTheme(Vazirmatn);
```

#### `createFarsiMantineTheme(options)`

Create a customized Mantine theme with Persian fonts support.

```ts
import { createFarsiMantineTheme, Vazirmatn, IRANSansX } from 'farsi-font-factory';

const theme = createFarsiMantineTheme({
  primaryFont: Vazirmatn,
  headingFont: IRANSansX,
  rtl: true,
  // Other Mantine theme options
});
```

## License

MIT
