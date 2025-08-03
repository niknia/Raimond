import { defineConfig } from 'tsup';

export default defineConfig({
  entry: ['src/index.ts'],
  format: ['esm'],
  dts: true,
  splitting: false,
  sourcemap: true,
  clean: true,
  minify: true,
  target: 'es2022',
  outDir: 'dist',
  external: [
    '@dkd-font-factory','@mantine/core'
  ],
  esbuildOptions(options) {
    options.charset = 'utf8';
  },
}); 