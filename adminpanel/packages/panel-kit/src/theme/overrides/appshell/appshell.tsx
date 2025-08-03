import type { MantineTheme } from '@mantine/core';
import { type ThemedMantine, getBackgroundColor, getCardBorderColor } from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// AppShell Styles
// *******************
export const ThemedAppShell: MantineThemeComponents['AppShell'] = {
  defaultProps: {}, // مقادیر پیش‌فرض (در صورت نیاز می‌توانید تنظیم کنید)
  styles: (theme: MantineTheme) => {
    const themedTheme = theme as ThemedMantine;

    return {
      root: {
      //   // Base styles
      //   display: 'flex',
      //   flexDirection: 'column',
      //   minHeight: '100vh', // ارتفاع کامل صفحه
      //   backgroundColor: getBackgroundColor(themedTheme), // رنگ پس‌زمینه بر اساس تم
      //   color: themedTheme.colorScheme === 'dark' ? theme.colors.dark[0] : theme.black, // رنگ متن
      //   transition: 'background-color 0.3s ease, color 0.3s ease', // انتقال نرم برای تغییر تم

      //   // Padding and margin
      //   padding: 0,
      //   margin: 0,
      // },
      // body: {
      //   flex: 1, // فضای باقی‌مانده را اشغال کند
      //   display: 'flex',
      //   flexDirection: 'column',
      // },
      // main: {
      //   flex: 1, // فضای اصلی را اشغال کند
      //   padding: theme.spacing.md, // فاصله داخلی
      //   overflow: 'auto', // اجازه اسکرول در صورت نیاز
      // },
      // header: {
      //   borderBottom: `1px solid ${getCardBorderColor(themedTheme)}`, // خط جداکننده زیر هدر
      //   backgroundColor: themedTheme.colorScheme === 'dark' ? theme.colors.dark[7] : theme.white, // رنگ پس‌زمینه هدر
      // },
      // navbar: {
      //   borderRight: `1px solid ${getCardBorderColor(themedTheme)}`, // خط جداکننده سمت راست نوار ناوبری
      //   backgroundColor: themedTheme.colorScheme === 'dark' ? theme.colors.dark[6] : theme.white, // رنگ پس‌زمینه نوار ناوبری
      //   padding: 0, // حذف padding از navbar
      // },
      // footer: {
      //   borderTop: `1px solid ${getCardBorderColor(themedTheme)}`, // خط جداکننده بالای فوتر
      //   backgroundColor: themedTheme.colorScheme === 'dark' ? theme.colors.dark[7] : theme.white, // رنگ پس‌زمینه فوتر
      },
    };
  },
};