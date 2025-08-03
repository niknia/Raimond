
const { getTailwindFontConfig } = require('farsi-font-factory');

/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './src/**/*.{js,ts,jsx,tsx}',
  ],
  theme: {
    extend: {
      fontFamily: getTailwindFontConfig(['Vazirmatn', 'IRANSansX', 'Sahel']),
    },
  },
  plugins: [],
};
