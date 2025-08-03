import type { AppProps } from 'next/app';
import React from 'react';
import { initializeGlobalLogger } from '../global';
import type { LoggerOptions } from '../types';

type NextPageContext = {
  pathname: string;
  query: Record<string, string>;
};

export function withLogger(options: LoggerOptions = {}) {
  // Initialize the global logger
  initializeGlobalLogger(options);
  
  return function withLoggerHOC(Component: React.ComponentType<AppProps> & { getInitialProps?: (ctx: NextPageContext) => Promise<Record<string, unknown>> }) {
    const WithLogger = (props: AppProps) => {
      // Log page navigation using global logger
      debug(`Rendering page: ${props.router.pathname}`, {
        pathname: props.router.pathname,
        query: props.router.query,
      });
      
      return React.createElement(Component, props);
    };
    
    if (Component.getInitialProps) {
      WithLogger.getInitialProps = async (ctx: NextPageContext) => {
        debug(`getInitialProps: ${ctx.pathname}`, {
          pathname: ctx.pathname,
          query: ctx.query,
        });
        
        const originalProps = await (Component.getInitialProps as (ctx: NextPageContext) => Promise<Record<string, unknown>>)(ctx);
        return originalProps;
      };
    }
    
    return WithLogger;
  };
}