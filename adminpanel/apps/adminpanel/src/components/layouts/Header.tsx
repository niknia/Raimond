import { Group, Box, ActionIcon, UnstyledButton, Menu, Avatar, Text, rem } from '@mantine/core';
import { IconSun, IconMoon, IconChevronDown, IconSettings, IconLogout, IconMenu2 } from '@tabler/icons-react';
import { useDisclosure } from '@mantine/hooks';
import { useMantineColorScheme } from '@mantine/core';
import { useEffect, useState } from 'react';
import { useAuth } from '@/providers/AuthContext';
import { useRouter } from 'next/router';
import { useAppShell } from '@dkd/panel-kit';
import { useAccountQueries } from '@/data/account/account.query';

interface HeaderProps {
  toggleSidebar: () => void;
  isSidebarCollapsed: boolean;
  toggleCollapsed: () => void;
}

export function Header({ toggleSidebar, isSidebarCollapsed, toggleCollapsed }: HeaderProps) {
  const { colorScheme, setColorScheme } = useMantineColorScheme();
  const [mounted, setMounted] = useState(false);
  const [isMobile, setIsMobile] = useState(false);
  const { logout, isAuthenticated } = useAuth();
  const router = useRouter();
  const { useProfile } = useAccountQueries();
  const { data: profile } = useProfile();

  // تشخیص mobile/desktop
  useEffect(() => {
    const checkIsMobile = () => {
      setIsMobile(window.innerWidth < 768);
    };
    
    checkIsMobile();
    window.addEventListener('resize', checkIsMobile);
    
    return () => window.removeEventListener('resize', checkIsMobile);
  }, []);

  // Only show theme toggle after component is mounted
  useEffect(() => {
    setMounted(true);
  }, []);

  const [user, setUser] = useState({
    name: '11شرکت آدفا',
    email: 'john@example.com',
    image: 'https://i.pravatar.cc/150?img=1',
  });

  useEffect(() => {
    if (profile && profile.result && typeof profile.result === 'object') {
      const profileData = profile.result as any;
      
      setUser(prev => {
        const newUser = {
          ...prev,
          name: profileData.name ?? prev.name,
          email: profileData.email ?? prev.email,
          // image: profileData.avatar ?? prev.image,
        };
        return newUser;
      });
    }
  }, [profile]);

  return (
    <>  
     {/* این بخش سمت راست خواهد بود */}
      <Group gap="xs">
        {mounted && (
          <ActionIcon
            variant="default"
            onClick={() => setColorScheme(colorScheme === 'dark' ? 'light' : 'dark')}
            size="lg"
          >
            {colorScheme === 'dark' ? <IconSun size={20} /> : <IconMoon size={20} />}
          </ActionIcon>
        )}
        <Menu
          width={260}
          position="bottom-end"
          transitionProps={{ transition: 'pop-top-right' }}
          withinPortal
        >
          <Menu.Target>
            <UnstyledButton>
              <Group gap={7}>
                <Avatar src={user.image} alt={user.name} radius="xl" size={20} />
                <Text fw={500} size="sm" lh={1} mr={3}>
                  {user.name}
                </Text>
                <IconChevronDown style={{ width: rem(12), height: rem(12) }} stroke={1.5} />
              </Group>
            </UnstyledButton>
          </Menu.Target>
          <Menu.Dropdown>
            <Menu.Item
              leftSection={
                <IconSettings style={{ width: rem(16), height: rem(16) }} stroke={1.5} />
              }
            >
              تنظیمات
            </Menu.Item>
            <Menu.Item
              leftSection={
                <IconLogout style={{ width: rem(16), height: rem(16) }} stroke={1.5} />
              }
              onClick={async e => {
                await logout();
                router.push('/login');
              }}
            >
              خروج
            </Menu.Item>
          </Menu.Dropdown>
        </Menu>
      </Group>
    </>
  );
} 