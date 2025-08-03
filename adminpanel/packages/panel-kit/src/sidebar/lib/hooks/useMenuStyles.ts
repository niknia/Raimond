import { useMantineColorScheme, useMantineTheme } from '@mantine/core';

export const useMenuStyles = () => {
  const { colorScheme } = useMantineColorScheme();
  const theme = useMantineTheme();

  const isDark = colorScheme === 'dark';

  const getActiveStyles = (isActive: boolean) => {
    if (isActive) {
      return `bg-[${theme.colors[theme.primaryColor][6]}] text-[${theme.colors.gray[0]}]`;
    }
    return `hover:bg-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 6 : 2]}]`;
  };

  const getBorderColor = () => {
    return `border-[${theme.colors[colorScheme === 'dark' ? 'gray' : 'gray'][colorScheme === 'dark' ? 4 : 5]}]`;
  };

  const getBackgroundColor = () => {
    return `bg-[${theme.colors[theme.primaryColor][colorScheme === 'dark' ? 8 : 6]}]`;
  };

  const getTextColor = () => {
    return `text-[${theme.colors[colorScheme === 'dark' ? 'gray' : 'gray'][colorScheme === 'dark' ? 0 : 9]}]`;
  };

  const getFocusRingColor = () => {
    return `focus:ring-[${theme.colors[theme.primaryColor][4]}]`;
  };

  const getPopoverStyles = () => {
    return `
      bg-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 8 : 0]}]
      text-[${theme.colors[colorScheme === 'dark' ? 'gray' : 'gray'][colorScheme === 'dark' ? 0 : 9]}]
      border-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 6 : 3]}]
    `;
  };

  return {
    isDark,
    getActiveStyles,
    getBorderColor,
    getBackgroundColor,
    getTextColor,
    getFocusRingColor,
    getPopoverStyles,
    theme,
    colorScheme
  };
}; 