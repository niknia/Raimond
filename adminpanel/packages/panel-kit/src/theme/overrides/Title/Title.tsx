
import type { MantineTheme } from '@mantine/core';
import type { ThemedMantine } from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// Tooltip Styles
// *******************

export const ThemedTitle: MantineThemeComponents['Title'] = {
  styles: () => ({
    root: {
      fontFamily: 'var(--mantine-font-family)',
    },
  }),
};

