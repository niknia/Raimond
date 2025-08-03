import type { MantineTheme } from '@mantine/core';
import { type ThemedMantine, getCardBorderColor, getBackgroundColor } from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// Card Styles
// *******************
export const ThemedCard: MantineThemeComponents['Card'] = {
    defaultProps: {},
    styles: (theme: MantineTheme) => {
      const themedTheme = theme as ThemedMantine;
      
      return {
        root: {
          // Base styles
          // transition: 'all 0.3s ease',
          // borderColor: getCardBorderColor(themedTheme),
          
          // // Hover state
          // '&:hover': {
          //   boxShadow: theme.shadows.md,
          //   transform: 'translateY(-3px)',
          // },
          
          // // Background color based on theme
          // backgroundColor: getBackgroundColor(themedTheme),
        },
      };
}
}
