import type { FC } from 'react';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { UnstyledButton, Menu } from '@mantine/core';

import { getDirection } from '@dkd/utils';
import { menuItems } from '../sidebar/data/menuItems';
import { useMantineColorScheme } from '@mantine/core';
import { Icon } from '../Components/icons/IconMap';
import type { MenuItem } from '../sidebar/types/menuItems';

const renderMenuItem = (item: MenuItem, pathname: string, currentDirection: string) => {
  const hasSubItems = item.children && item.children.length > 0;
  const isActive = pathname === item.path || 
                  (hasSubItems && item.children?.some((subItem) => 
                    pathname === subItem.path || 
                    (subItem.children?.some((thirdItem) => pathname === thirdItem.path))
                  ));

  if (hasSubItems && item.children) {
    return (
      <Menu 
        key={item.id} 
        trigger="hover" 
        position={currentDirection === 'rtl' ? 'bottom-start' : 'bottom-end'}
      >
        <Menu.Target>
          <UnstyledButton
            className={`
              px-3 py-2 rounded-md
              ${isActive ? 'bg-blue-500 text-white' : 'hover:bg-gray-100 dark:hover:bg-gray-700'}
              flex items-center gap-1
            `}
          >
            {item.meta.icon && <Icon name={item.meta.icon} />}
            <span>{item.name}</span>
            <Icon name="IconChevronDown" size={16} />
          </UnstyledButton>
        </Menu.Target>
        <Menu.Dropdown>
          {item.children.map((subItem) => {
            const hasThirdLevel = subItem.children && subItem.children.length > 0;
            
            if (hasThirdLevel && subItem.children) {
              return (
                <Menu.Item key={subItem.id} component="div">
                  <Menu 
                    trigger="hover" 
                    position={currentDirection === 'rtl' ? 'left' : 'right-start'}
                  >
                    <Menu.Target>
                      <div className="flex items-center justify-between w-full">
                        <div className="flex items-center gap-2">
                          {subItem.meta.icon && <Icon name={subItem.meta.icon} />}
                          <span>{subItem.name}</span>
                        </div>
                        <Icon name="IconChevronDown" size={16} />
                      </div>
                    </Menu.Target>
                    <Menu.Dropdown>
                      {subItem.children.map((thirdItem) => (
                        <Menu.Item
                          key={thirdItem.id}
                          component={Link}
                          href={thirdItem.path || "#"}
                          className={pathname === thirdItem.path ? 'bg-blue-50' : ''}
                        >
                          <div className="flex items-center gap-2">
                            {thirdItem.meta.icon && <Icon name={thirdItem.meta.icon} />}
                            <span>{thirdItem.name}</span>
                          </div>
                        </Menu.Item>
                      ))}
                    </Menu.Dropdown>
                  </Menu>
                </Menu.Item>
              );
            }

            return (
              <Menu.Item
                key={subItem.id}
                component={Link}
                href={subItem.path || "#"}
                className={pathname === subItem.path ? 'bg-blue-50' : ''}
              >
                <div className="flex items-center gap-2">
                  {subItem.meta.icon && <Icon name={subItem.meta.icon} />}
                  <span>{subItem.name}</span>
                </div>
              </Menu.Item>
            );
          })}
        </Menu.Dropdown>
      </Menu>
    );
  }

  return (
    <UnstyledButton
      key={item.id}
      component={Link}
      href={item.path || "#"}
      className={`
        px-3 py-2 rounded-md
        ${isActive ? 'bg-blue-500 text-white' : 'hover:bg-gray-100 dark:hover:bg-gray-700'}
        flex items-center gap-1
      `}
    >
      {item.meta.icon && <Icon name={item.meta.icon} />}
      <span>{item.name}</span>
    </UnstyledButton>
  );
};

export const HorizontalNavigation: FC = () => {
  const pathname = usePathname();
  const currentDirection = getDirection();
  const { colorScheme } = useMantineColorScheme();
  const isDark = colorScheme === 'dark';

  return (
    <nav className={`flex items-center h-full ${currentDirection === 'rtl' ? 'mr-auto' : 'ml-auto'}`}>
      {menuItems.map((item) => renderMenuItem(item, pathname, currentDirection))}
    </nav>
  );
}; 