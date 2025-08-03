import { type ReactElement, useState } from 'react';
import { Box, Group, type CSSProperties } from '@mantine/core';
import type { Table, Header } from '@tanstack/react-table';
import { flexRender } from '@tanstack/react-table';
import { IconArrowsSort, IconFilter } from '@tabler/icons-react';
import type { DkdGridTheme } from '../theme/types';

interface GridHeaderProps<T extends object> {
  table: Table<T>;
  theme: DkdGridTheme;
  header: Header<T, unknown>;
}

export function GridHeader<T extends object>({ table, theme, header }: GridHeaderProps<T>): ReactElement | null {
  const { colors, typography, spacing, layout } = theme;
  const [isResizing, setIsResizing] = useState(false);

  if (!header) return null;

  const headerStyle: CSSProperties = {
    position: 'relative',
    color: colors.header.text,
    borderRight: `1px solid ${colors.header.border}`,
    padding: spacing.padding,
    height: spacing.headerHeight,
    display: 'flex',
    alignItems: 'center',
    width: header.getSize(),
    minWidth: layout.minColumnWidth,
    maxWidth: layout.maxColumnWidth,
    fontFamily: layout.direction === 'rtl' ? typography.fontFamily.rtl : typography.fontFamily.ltr,
    fontSize: typography.headerFontSize,
    fontWeight: typography.headerFontWeight,
    flexShrink: 0,
    userSelect: 'none',
    cursor: header.column.getCanSort() ? 'pointer' : 'default',
    whiteSpace: 'nowrap',
    overflow: 'hidden',
    boxSizing: 'border-box',
    background: colors.header.background,
  };

  const isActionColumn = header.column.id === 'actions';
  if (isActionColumn && layout.direction === 'rtl') {
    headerStyle.position = 'sticky';
    headerStyle.right = 0;
    headerStyle.zIndex = 2;
  }

  return (
    <Box
      style={headerStyle}
      onClick={() => header.column.getCanSort() && header.column.toggleSorting()}
    >
      <Group w="100%" justify="space-between" gap={4} style={{ boxSizing: 'border-box' }}>
        <Box style={{ flexGrow: 1, overflow: 'hidden', textOverflow: 'ellipsis' }}>
          {flexRender(header.column.columnDef.header, header.getContext())}
        </Box>
        <Group gap={4}>
          {header.column.getCanSort() && <IconArrowsSort size={14} />}
          {header.column.getCanFilter() && <IconFilter size={14} />}
        </Group>
      </Group>
      {header.column.getCanResize() && (
        <Box
          style={{
            position: 'absolute',
            [layout.direction === 'rtl' ? 'left' : 'right']: 0,
            top: 0,
            height: '100%',
            width: '4px',
            cursor: 'col-resize',
            userSelect: 'none',
            touchAction: 'none',
            background: isResizing ? colors.header.resizer : 'transparent',
            '&:hover': {
              background: colors.header.resizerHover,
            },
            zIndex: 3,
          }}
          onMouseDown={(e) => {
            e.preventDefault();
            setIsResizing(true);
            const startX = e.pageX;
            const startWidth = header.getSize();

            const onMouseMove = (e: MouseEvent) => {
              const diff = layout.direction === 'rtl' ? startX - e.pageX : e.pageX - startX;
              table.setColumnSizing((old) => ({
                ...old,
                [header.column.id]: Math.max(layout.minColumnWidth, startWidth + diff),
              }));
            };

            const onMouseUp = () => {
              setIsResizing(false);
              document.removeEventListener('mousemove', onMouseMove);
              document.removeEventListener('mouseup', onMouseUp);
            };

            document.addEventListener('mousemove', onMouseMove);
            document.addEventListener('mouseup', onMouseUp);
          }}
        />
      )}
    </Box>
  );
} 