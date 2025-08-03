import config from '@tailwind-config';

export default {
  ...config,
  content: [
    ...(Array.isArray(config.content) ? config.content : []),
    './src/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',
    './dist/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  important: true,
}; 