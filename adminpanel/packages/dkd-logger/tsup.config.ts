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
  external: ['react', 'react-dom', 'next'],
  esbuildOptions(options) {
    baseConfig.esbuildOptions(options);
  },
});