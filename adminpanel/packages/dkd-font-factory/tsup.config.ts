/// <reference types="node" />

import { defineConfig } from 'tsup';
import { promises as fs } from 'node:fs';
import path from 'node:path';

export default defineConfig({
  entry: ['src/index.ts'],
  format: ['cjs', 'esm'],
  dts: true,
  splitting: false,
  sourcemap: true,
  clean: true,
  target: 'es2020',
  outDir: 'dist',
  esbuildOptions(options) {
    options.banner = {
      js: `/**
 * Dkd-font-factory v0.2.0
 * 
 * A collection of beautiful Persian fonts optimized for Next.js, Tailwind v4, and Mantine UI 7
 * 
 * MIT License
 */`,
    };
  },
  async onSuccess() {
    // Copy CSS file
    try {
      const cssContent = await fs.readFile('src/styles.css', 'utf-8');
      await fs.writeFile('dist/styles.css', cssContent);
      console.log('✅ Copied styles.css to dist');
    } catch (error) {
      if ((error as NodeJS.ErrnoException).code !== 'ENOENT') {
        throw error;
      }
    }
    
    // Create fonts directory structure
    const distFontsPath = path.join('dist', 'assets', 'fonts');
    
    try {
      // Get all font family directories
      const fontFamilies = await fs.readdir(path.join('src', 'assets', 'fonts'));
      
      for (const family of fontFamilies) {
        // Skip README.md and non-directory files
        if (family === 'README.md' || !(await fs.stat(path.join('src', 'assets', 'fonts', family))).isDirectory()) {
          continue;
        }

        // Create family directory in dist
        const familyDistPath = path.join(distFontsPath, family);
        await fs.mkdir(familyDistPath, { recursive: true });
        
        // Recursively copy font files and directories
        await copyFontFiles(
          path.join('src', 'assets', 'fonts', family),
          familyDistPath
        );
        
        console.log(`✅ Copied files for ${family} font family`);
      }
    } catch (error) {
      if ((error as NodeJS.ErrnoException).code !== 'ENOENT') {
        throw error;
      }
    }

    console.log('✅ Font files and CSS processed successfully!');
  },
});

// Helper function to recursively copy font files and directories
async function copyFontFiles(srcPath: string, destPath: string) {
  const entries = await fs.readdir(srcPath, { withFileTypes: true });
  
  for (const entry of entries) {
    const srcEntryPath = path.join(srcPath, entry.name);
    const destEntryPath = path.join(destPath, entry.name);
    
    if (entry.isDirectory()) {
      // Create directory and recursively copy its contents
      await fs.mkdir(destEntryPath, { recursive: true });
      await copyFontFiles(srcEntryPath, destEntryPath);
    } else if (entry.isFile() && (entry.name.endsWith('.woff2') || entry.name.endsWith('.woff'))) {
      // Copy font files
      await fs.copyFile(srcEntryPath, destEntryPath);
    }
  }
}
