import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ReactNode } from 'react';
import dynamic from 'next/dynamic';
import { AuthProvider } from '@dkd-axios';

// Create a client-side only wrapper component

const queryClient = new QueryClient({
  defaultOptions: {
    queries: {
      refetchOnWindowFocus: false,
      retry: 1,
      staleTime: 5 * 60 * 1000, // 5 minutes
    },
  },
});

interface QueryProviderProps {
  children: ReactNode;
}

export function QueryProvider({ children }: QueryProviderProps) {
  return (
    <QueryClientProvider client={queryClient}>
      {/* <AuthProvider> */}
        {children}
      {/* </AuthProvider> */}
    </QueryClientProvider>
  );
} 