import type { FC } from 'react';
import { useMantineColorScheme, useMantineTheme } from '@mantine/core';
import { menuItems } from '../data/menuItems';
import { SidebarMenuItem } from './components';
import { useMenuStyles } from './hooks/useMenuStyles';

interface AppSidebarProps {
  collapsed: boolean;
}

const AppSidebar: FC<AppSidebarProps> = ({ collapsed }) => {
  const { getBackgroundColor, getTextColor } = useMenuStyles();

  return (
    <nav className={`
      ${collapsed ? 'w-16' : 'w-64'}
      ${getBackgroundColor()}
      ${getTextColor()}
      w-full
      text-sm
      font-semibold
      h-screen
      top-0 left-0
      shadow-md
      transition-all duration-300 ease-in-out
      overflow-y-auto
      scrollbar-hide
      [&::-webkit-scrollbar]:hidden
      [-ms-overflow-style:none]
      [scrollbar-width:none]
    `}>
      <div className="p-4">
        <ul className="space-y-0">
          {menuItems.map((item) => (
            <SidebarMenuItem key={item.id} item={item} collapsed={collapsed} />
          ))}
        </ul>
      </div>
    </nav>
  );
};

export default AppSidebar; 