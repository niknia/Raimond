import type { MantineThemeOverride } from '@mantine/core';

export interface GridTheme {
  headerBackground: string;
  headerTextColor: string;
  borderColor: string;
  rowHoverColor: string;
  stripedColor: string;
  paginationColor: string;
  actionButtonColor: string;
}

export const lightTheme: GridTheme = {
  headerBackground: '#f8f9fa',
  headerTextColor: '#212529',
  borderColor: '#dee2e6',
  rowHoverColor: '#f8f9fa',
  stripedColor: '#f8f9fa',
  paginationColor: '#228be6',
  actionButtonColor: '#228be6',
};

export const darkTheme: GridTheme = {
  headerBackground: '#2c2e33',
  headerTextColor: '#c1c2c5',
  borderColor: '#373a40',
  rowHoverColor: '#2c2e33',
  stripedColor: '#25262b',
  paginationColor: '#74b0ff',
  actionButtonColor: '#74b0ff',
};

export const getGridTheme = (theme: MantineThemeOverride): GridTheme => {
  return theme.colorScheme === 'dark' ? darkTheme : lightTheme;
}; 