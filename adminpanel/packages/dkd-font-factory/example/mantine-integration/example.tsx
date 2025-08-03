/**
 * This is an example file for documentation purposes only
 * In a real project, you would have already installed the required dependencies
 */

import { MantineProvider, createTheme, Button, Title, Text } from '@mantine/core';
import { createFarsiMantineTheme, Vazirmatn, IRANSansX } from 'farsi-font-factory';
import 'farsi-font-factory/styles.css';

// Method 1: Using createFarsiMantineTheme
const theme = createFarsiMantineTheme({
  primaryFont: Vazirmatn,
  headingFont: IRANSansX,
  rtl: true,
  // Other Mantine theme options
  primaryColor: 'blue',
});

// Method 2: Using createTheme with getMantineFont
// const customTheme = createTheme({
//   ...getMantineFont(Vazirmatn),
//   dir: 'rtl',
//   // Other theme options
// });

export default function MantineExample() {
  return (
    <MantineProvider theme={theme}>
      <div style={{ padding: '2rem' }}>
        <Title order={1}>نمونه استفاده از فونت‌های فارسی با Mantine UI</Title>
        
        <Text mt="xl">
          این یک متن فارسی است که با استفاده از فونت وزیرمتن نمایش داده می‌شود.
        </Text>
        
        <Button mt="xl">دکمه فارسی</Button>
        
        <Title order={2} mt="xl" style={{ fontFamily: `${IRANSansX.family}, ${IRANSansX.fallback}` }}>
          عنوان با فونت ایران‌سنس
        </Title>
        
        <Text mt="lg" style={{ fontFamily: `${IRANSansX.family}, ${IRANSansX.fallback}` }}>
          این متن با فونت ایران‌سنس نمایش داده می‌شود که به صورت جداگانه برای این المان تنظیم شده است.
        </Text>
      </div>
    </MantineProvider>
  );
}
