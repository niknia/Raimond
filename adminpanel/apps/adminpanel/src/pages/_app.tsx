'use client';

import { AppProps } from 'next/app';
import Head from 'next/head';
import { ReactElement, ReactNode } from 'react';
import { NextPage } from 'next';

import '@mantine/core/styles.css';
import '@mantine/notifications/styles.css';
import '@mantine/dates/styles.css';
import '@mantine/dropzone/styles.css';
import '@mantine/carousel/styles.css';
import '@mantine/code-highlight/styles.css';
import '@mantine/tiptap/styles.css';
import '../styles/globals.css';
import '@dkd-font-factory/dist/styles.css'
import { NotificationProvider } from '../components/notifications/NotificationProvider';
import { QueryProvider } from '@/providers/QueryProvider';
import { AuthProvider } from '@/providers/AuthContext';
import { axiosConfig } from '@dkd-axios';
import { DirectionProvider, DkdThemeProvider, ThemeProvider } from '@dkd/panel-kit';
import { API_URL } from '@/lib/constants';

// Configure axios
axiosConfig.setConfig({
  baseUrl: API_URL ,
  timeout: 10000,
  withCredentials: true,
  headers: {
    'Content-Type': 'application/json',
  },
  requestOptions: {
    isJoinPrefix: true,
    isReturnNativeResponse: false,
    isTransformResponse: true,
    joinParamsToUrl: false,
    formatDate: true,
    joinTime: true,
    ignoreRepeatRequest: true,
    withToken: true,
    retry: {
      count: 3,
      delay: 1000,
    },
  },
});

type NextPageWithLayout = NextPage & {
  getLayout?: (page: ReactElement) => ReactNode;
};

type AppPropsWithLayout = AppProps & {
  Component: NextPageWithLayout;
};

const App = ({ Component, pageProps }: AppPropsWithLayout) => {
  const getLayout = Component.getLayout || ((page: ReactElement) => page);

  return (
    <>
      <Head>
        <title>پنل مدیریتی</title>
        <meta name="viewport" content="minimum-scale=1, initial-scale=1, width=device-width" />
      </Head>
      <DirectionProvider>
      {/* <ThemeProvider> */}
        <QueryProvider>
          <AuthProvider>
            <DkdThemeProvider>
            <main className="app">
              {getLayout(<Component {...pageProps} />)}
            </main>
            </DkdThemeProvider>
          </AuthProvider>
        </QueryProvider>
      {/* </DirectionProvider></ThemeProvider> */}
      </DirectionProvider>
    </>
  );
}

export default App;
