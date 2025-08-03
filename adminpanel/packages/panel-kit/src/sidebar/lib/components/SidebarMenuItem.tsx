import type { FC } from 'react';
import type { MenuItem } from '../types/menuItems';
import CollapsedMenuItem from './CollapsedMenuItem';
import ExpandedMenuItem from './ExpandedMenuItem';

interface SidebarMenuItemProps {
  item: MenuItem;
  collapsed: boolean;
}

const SidebarMenuItem: FC<SidebarMenuItemProps> = ({ item, collapsed }) => {
  const hasSubItems = item.children && item.children.length > 0;

  if (collapsed && hasSubItems) {
    return <CollapsedMenuItem item={item} />;
  }

  return <ExpandedMenuItem item={item} />;
};

export default SidebarMenuItem; 