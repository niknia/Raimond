import type { FC } from 'react';
import { Popover, UnstyledButton, Text, useMantineColorScheme, useMantineTheme } from '@mantine/core';
import { useDisclosure } from '@mantine/hooks';
import { getDirection } from '@dkd/utils';
import { Icon } from '../../../Components/icons/IconMap';
import type { MenuItem, SubMenuItem } from '../types/menuItems';
import PopoverSubMenu from './PopoverSubMenu';
import { useMenuStyles } from '../hooks/useMenuStyles';

interface CollapsedMenuItemProps {
  item: MenuItem;
}

const CollapsedMenuItem: FC<CollapsedMenuItemProps> = ({ item }) => {
  const [opened, { toggle }] = useDisclosure(false);
  const currentDirection = getDirection();
  const { getPopoverStyles, getActiveStyles, colorScheme, theme } = useMenuStyles();

  const hasSubItems = item.children && item.children.length > 0;

  if (!hasSubItems) {
    return null;
  }

  return (
    <li className="list-none">
      <Popover 
        position={currentDirection === 'rtl' ? 'right' : 'left'}
        withArrow 
        shadow="md"
        offset={0}
        positionDependencies={[opened]}
        withinPortal={false}
        classNames={{
          dropdown: `
            ${getPopoverStyles()}
            p-2
            min-w-[200px]
            mt-0
            ${currentDirection === 'rtl' ? 'mr-0' : 'ml-0'}
            transform transition-transform duration-200 ease-in-out
            ${opened ? 'translate-y-0' : '-translate-y-2 opacity-0'}
          `
        }}
      >
        <Popover.Target>
          <UnstyledButton
            className={`
              w-full py-0.5 pr-2 rounded-md
              ${getActiveStyles(false)}
              flex justify-center items-center
              relative
              focus:ring-2 focus:ring-[${theme.colors[theme.primaryColor][4]}]
              focus:outline-none
            `}
            onClick={toggle}
          >
            {item.meta.icon && <Icon name={item.meta.icon} />}
            {opened && (
              <div className={`
                absolute ${currentDirection === 'rtl' ? 'left-0' : 'right-0'}
                top-1/2 -translate-y-1/2
                w-1 h-1 rounded-full
                bg-[${theme.colors[colorScheme === 'dark' ? 'gray' : 'gray'][colorScheme === 'dark' ? 4 : 6]}]
              `} />
            )}
          </UnstyledButton>
        </Popover.Target>
        <Popover.Dropdown>
          <div className="space-y-0">
            <Text fw={600} size="sm" className="mb-2">{item.name}</Text>
            <ul className="space-y-0">
              {item.children?.map((subItem: SubMenuItem) => (
                <li key={subItem.id}>
                  <PopoverSubMenu item={subItem} direction={currentDirection} />
                </li>
              ))}
            </ul>
          </div>
        </Popover.Dropdown>
      </Popover>
    </li>
  );
};

export default CollapsedMenuItem; 