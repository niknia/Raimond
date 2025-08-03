import { ReactNode } from 'react';
import { Notifications } from '@mantine/notifications';

interface NotificationProviderProps {
  children: ReactNode;
}

export function NotificationProvider({ children }: NotificationProviderProps) {
  return (
    <>
      <Notifications position="top-right" limit={3}/>
      {children}
    </>
  );
} 