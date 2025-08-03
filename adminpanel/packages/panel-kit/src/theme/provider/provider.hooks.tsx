import type { MantineThemeOverride } from '@mantine/core';
import {useMantineColorScheme} from '@mantine/core'
import type { SpotlightActionData } from '@mantine/spotlight';
import { useMemo, useState } from 'react';
import { ThemeComponentsOverrides } from '../overrides';
import { ThemeTransitions } from '../transition';
import { ThemeTypography } from '../typography';
import { useTheme } from 'next-themes';
import { ThemeOption } from './provider.types';

export const useCreateTheme = () => {

  const theme: MantineThemeOverride = useMemo(
    () => ({
      //colorScheme,
      fontFamily: "Public Sans",
      components: ThemeComponentsOverrides,
      primaryColor: "grape",
      other: {
        typography: ThemeTypography,
        transitions: ThemeTransitions,
      },
    }),
    //[colorScheme]
  );

  return {
    //colorScheme,
    //toggleColorScheme,
    theme,
    //spotlightActions,
    ///setSpotlightActions,
  };
};
// export const useCreateTheme = (colorScheme: 'light' | 'dark' | 'auto'): MantineThemeOverride => {
//   return {
//     // colorScheme,
//     fontFamily: 'Public Sans',
//     components: ThemeComponentsOverrides,
//     primaryColor: 'grape',
//     other: {
//       typography: ThemeTypography,
//       transitions: () => ThemeTransitions,
//     },
//   };
// };

// Separate hook for spotlight actions (still uses useState, which is fine)
export const useSpotlightActions = () => {
  const [spotlightActions, setSpotlightActions] = useState<SpotlightActionData[]>([]);
  return { spotlightActions, setSpotlightActions };
};