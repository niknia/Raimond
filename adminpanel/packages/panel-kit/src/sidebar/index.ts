"use client";

// Use this file to export React client components (e.g. those with 'use client' directive) or other non-server utilities


import type { FC } from 'react';
import type { MenuItem, SubMenuItem as SubMenuItemType, ThirdLevelMenuItem as ThirdLevelMenuItemType } from './types/menuItems';

// Import components
import AppSidebar from './lib/AppSidebar';
import SubMenuItem from './lib/SubMenuItem';
import ThirdLevelMenuItem from './lib/ThirdLevelMenuItem';

// Import icons
import { iconMap } from './lib/icons';

// Export components
export { AppSidebar };
export { SubMenuItem };
export { ThirdLevelMenuItem };

// Export types
export type { MenuItem };
export type { SubMenuItemType };
export type { ThirdLevelMenuItemType };

// Export interfaces
export interface SidebarMenuItemProps {
  item: MenuItem;
  collapsed: boolean;
}

export interface SubMenuItemProps {
  item: SubMenuItemType;
  iconMap: Record<string, React.ReactNode>;
}

export interface ThirdLevelMenuItemProps {
  item: ThirdLevelMenuItemType;
  collapsed: boolean;
}

// Export icon map
export { iconMap };
