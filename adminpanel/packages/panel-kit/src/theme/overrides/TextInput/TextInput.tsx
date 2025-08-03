
import { useMantineColorScheme, useMantineTheme, type MantineTheme } from '@mantine/core';
import { type ThemedMantine,getTextColor, 
  getInputBorderColor, 
  getFocusBorderColor } from '../../util/componentThemeUtils';

type MantineThemeComponents = NonNullable<MantineTheme['components']>;

// *******************
// TextInput Styles
// *******************

export const ThemedTextInput: MantineThemeComponents['TextInput'] = {
  
  styles: (theme: MantineTheme) => {
    const { colorScheme } = useMantineColorScheme();
    const themedTheme = { ...theme, colorScheme } as ThemedMantine;
    
   
    return {
      label: {
       // color: getTextColor(themedTheme),
        marginBottom: '10px'
      },
      // input: {
      //   color: getTextColor(themedTheme),
      //   borderColor: theme.colors.gray[5],
      //   '&:focus': {
      //     borderColor: theme.colors.gray[9]
      //   }
      // },
      // error: {
      //   color: theme.colors.red[6],
      // },
    };
  },
};
