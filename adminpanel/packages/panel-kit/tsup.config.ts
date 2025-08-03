import { defineConfig } from 'tsup';
import { baseConfig } from '../../tsup.base.config';
import postcss from 'postcss';
import tailwindcss from 'tailwindcss';
import autoprefixer from 'autoprefixer';

export default defineConfig({
  ...baseConfig,
  entry: ['src/index.ts', 'src/styles.css'],
  format: ['esm', 'cjs'],
  dts: true,
  banner: {
    js: "'use client'",
  },
  external: [
    'react',
    'react-dom',
    'next',
    '@mantine/core',
    '@mantine/hooks',
    '@dkd/utils',
    '@tailwind-config',
    '@dkd-font-factory',
    'fuzzy-search',
    '@mantine/notifications',
    '@mantine/modals',
    '@tanstack/react-query'
  ],
  esbuildOptions(options) {
    baseConfig.esbuildOptions(options);
    options.loader = {
      ...options.loader,
      '.css': 'css',
    };
    options.platform = 'browser';
  },
  async onSuccess() {
    // Process CSS with PostCSS and Tailwind
    const css = await postcss([
      tailwindcss('./tailwind.config.ts'),
      autoprefixer,
    ]).process(await import('node:fs').then(fs => fs.readFileSync('src/styles.css', 'utf8')), {
      from: 'src/styles.css',
      to: 'dist/styles.css'
    });
    
    await import('node:fs').then(fs => 
      fs.writeFileSync('dist/styles.css', css.css)
    );
  },
});