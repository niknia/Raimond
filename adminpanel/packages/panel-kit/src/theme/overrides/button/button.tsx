import type { MantineTheme } from '@mantine/core';
import { type ThemedMantine, getButtonHoverColor, } from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// Button Styles
// *******************
export const ThemedButton: MantineThemeComponents['Button'] = {
  defaultProps: {
    radius: 'md',
  },
  styles: (theme: MantineTheme) => {
    const themedTheme = theme as ThemedMantine;
    
    return {
      root: {
        // Base styles
        // transition: 'all 0.2s ease',
        
        // Hover state
        // '&:hover': {
        //   transform: 'translateY(-2px)',
        //   boxShadow: theme.shadows.sm,
        //   backgroundColor: getButtonHoverColor(themedTheme),
        // },
        
        // Active state
        // '&:active': {
        //   transform: 'translateY(0)',
        // },
        
        // Disabled state
        // '&:disabled': {
        //   opacity: '0.6',
        //   transform: 'none',
        //   boxShadow: 'none',
        // },
      },
    };
  },
};