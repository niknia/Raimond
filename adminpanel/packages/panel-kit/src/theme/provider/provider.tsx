"use client"

import type React from "react"
import { useEffect, useState } from "react"
import { useMantineColorScheme, MantineProvider } from "@mantine/core"
import { Notifications } from '@mantine/notifications'
import { NavigationProgress } from '@mantine/nprogress'
import type {ThemeProviderProps} from './provider.types'
import { MotionLazyProvider } from "./motion-lazy"
import { useThemes } from "../use-theme"

function ColorSchemeSync({ children }: { children: React.ReactNode }) {
  const { setColorScheme, colorScheme } = useMantineColorScheme();

  useEffect(() => {
    // Get stored mantine color scheme
    const storedColorScheme = typeof window !== 'undefined'
      ? window.localStorage.getItem('mantine-color-scheme-value')
      : null;

    // Only set color scheme if it exists in storage
    if (storedColorScheme === 'light' || storedColorScheme === 'dark') {
      setColorScheme(storedColorScheme);
      // Sync with Tailwind dark mode
      if (typeof window !== 'undefined') {
        if (storedColorScheme === 'dark') {
          document.documentElement.classList.add('dark');
        } else {
          document.documentElement.classList.remove('dark');
        }
      }
    }
  }, [setColorScheme]);

  // Sync Tailwind dark mode with Mantine color scheme changes
  useEffect(() => {
    if (typeof window !== 'undefined') {
      if (colorScheme === 'dark') {
        document.documentElement.classList.add('dark');
      } else {
        document.documentElement.classList.remove('dark');
      }
    }
  }, [colorScheme]);

  return <>{children}</>;
}

export const ThemeProvider: React.FC<ThemeProviderProps> = ({ children }) => {
  const [mounted, setMounted] = useState(false);
  const { themes, currentThemeName } = useThemes();

  useEffect(() => {
    setMounted(true);
  }, []);

  if (!mounted) {
    return null;
  }

  return (
    <MotionLazyProvider>
      <MantineProvider
        theme={themes[currentThemeName]?.mantineTheme}
        defaultColorScheme="light"
      >
        <ColorSchemeSync>
          <NavigationProgress />
          <Notifications limit={3}/>
          {children}
        </ColorSchemeSync>
      </MantineProvider>
    </MotionLazyProvider>
  )
}

