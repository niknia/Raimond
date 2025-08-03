import type { MantineTheme } from '@mantine/core';
import type { ThemedMantine } from '../../util/componentThemeUtils';
import { getThemeValue } from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

export const ThemedScrollArea: MantineThemeComponents['ScrollArea'] = {
  styles: (theme: MantineTheme)  => {
    const themedTheme = theme as ThemedMantine;
    
    return {
      scrollbar: {
        // '&:hover': {
        //   backgroundColor: getThemeValue(
        //     themedTheme, 
        //     'rgba(0, 0, 0, 0.05)', 
        //     'rgba(255, 255, 255, 0.05)'
        //   ),
        // },
      },
      thumb: {
        // backgroundColor: getThemeValue(
        //   themedTheme, 
        //   'rgba(0, 0, 0, 0.2)', 
        //   'rgba(255, 255, 255, 0.2)'
        // ),
        // '&:hover': {
        //   backgroundColor: getThemeValue(
        //     themedTheme, 
        //     'rgba(0, 0, 0, 0.3)', 
        //     'rgba(255, 255, 255, 0.3)'
        //   ),
        // },
      },
    };
  },
}
