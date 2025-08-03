import type { ReactElement } from 'react';
import { Group, ActionIcon } from '@mantine/core';
import { IconEdit, IconTrash, IconPlus } from '@tabler/icons-react';
import type { DkdGridTheme } from '../theme/types';

interface ActionColumnProps<T extends object> {
  row: T;
  onEdit?: () => void;
  onDelete?: () => void;
  onAdd?: () => void;
  rtl?: boolean;
  theme: DkdGridTheme;
}

export function ActionColumn<T extends object>({
  onEdit,
  onDelete,
  onAdd,
  rtl = false,
  theme,
}: ActionColumnProps<T>): ReactElement {
  
  return (
    <Group gap={4} justify={rtl ? 'flex-end' : 'flex-start'}>
      {onEdit && (
        <ActionIcon
          size="sm"
          variant="subtle"
          onClick={(e) => {
            e.stopPropagation();
            onEdit();
          }}
          title={rtl ? 'ویرایش' : 'Edit'}
        >
          <IconEdit size={16} />
        </ActionIcon>
      )}
      {onDelete && (
        <ActionIcon
          size="sm"
          variant="subtle"
          color="red"
          onClick={(e) => {
            e.stopPropagation();
            onDelete();
          }}
          title={rtl ? 'حذف' : 'Delete'}
        >
          <IconTrash size={16} />
        </ActionIcon>
      )}
      {onAdd && (
        <ActionIcon
          size="sm"
          variant="subtle"
          color="green"
          onClick={(e) => {
            e.stopPropagation();
            onAdd();
          }}
          title={rtl ? 'افزودن' : 'Add'}
        >
          <IconPlus size={16} />
        </ActionIcon>
      )}
    </Group>
  );
} 