import type { FC } from 'react';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { UnstyledButton, useMantineColorScheme, useMantineTheme } from '@mantine/core';
import { useDisclosure } from '@mantine/hooks';
import { getDirection } from '@dkd/utils';
import type { SubMenuItem as SubMenuItemType, ThirdLevelMenuItem as ThirdLevelMenuItemType } from '../types/menuItems';
import { Icon } from '../../Components/icons/IconMap';

interface SubMenuItemProps {
  item: SubMenuItemType;
  iconMap: Record<string, React.ReactNode>;
}

const SubMenuItem: FC<SubMenuItemProps> = ({ item }) => {
  const [opened, { toggle }] = useDisclosure(false);
  const pathname = usePathname();
  const currentDirection = getDirection();

  const theme = useMantineTheme();
  const { colorScheme } = useMantineColorScheme();
  
  const hasSubItems = item.children && item.children.length > 0;
  const isActive = pathname === item.path || 
                  (hasSubItems && item.children?.some((thirdItem: ThirdLevelMenuItemType) => pathname === thirdItem.path));

  const handleItemClick = (e: React.MouseEvent) => {
    if (hasSubItems) {
      e.preventDefault();
      toggle();
    }
  };

  return (
    <div>
    <UnstyledButton
      component={Link}
      href={item.path || "#"}
      onClick={handleItemClick}
      className={`
        w-full py-0.5 pr-2 rounded-md text-left text-sm
        ${isActive ? `bg-[${theme.colors[theme.primaryColor][6]}] text-[${theme.colors.gray[0]}]` : `hover:bg-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 6 : 2]}]`}
        focus:ring-2 focus:ring-[${theme.colors[theme.primaryColor][4]}]
        focus:outline-none
      `}
    >
      <div className="flex items-center justify-between">
        <div className="flex items-center gap-2">
          {item.meta.icon && <Icon name={item.meta.icon} />}
          <span>{item.name}</span>
        </div>
        {hasSubItems && (
          <Icon 
            name={currentDirection === 'rtl' ? 'IconChevronLeft' : 'IconChevronRight'}
            size={16}
            style={{
              transform: opened ? (currentDirection === 'rtl' ? 'rotate(-90deg)' : 'rotate(90deg)') : 'none',
              transition: 'transform 200ms ease'
            }}
          />
        )}
      </div>
    </UnstyledButton>
    {hasSubItems && (
      <div className={`
        ${currentDirection === 'rtl' ? 'mr-4' : 'ml-4'}
        -mr-6 pr-2 border-r-2 relative z-10 mt-0 space-y-0
        border-[${theme.colors[colorScheme === 'dark' ? 'gray' : 'gray'][colorScheme === 'dark' ? 4 : 5]}]
        ${opened ? 'block' : 'hidden'}
      `}>
        {item.children?.map((thirdItem: ThirdLevelMenuItemType) => (
          <UnstyledButton
            key={thirdItem.id}
            component={Link}
            href={thirdItem.path || "#"}
            className={`
              w-full py-0.5 pr-2 rounded-md text-left text-xs
              ${pathname === thirdItem.path ? `bg-[${theme.colors[theme.primaryColor][6]}] text-[${theme.colors.gray[0]}]` : `hover:bg-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 6 : 2]}]`}
              focus:ring-2 focus:ring-[${theme.colors[theme.primaryColor][4]}]
              focus:outline-none
            `}
          >
            <div className="flex items-center gap-1.5">
              <span className={`w-1.5 h-1.5 rounded-full bg-[${theme.colors[colorScheme === 'dark' ? 'gray' : 'gray'][colorScheme === 'dark' ? 4 : 6]}]`} />
              <span>{thirdItem.name}</span>
            </div>
          </UnstyledButton>
        ))}
      </div>
    )}
  </div>
  );
};

export default SubMenuItem; 