// import { Text } from '@mantine/core';
// import { appConfig } from '../config/app-config';

// export function Footer() {
//   const currentYear = new Date().getFullYear();

//   return (
// <div className="flex items-center justify-between px-4 py-2 border-t border-gray-200 dark:border-gray-700">
//   <div className="flex items-center gap-1 text-sm text-gray-500 dark:text-gray-400">
//     <Text size="sm" c="dimmed">
//        {appConfig.description}
//     </Text>
//   </div>
//   <div className="text-sm text-gray-500 dark:text-gray-400">
//     <Text size="sm">
//       © {currentYear} {appConfig.name}
//     </Text>
//   </div>
// </div>
//   );
// } 

import { Group, Text, Anchor } from '@mantine/core';
import { IconBrandGithub, IconBrandTwitter } from '@tabler/icons-react';
import { appConfig } from '../config/app-config';
import { SettingsButton } from './settings-button';

export function Footer() {
  const currentYear = new Date().getFullYear();

  return (
    <Group h="100%" px="md" justify="space-between" wrap="wrap">
      <Text size="sm" c="dimmed">
        © {currentYear} {appConfig.name}
      </Text>
      <Group gap="xs">
        <Anchor href="https://github.com" target="_blank" size="sm">
          <IconBrandGithub size={18} />
        </Anchor>
        <Anchor href="https://twitter.com" target="_blank" size="sm">
          <IconBrandTwitter size={18} />
        </Anchor>
        <SettingsButton />
      </Group>
    </Group>
  );
} 