import type { MantineTheme } from '@mantine/core';
import { getThemeValue } from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

export const ThemedAvatar: MantineThemeComponents['Avatar'] = {
  styles: (theme: MantineTheme) => {
    return {
      root: {
        // transition: theme.other.transition.default,
        // '&:hover': {
        //   transform: 'scale(1.05)',
        // },
      },
      // placeholder: {
      //   backgroundColor: getThemeValue(
      //     theme as any, 
      //     theme.colors[theme.primaryColor][1], 
      //     theme.colors[theme.primaryColor][8]
      //   ),
      //   color: getThemeValue(
      //     theme as any, 
      //     theme.colors[theme.primaryColor][8], 
      //     theme.colors[theme.primaryColor][1]
      //   ),
      // },
    };
  },
}
