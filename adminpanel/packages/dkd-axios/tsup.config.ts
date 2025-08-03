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
    'axios',
    'jsonwebtoken',
    'crypto',
    'lodash',
  ],
  esbuildOptions(options) {
    baseConfig.esbuildOptions(options);
    options.loader = {
      ...options.loader,
      '.css': 'local-css',
    };
    options.define = {
      ...options.define,
      'process.env.MODE': '"development"',
      'process.env.NEXT_PUBLIC_REST_API_ENDPOINT': '""',
      'process.env.NEXT_PUBLIC_REST_API_ENDPOINT_PREFIX': '""',
    };
  }
}); 