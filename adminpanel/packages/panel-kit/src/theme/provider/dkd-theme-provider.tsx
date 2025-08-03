"use client";

import { DirectionProvider } from "../../providers";
import { AppShellProvider } from "../../providers";
import { QueryProvider } from "../../providers";
// import {TranslationProvider} from "@providers";
import  { i18nConfig } from '@dkd/utils'
import { ThemeProvider } from "./provider";
import { ModalsProvider } from '@mantine/modals';
import { Notifications } from '@mantine/notifications';
import { NavigationProgress } from '@mantine/nprogress';

/**
 * Provides context for the main application theme, direction, and app shell.
 * Should be used as a root component in the application.
 *
 * @param children React node(s) to be rendered within the theme context.
 * @returns A React component that wraps the given children with the theme context.
 * @example
 * <DkdThemeProvider>
 *   <App />
 * </DkdThemeProvider>
 */

export function generateStaticParams(): { locale: string }[] {
  return i18nConfig.locales.map(locale => ({ locale }))
}

export function DkdThemeProvider({ children }: { children: React.ReactNode }) {
  return (
    <ThemeProvider>
      <DirectionProvider>
        <QueryProvider>
          <AppShellProvider>
            <ModalsProvider>
              <NavigationProgress />
              <Notifications limit={3}/>
              {children}
            </ModalsProvider>
          </AppShellProvider>
        </QueryProvider>
      </DirectionProvider>
    </ThemeProvider>
  );
}
