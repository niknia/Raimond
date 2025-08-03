import type { MantineThemeComponents } from '@mantine/core'
import { ThemedActionIcon } from './action-icon'
import { ThemedAvatar } from './avatar'
import { ThemedButton } from './button'
import { ThemedCard } from './card'
import { ThemedCollapse } from './collapse'
import { ThemedInput } from './input'
import { ThemedPopover } from './popover'
import { ThemedScrollArea } from './scroll-area'
import { ThemedTooltip } from './tooltip'
import { ThemedAppShell } from './appshell'
import { ThemedTitle } from './Title'
import { ThemedTextInput } from './TextInput'
import { ThemedPasswordInput } from './PasswordInput'

export const ThemeComponentsOverrides: MantineThemeComponents = {
  Button: ThemedButton,
  Input: ThemedInput,
  ActionIcon: ThemedActionIcon,
  Avatar: ThemedAvatar,
  ScrollArea: ThemedScrollArea,
  Card: ThemedCard,
  Popover: ThemedPopover,
  Collapse: ThemedCollapse,
  Tooltip: ThemedTooltip,
  AppShell: ThemedAppShell,
  Title: ThemedTitle,
  PasswordInput: ThemedPasswordInput,
  TextInput: ThemedTextInput
}
