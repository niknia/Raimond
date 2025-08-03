import { defineConfig } from 'tsup';
import { baseConfig } from '../../tsup.base.config';

export default defineConfig({
  ...baseConfig,
  entry: ['src/index.ts'],
  format: ['esm', 'cjs'],
  dts: true,
  banner: {
    js: "'use client'",
  },
  external: [
    'react',
    'react-dom',
    'next',
    '@dkd/utils',
    '@nozbe/watermelondb',
    '@nozbe/with-observables',
    'redux-persist',
    'rxjs'
  ],
  esbuildOptions(options) {
    baseConfig.esbuildOptions(options);
    options.loader = {
      ...options.loader,
      '.css': 'local-css',
    };
  }
}); 