import { defineConfig } from 'tsup';

export const baseConfig = {
  format: ['esm' as const],
  dts: true,
  splitting: false,
  minify: true,
  clean: true,
  external: ['react', 'react-dom', 'next', 'next/router'],
  esbuildOptions(options) {
    options.jsx = 'automatic';
    options.jsxImportSource = 'react';
    options.platform = 'browser';
    options.target = 'es2020';
    options.define = {
      ...options.define,
      'process.env.NODE_ENV': '"production"',
    };
  },
};

export default defineConfig(baseConfig); 