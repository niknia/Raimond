import { defineConfig } from 'tsup';

export default defineConfig({
  entry: {
    '.': 'src/index.ts',
  },
  format: ['cjs', 'esm'],
  external: ['react', '@mantine/core', 'react-dom'],
  dts: true,
  splitting: false,
  minify: true,
  clean: true,
  esbuildOptions(options) {
    options.banner = {
      js: '"use client"',
    };
    options.define = {
      'process.env.NODE_ENV': '"production"',
    };
  },
  treeshake: true,
});