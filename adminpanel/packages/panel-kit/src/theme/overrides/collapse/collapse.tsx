import type { MantineTheme } from '@mantine/core';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// Collapse Styles
// *******************
export const ThemedCollapse: MantineThemeComponents['Collapse'] = {
  styles: (theme: MantineTheme) => ({
    root: {
      // Base styles for the collapse component
      transition: 'height 200ms ease',
    },
    content: {
      // Animation and transition for the content
      // opacity: 1,
      // transition: 'opacity 200ms ease',
    },
  }),
};