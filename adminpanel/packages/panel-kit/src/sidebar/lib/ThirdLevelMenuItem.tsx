import type { FC } from 'react';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { UnstyledButton, useMantineColorScheme, useMantineTheme } from '@mantine/core';

import type { ThirdLevelMenuItem as ThirdLevelMenuItemType } from '../types/menuItems';

interface ThirdLevelMenuItemProps {
  item: ThirdLevelMenuItemType;
  collapsed: boolean;
}

const ThirdLevelMenuItem: FC<ThirdLevelMenuItemProps> = ({ item, collapsed }) => {
  const pathname = usePathname();
  const theme = useMantineTheme();
  const { colorScheme } = useMantineColorScheme();
  const isActive = pathname === item.path;
  
  if (collapsed) return null;

  return (
    <li className="list-none">
      <UnstyledButton
        component={Link}
        href={item.path || "#"}
        className={`
          w-full p-2 rounded-md text-left ml-6 mb-1 text-xs
          ${isActive ? `bg-[${theme.colors[theme.primaryColor][6]}] text-[${theme.colors.gray[0]}]` : `hover:bg-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 6 : 2]}]`}
          focus:ring-2 focus:ring-[${theme.colors[theme.primaryColor][4]}]
          focus:outline-none
        `}
      >
        <div className="flex items-center gap-2">
          <span className={`text-xl font-bold text-[${theme.colors[colorScheme === 'dark' ? 'gray' : 'gray'][colorScheme === 'dark' ? 5 : 6]}]`}>•</span>
          <span>{item.name}</span>
        </div>
      </UnstyledButton>
    </li>
  );
};

export default ThirdLevelMenuItem;