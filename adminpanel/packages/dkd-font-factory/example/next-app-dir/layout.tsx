
/**
 * This is an example file for documentation purposes only
 * In a real Next.js project, you would import from the installed package
 */

// import { Vazirmatn, addFarsiFontToNext } from 'farsi-font-factory';
// import './globals.css';

// Initialize font
// const vazirmatnFont = addFarsiFontToNext(Vazirmatn);

export const metadata = {
  title: 'Next.js با فونت فارسی',
  description: 'مثال استفاده از فونت فارسی در Next.js',
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  // This is just an example of how you would use the package
  // In a real project, this would use the actual vazirmatnFont variable
  return (
    <html lang="fa" dir="rtl" className="font-vazirmatn">
      <body>{children}</body>
    </html>
  );
}
