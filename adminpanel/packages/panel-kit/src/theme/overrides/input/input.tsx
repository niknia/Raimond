import type { MantineTheme } from '@mantine/core';
import { 
  type ThemedMantine, 
  getInputBorderColor, 
  getFocusBorderColor, 
  createPrimaryBoxShadow, 
  getTextColor, 
  getThemeValue 
} from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// Input Styles
// *******************
export const ThemedInput: MantineThemeComponents['Input'] = {
  defaultProps: {
    radius: 'md',
  },
  styles: (theme: MantineTheme) => {
    const themedTheme = theme as ThemedMantine;
    
    return {
      // input: {
      //   // Base styles
      //   borderColor: getInputBorderColor(themedTheme),
      //   color: getTextColor(themedTheme),
      //   transition: 'border-color 200ms ease, color 200ms ease, box-shadow 200ms ease',
        
      //   // Focus state
      //   '&:focus, &:focus-within': {
      //     borderColor: getFocusBorderColor(themedTheme),
      //     boxShadow: createPrimaryBoxShadow(themedTheme),
      //   },
        
      //   // Hover state
      //   '&:hover': {
      //     borderColor: theme.colors[theme.primaryColor][7],
      //   },
        
      //   // Disabled state
      //   '&[disabled]': {
      //     borderColor: getThemeValue(themedTheme, theme.colors.gray[3], theme.colors.dark[4]),
      //     backgroundColor: getThemeValue(themedTheme, theme.colors.gray[1], theme.colors.dark[6]),
      //     color: getThemeValue(themedTheme, theme.colors.gray[5], theme.colors.dark[2]),
      //   },
        
      //   // Invalid state
      //   '&[data-invalid]': {
      //     borderColor: theme.colors.red[7],
      //     color: getThemeValue(themedTheme, theme.colors.red[9], theme.colors.red[2]),
      //   },
        
      //   // Placeholder
      //   '&::placeholder': {
      //     color: getThemeValue(themedTheme, theme.colors.gray[5], theme.colors.dark[2]),
      //     opacity: '0.8',
      //   },
      // },
    };
  },
};