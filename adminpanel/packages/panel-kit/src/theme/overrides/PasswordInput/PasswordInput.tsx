
import type { MantineTheme } from '@mantine/core';
import { 
  type ThemedMantine, 
  getFocusBorderColor, 
  createPrimaryBoxShadow, 
  getThemeValue 
} from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// PasswordInput Styles
// *******************
export const ThemedPasswordInput: MantineThemeComponents['PasswordInput'] = {
  defaultProps: {
    radius: 'md',
  },
  styles: (theme: MantineTheme) => {
    const themedTheme = theme as ThemedMantine;
    
    return {
      label: {
        marginBottom: '10px'
        // color: themedTheme.colorScheme === 'dark' 
        //   ? theme.colors.gray[0] 
        //   : theme.colors.black,
      },
      // input: {
      //   // Base styles
      //   borderColor: themedTheme.colorScheme === 'dark' 
      //     ? theme.colors.dark[3] 
      //     : theme.colors.gray[4],
      //   color: themedTheme.colorScheme === 'dark' 
      //     ? theme.colors.gray[0] 
      //     : theme.colors.black,
      //   backgroundColor: themedTheme.colorScheme === 'dark' 
      //     ? theme.colors.dark[5] 
      //     : theme.colors.white,
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
      // error: {
      //   color: theme.colors.red[6],
      // },
    };
  },
};