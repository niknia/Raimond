import { ReactNode } from 'react';
import { Container } from '@mantine/core';
import { DashboardLayout } from '@dkd/panel-kit';
import { Header } from './Header';


interface BasePageProps {
  children: ReactNode;
  title?: string;
  fluid?: boolean;
}

export function BasePage({ children, title, fluid = false }: BasePageProps) {
  return (
    <DashboardLayout HeaderComponent={Header}>
      {/* <Container size={fluid ? '100%' : 'xl'}> */}
        {children}
      {/* </Container> */}
    </DashboardLayout>
  );
} 