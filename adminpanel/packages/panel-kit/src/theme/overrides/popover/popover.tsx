import type { MantineTheme } from '@mantine/core';
import { type ThemedMantine, getBackgroundColor, getCardBorderColor } from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// Popover Styles
// *******************
export const ThemedPopover: MantineThemeComponents['Popover'] = {
  defaultProps: {
    shadow: 'md',
    radius: 'md',
  },
  styles: (theme: MantineTheme) => {
    const themedTheme = theme as ThemedMantine;
    
    return {
      dropdown: {
        // backgroundColor: getBackgroundColor(themedTheme),
        // borderColor: getCardBorderColor(themedTheme),
        transition: 'opacity 150ms ease, transform 150ms ease',
      },
      arrow: {
        // backgroundColor: getBackgroundColor(themedTheme),
        // borderColor: getCardBorderColor(themedTheme),
      },
    };
  },
};