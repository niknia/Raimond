import type { FC } from 'react';
import { Text, UnstyledButton, useMantineColorScheme, useMantineTheme } from '@mantine/core';
import { usePathname } from 'next/navigation';
import Link from 'next/link';
import { Icon } from '../../../Components/icons/IconMap';
import type { SubMenuItem, ThirdLevelMenuItem } from '../types/menuItems';
import ThirdLevelMenu from './ThirdLevelMenu';

interface PopoverSubMenuProps {
  item: SubMenuItem;
  direction: 'ltr' | 'rtl';
}

const PopoverSubMenu: FC<PopoverSubMenuProps> = ({ item, direction }) => {
  const pathname = usePathname();
  const { colorScheme } = useMantineColorScheme();
  const theme = useMantineTheme();

  if (!item.children) {
    return (
      <UnstyledButton
        component={Link}
        href={item.path || "#"}
        className={`
          w-full py-2 px-2 rounded-md text-left
          ${pathname === item.path ? `bg-[${theme.colors[theme.primaryColor][6]}] text-[${theme.colors.gray[0]}]` : `hover:bg-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 6 : 2]}]`}
          focus:ring-2 focus:ring-[${theme.colors[theme.primaryColor][4]}]
          focus:outline-none
        `}
      >
        <div className="flex items-center gap-2">
          {item.meta.icon && <Icon name={item.meta.icon} />}
          <span>{item.name}</span>
        </div>
      </UnstyledButton>
    );
  }

  return (
    <div>
      <UnstyledButton
        className={`
          w-full py-2 px-2 rounded-md
          ${pathname === item.path ? `bg-[${theme.colors[theme.primaryColor][6]}] text-[${theme.colors.gray[0]}]` : `hover:bg-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 6 : 2]}]`}
          flex items-center justify-between
          focus:ring-2 focus:ring-[${theme.colors[theme.primaryColor][4]}]
          focus:outline-none
        `}
        onClick={() => {
          const subItemElement = document.getElementById(`submenu-${item.id}`);
          if (subItemElement) {
            subItemElement.classList.toggle('hidden');
          }
        }}
      >
        <div className="flex items-center gap-2">
          {item.meta.icon && <Icon name={item.meta.icon} />}
          <span>{item.name}</span>
        </div>
        {direction === 'rtl' ? (
          <Icon 
            name="IconChevronLeft"
            size={16}
            className={`
              transition-transform duration-200
              ${document.getElementById(`submenu-${item.id}`)?.classList.contains('hidden') ? '' : 'rotate-90'}
            `}
          />
        ) : (
          <Icon 
            name="IconChevronRight"
            size={16}
            className={`
              transition-transform duration-200
              ${document.getElementById(`submenu-${item.id}`)?.classList.contains('hidden') ? '' : 'rotate-90'}
            `}
          />
        )}
      </UnstyledButton>
      <div 
        id={`submenu-${item.id}`}
        className="hidden"
      >
        <ThirdLevelMenu items={item.children} direction={direction} />
      </div>
    </div>
  );
};

export default PopoverSubMenu; 