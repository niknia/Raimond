import type { FC, ReactNode } from 'react';
import Link from 'next/link';
import { UnstyledButton, useMantineColorScheme, useMantineTheme } from '@mantine/core';
import { getDirection } from '@dkd/utils';

interface MenuButtonProps {
  href?: string;
  onClick?: (e: React.MouseEvent) => void;
  isActive?: boolean;
  children: ReactNode;
  className?: string;
}

const MenuButton: FC<MenuButtonProps> = ({ 
  href, 
  onClick, 
  isActive = false, 
  children, 
  className = '' 
}) => {
  const { colorScheme } = useMantineColorScheme();
  const theme = useMantineTheme();

  const baseClasses = `
    w-full p-2 rounded-md text-left mb-1
    ${isActive ? `bg-[${theme.colors[theme.primaryColor][6]}] text-[${theme.colors.gray[0]}]` : `hover:bg-[${theme.colors[colorScheme === 'dark' ? 'dark' : 'gray'][colorScheme === 'dark' ? 6 : 2]}]`}
    focus:ring-2 focus:ring-[${theme.colors[theme.primaryColor][4]}]
    focus:outline-none
    ${className}
  `;

  if (href) {
    return (
      <UnstyledButton
        component={Link}
        href={href}
        onClick={onClick}
        className={baseClasses}
      >
        {children}
      </UnstyledButton>
    );
  }

  return (
    <UnstyledButton
      onClick={onClick}
      className={baseClasses}
    >
      {children}
    </UnstyledButton>
  );
};

export default MenuButton; 