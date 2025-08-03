"use client"

import type { FC } from "react"
import type { ReactNode } from "react"

import { ActionIcon, Anchor, AppShell, Burger, Group, Stack, Title, Tooltip, Text } from "@mantine/core"
import { useAppShell } from "../providers"
import { AppSidebar } from "../sidebar"
import { useDirection } from "../providers"
import { useEffect } from "react"
import surfaceClasses from "../styles/surface.module.css";
import { useMediaQuery } from '@mantine/hooks';
import { useDisclosure } from '@mantine/hooks';
import { HorizontalNavigation } from './horizontal-navigation';
import { IconBook } from '@tabler/icons-react';
import { cn } from '@dkd/utils';
import { Logo } from '../Components/logo';
import { Footer } from '../Components/footer';


interface DashboardLayoutProps {
  children: React.ReactNode;
  HeaderComponent?: React.ComponentType<any>;
}

export function DashboardLayout({ children, HeaderComponent }: DashboardLayoutProps) {
  const { opened, toggle, close, collapsed, navigationMode, toggleCollapsed } = useAppShell()
  const { direction } = useDirection()
  const isMobile = useMediaQuery('(max-width: 768px)');

  // const [mobileOpened, { toggle: toggleMobile }] = useDisclosure();
	// const [desktopOpened, { toggle: toggleDesktop }] = useDisclosure(true);

  // Force RTL styles to be applied correctly
  useEffect(() => {
    document.documentElement.dir = direction

    // Force Mantine to recalculate layout
    window.dispatchEvent(new Event("resize"))
  }, [direction])

  const handleBurgerClick = () => {
    if (navigationMode === "sidebar" && !isMobile) {
      toggleCollapsed();
    } else {
      toggle();
    }
  };

  return (
    <AppShell
      header={{ height: 60 }}
      navbar={{
        width: collapsed ? isMobile ? 250 : 60 : 250,
        breakpoint: 'sm',
        collapsed: { mobile: !opened, desktop: navigationMode === "horizontal" }
      }}
      footer={{ height: 35 }}
      padding={0}
      dir={direction}
      className={direction === "rtl" ? "rtl" : "ltr"}
      style={{ minHeight: '100vh' }}
    >
      <AppShell.Header className={surfaceClasses.surface}>
      <Group h="100%" w="100%" px="md" justify="space-between" align="center">
      <Group gap="xs">
            {isMobile && (
              <Burger
                opened={opened}
                onClick={handleBurgerClick}
                size="sm"
              />
            )}
            {navigationMode === "sidebar" && !isMobile && (
              <Burger
                opened={!collapsed}
                onClick={handleBurgerClick}
                size="sm"
              />
            )}
            <Logo />
        </Group>
		  <div className={cn("flex items-center gap-4", {
            'mr-auto': direction === 'ltr',
            'ml-auto': direction === 'rtl'
          }, "px-4")}>
		     {navigationMode !== "sidebar" && !isMobile && <HorizontalNavigation />}
		  </div>
          {HeaderComponent && <HeaderComponent/>}
      </Group>
      </AppShell.Header>

      {navigationMode === "sidebar" && (
        <AppShell.Navbar p={0} className={surfaceClasses.surface}>
          <AppSidebar collapsed={collapsed} />
        </AppShell.Navbar>
      )}

      <AppShell.Main style={{ height: 'calc(100vh - 95px)', overflow: 'hidden' }}>
        <div style={{ height: '100%', overflow: 'auto', padding: '1rem' }}>
          {children}
        </div>
      </AppShell.Main>

      <AppShell.Footer className={surfaceClasses.surface}>
        <Footer />
      </AppShell.Footer>
    </AppShell>
  )
}