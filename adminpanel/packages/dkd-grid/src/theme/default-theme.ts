import type { MantineTheme } from '@mantine/core';
import type { DkdGridTheme } from './types';

export function createDefaultTheme(mantineTheme: MantineTheme): DkdGridTheme {
  const isDark = mantineTheme.colors.dark[0] === '#C1C2C5';

  return {
    colors: {
      primary: mantineTheme.colors.blue[6],
      header: {
        background: isDark ? mantineTheme.colors.dark[7] : mantineTheme.white,
        text: isDark ? mantineTheme.colors.dark[0] : mantineTheme.colors.dark[7],
        border: isDark ? mantineTheme.colors.dark[5] : mantineTheme.colors.gray[3],
        resizer: isDark ? mantineTheme.colors.dark[4] : mantineTheme.colors.gray[4],
        resizerHover: isDark ? mantineTheme.colors.dark[3] : mantineTheme.colors.gray[5],
      },
      row: {
        background: isDark ? mantineTheme.colors.dark[8] : mantineTheme.white,
        text: isDark ? mantineTheme.colors.dark[0] : mantineTheme.colors.dark[7],
        border: isDark ? mantineTheme.colors.dark[5] : mantineTheme.colors.gray[3],
        hoverBackground: isDark ? mantineTheme.colors.dark[7] : mantineTheme.colors.gray[0],
        selectedBackground: isDark ? mantineTheme.colors.dark[6] : mantineTheme.colors.blue[0],
        selectedText: isDark ? mantineTheme.colors.blue[2] : mantineTheme.colors.blue[7],
        selectedBorder: isDark ? mantineTheme.colors.blue[7] : mantineTheme.colors.blue[6],
        alternateBackground: isDark ? mantineTheme.colors.dark[7] : mantineTheme.colors.gray[1],
      },
      pagination: {
        background: isDark ? mantineTheme.colors.dark[7] : mantineTheme.white,
        text: isDark ? mantineTheme.colors.dark[0] : mantineTheme.colors.dark[7],
        border: isDark ? mantineTheme.colors.dark[5] : mantineTheme.colors.gray[3],
        activeBackground: isDark ? mantineTheme.colors.blue[7] : mantineTheme.colors.blue[6],
        activeText: mantineTheme.white,
      },
      error: mantineTheme.colors.red[6],
      actions: {
        background: mantineTheme.colors.blue[6],
        text: mantineTheme.white,
        iconColor: mantineTheme.white,
        iconBackground: mantineTheme.colors.blue[6],
        hoverBackground: mantineTheme.colors.blue[7],
        iconHoverBackground: mantineTheme.colors.blue[7],
        menuBackground: isDark ? mantineTheme.colors.dark[7] : mantineTheme.white,
      },
    },
    typography: {
      fontFamily: {
        ltr: mantineTheme.fontFamily,
        rtl: 'Vazir, Tahoma, Arial, sans-serif',
      },
      headerFontSize: mantineTheme.fontSizes.sm,
      headerFontWeight: 600,
      cellFontSize: mantineTheme.fontSizes.sm,
      actionFontSize: mantineTheme.fontSizes.sm,
    },
    spacing: {
      padding: mantineTheme.spacing.sm,
      headerHeight: 40,
      rowHeight: 40,
      fabPosition: mantineTheme.spacing.lg,
    },
    layout: {
      direction: 'ltr',
      fullWidth: true,
      columnResizing: true,
      minColumnWidth: 100,
      maxColumnWidth: 500,
    },
  };
} 