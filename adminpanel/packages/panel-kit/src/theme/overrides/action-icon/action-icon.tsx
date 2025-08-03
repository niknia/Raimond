import type { MantineTheme } from '@mantine/core'

type MantineThemeComponents = NonNullable<MantineTheme['components']>;


export const ThemedActionIcon: MantineThemeComponents['ActionIcon'] = {
  styles: (theme: MantineTheme) => {
    return {
      root: {
        // transition: theme.other.transition.default,
        // '&:hover': {
        //   transform: 'scale(1.05)',
        // },
      },
    };
  },
}
