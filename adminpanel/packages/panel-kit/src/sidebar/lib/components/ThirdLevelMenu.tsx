import type { FC } from 'react';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { UnstyledButton, useMantineColorScheme, useMantineTheme } from '@mantine/core';
import type { ThirdLevelMenuItem } from '../types/menuItems';

interface ThirdLevelMenuProps {
  items: ThirdLevelMenuItem[];
  direction: 'ltr' | 'rtl';
}

const ThirdLevelMenu: FC<ThirdLevelMenuProps> = ({ items, direction }) => {
  const pathname = usePathname();
  const { colorScheme } = useMantineColorScheme();
  const theme = useMantineTheme();

  return (
    <ul className={`
      ${direction === 'rtl' ? 'mr-4' : 'ml-4'}
      -mr-6 pr-2 border-r-2 relative z-10 mt-0 space-y-0
      border-[${theme.colors[colorScheme === 'dark' ? 'gray' : 'gray'][colorScheme === 'dark' ? 4 : 5]}]
    `}>
      {items.map((item) => (
        <li key={item.id}>
          <UnstyledButton
            component={Link}
            href={item.path || "#"}
            className={`
              w-full py-0.5 pr-2 rounded-md text-left text-xs
              ${pathname === item.path ? `bg-[${theme.colors[theme.primaryColor][6]}] text-[${theme.colors.gray[0]}]` : `hover:bg-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 6 : 2]}]`}
              focus:ring-2 focus:ring-[${theme.colors[theme.primaryColor][4]}]
              focus:outline-none
            `}
          >
            <div className="flex items-center gap-1.5">
              <span className={`w-1.5 h-1.5 rounded-full bg-[${theme.colors[colorScheme === 'dark' ? 'gray' : 'gray'][colorScheme === 'dark' ? 4 : 6]}]`} />
              <span>{item.name}</span>
            </div>
          </UnstyledButton>
        </li>
      ))}
    </ul>
  );
};

export default ThirdLevelMenu; 