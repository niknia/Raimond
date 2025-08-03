
/**
 * This is an example Tailwind v4 configuration
 * In a real project, adjust according to your needs
 */

const { getTailwindV4FontConfig } = require('farsi-font-factory');

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './src/**/*.{js,ts,jsx,tsx}',
  ],
  theme: {
    extend: {
      fontFamily: getTailwindV4FontConfig(['Vazirmatn', 'IRANSansX', 'Sahel']),
    },
  },
  plugins: [],
};
