import type { MantineTheme } from '@mantine/core';

// Type definition for theme with color scheme
export type ThemedMantine = MantineTheme & { colorScheme: 'light' | 'dark' };

/**
 * Generic function to get a value from theme based on color scheme
 * @param theme Mantine theme with color scheme
 * @param lightValue Value to use in light mode
 * @param darkValue Value to use in dark mode
 * @returns Appropriate value based on theme color scheme
 */
export const getThemeValue = <T>(theme: ThemedMantine, lightValue: T, darkValue: T): T => {
  return theme.colorScheme === 'dark' ? darkValue : lightValue;
};

/**
 * Gets appropriate text color based on color scheme
 * @param theme Mantine theme with color scheme
 * @returns Text color for current theme
 */
export const getTextColor = (theme: ThemedMantine) => {
  return getThemeValue(theme, theme.black, theme.colors.dark[0]);
};

/**
 * Gets appropriate card border color based on color scheme
 * @param theme Mantine theme with color scheme
 * @returns Border color for current theme
 */
export const getCardBorderColor = (theme: ThemedMantine) => {
  return getThemeValue(theme, theme.colors.gray[3], theme.colors.dark[4]);
};

/**
 * Gets appropriate button hover color based on color scheme
 * @param theme Mantine theme with color scheme
 * @returns Button hover color for current theme
 */
export const getButtonHoverColor = (theme: ThemedMantine) => {
  return getThemeValue(
    theme, 
    theme.colors[theme.primaryColor][7], 
    theme.colors[theme.primaryColor][3]
  );
};

/**
 * Gets appropriate input border color based on color scheme
 * @param theme Mantine theme with color scheme
 * @returns Input border color for current theme
 */
export const getInputBorderColor = (theme: ThemedMantine) => {
  const baseColor = theme.colors[theme.primaryColor][6];
  return getThemeValue(theme, baseColor, theme.colors[theme.primaryColor][4]);
};

/**
 * Gets appropriate input focus border color based on color scheme
 * @param theme Mantine theme with color scheme
 * @returns Input focus border color for current theme
 */
export const getFocusBorderColor = (theme: ThemedMantine) => {
  return getThemeValue(
    theme, 
    theme.colors[theme.primaryColor][7], 
    theme.colors[theme.primaryColor][3]
  );
};

/**
 * Creates box shadow with theme's primary color
 * @param theme Mantine theme with color scheme
 * @param opacity Shadow opacity
 * @returns CSS box-shadow value
 */
export const createPrimaryBoxShadow = (
  theme: ThemedMantine,
  opacity = 0.2
) => {
  const colorIndex = getThemeValue(theme, 5, 8);
  const color = theme.colors[theme.primaryColor][colorIndex];
  return `0 0 0 2px rgba(${hexToRgb(color).join(', ')}, ${opacity})`;
};

/**
 * Converts hex color to RGB array
 * @param hex Hex color string
 * @returns RGB array [r, g, b]
 */
export const hexToRgb = (hex: string): number[] => {
  // Remove # if present
  const cleanHex = hex.replace('#', '');
  
  // Parse as RGB
  const r = Number.parseInt(cleanHex.substring(0, 2), 16);
  const g = Number.parseInt(cleanHex.substring(2, 4), 16);
  const b = Number.parseInt(cleanHex.substring(4, 6), 16);
  
  return [r, g, b];
};

/**
 * Generates background color based on theme color scheme
 * @param theme Mantine theme with color scheme
 * @returns Background color for current theme
 */
export const getBackgroundColor = (theme: ThemedMantine) => {
  return getThemeValue(theme, theme.white, theme.colors.dark[7]);
};

/**
 * Generates hover state background color
 * @param theme Mantine theme with color scheme
 * @returns Hover background color for current theme
 */
export const getHoverBackgroundColor = (theme: ThemedMantine) => {
  return getThemeValue(theme, theme.colors.gray[0], theme.colors.dark[6]);
};

/**
 * Generates active/pressed state background color
 * @param theme Mantine theme with color scheme
 * @returns Active background color for current theme
 */
export const getActiveBackgroundColor = (theme: ThemedMantine) => {
  return getThemeValue(theme, theme.colors.gray[1], theme.colors.dark[5]);
};

/**
 * Gets the appropriate color for a component variant based on theme
 * @param theme Mantine theme
 * @param variant Component variant name
 * @param shade Optional shade offset for light/dark mode
 * @returns Color string appropriate for the theme and variant
 */
export const getVariantColor = (theme: ThemedMantine, variant: string, shade = 0) => {
  // Use primary color if variant is not a color name
  const colorName = theme.colors[variant] ? variant : theme.primaryColor;
  
  // Determine the base index 
  const baseIndex = 5;
  const adjustedIndex = theme.colorScheme === 'dark' 
    ? Math.max(0, baseIndex - shade)
    : Math.min(9, baseIndex + shade);
    
  return theme.colors[colorName][adjustedIndex];
};

/**
 * Gets proper contrast text color for a background color
 * @param theme Mantine theme
 * @param bgColorName Background color name
 * @param bgColorIndex Background color index
 * @returns Text color with appropriate contrast
 */
export const getContrastText = (theme: ThemedMantine, bgColorName: string, bgColorIndex: number) => {
  // Simple heuristic - darker background indices (> 5) get light text, lighter get dark text
  return bgColorIndex > 5 ? theme.white : theme.black;
};