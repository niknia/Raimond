import config from '@tailwind-config';

/** @type {import('tailwindcss').Config} */
export default {
  ...config,
  content: [
    ...(Array.isArray(config.content) ? config.content : []),
    './src/**/*.{js,ts,jsx,tsx,mdx}',
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',
  ]
}; 