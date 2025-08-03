import type { FC } from 'react';
import { Collapse, UnstyledButton, useMantineColorScheme, useMantineTheme } from '@mantine/core';
import { useDisclosure } from '@mantine/hooks';
import { getDirection } from '@dkd/utils';
import { IconChevronLeft, IconChevronRight } from '@tabler/icons-react';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { Icon } from '../../../Components/icons/IconMap';
import type { MenuItem, SubMenuItem } from '../types/menuItems';
import SubMenuItemComponent from '../SubMenuItem';
import { useMenuStyles } from '../hooks/useMenuStyles';

interface ExpandedMenuItemProps {
  item: MenuItem;
}

const ExpandedMenuItem: FC<ExpandedMenuItemProps> = ({ item }) => {
  const [opened, { toggle }] = useDisclosure(false);
  const pathname = usePathname();
  const currentDirection = getDirection();
  const { getActiveStyles, getBorderColor, theme } = useMenuStyles();

  const hasSubItems = item.children && item.children.length > 0;
  const isActive = pathname === item.path || 
                  (hasSubItems && item.children?.some((subItem: SubMenuItem) => 
                    pathname === subItem.path || 
                    (subItem.children?.some((thirdItem) => pathname === thirdItem.path))
                  ));

  const handleItemClick = (e: React.MouseEvent) => {
    if (hasSubItems) {
      e.preventDefault();
      toggle();
    }
  };

  return (
    <li className="list-none">
      <div className="relative">
        <UnstyledButton
          component={Link}
          href={item.path || "#"}
          onClick={handleItemClick}
          className={`
            w-full py-0.5 pr-2 rounded-md text-left
            ${getActiveStyles(isActive)}
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
              currentDirection === 'rtl' ? (
                <IconChevronLeft 
                  size={16}
                  style={{
                    transform: opened ? 'rotate(-90deg)' : 'none',
                    transition: 'transform 200ms ease'
                  }}
                />
              ) : (
                <IconChevronRight 
                  size={16}
                  style={{
                    transform: opened ? 'rotate(90deg)' : 'none',
                    transition: 'transform 200ms ease'
                  }}
                />
              )
            )}
          </div>
        </UnstyledButton>
        {hasSubItems && (
          <Collapse in={opened}>
            <div className={`${currentDirection === 'rtl' ? 'pr-1 mr-4 border-r-2 relative z-10' : 'pl-8 border-l-2'} space-y-0 ${getBorderColor()}`}>
              {item.children?.map((subItem: SubMenuItem) => (
                <SubMenuItemComponent key={subItem.id} item={subItem} iconMap={{}} />
              ))}
            </div>
          </Collapse>
        )}
      </div>
    </li>
  );
};

export default ExpandedMenuItem; 