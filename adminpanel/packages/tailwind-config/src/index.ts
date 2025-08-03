import type { Config } from 'tailwindcss';
import { getTailwindFontConfig, Vazirmatn, Sahel, IRANSansX } from '@dkd-font-factory';
import tailwindPresetMantine from './tailwindPresetMantine';
import { mantineTailwindPlugin } from './createMantineTailwindPlugin';
// import tailwindPresetMantine from './tailwindPresetMantine';
// import { updateTailwindTheme } from './runtimeTheme';

const config: Config = {
  presets: [tailwindPresetMantine()],

  content: [
    './src/**/*.{js,ts,jsx,tsx,mdx}',
    '../../apps/website/src/**/*.{js,ts,jsx,tsx,mdx}',
    '../../packages/panel-kit/src/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  theme: {
    extend: {
       fontFamily: getTailwindFontConfig(['Roboto', 'IRANSansX']),
    },
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/typography'),
    require('@tailwindcss/aspect-ratio'),
    mantineTailwindPlugin,
  ],
};

// export { tailwindPresetMantine, updateTailwindTheme };
export default config; 