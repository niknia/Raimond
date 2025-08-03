
import type { MantineTheme } from '@mantine/core';
import type { ThemedMantine } from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// Tooltip Styles
// *******************

export const ThemedTooltip: MantineThemeComponents['Tooltip'] = {
  defaultProps: {
    withArrow: true,
    arrowSize: 6,
  },
  styles: (theme: MantineTheme) => {
    const themedTheme = theme as ThemedMantine;
    
    return {
      // tooltip: {
      //   backgroundColor: themedTheme.colorScheme === 'dark' 
      //     ? theme.colors.dark[5] 
      //     : theme.colors.gray[9],
      //   color: themedTheme.colorScheme === 'dark' 
      //     ? theme.colors.dark[0] 
      //     : theme.white,
      //   fontSize: theme.fontSizes.xs,
      //   boxShadow: theme.shadows.sm,
      // },
      // arrow: {
      //   backgroundColor: themedTheme.colorScheme === 'dark' 
      //     ? theme.colors.dark[5] 
      //     : theme.colors.gray[9],
      // },
    };
  },
}
