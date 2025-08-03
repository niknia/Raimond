import { Box } from '@mantine/core';
import { type Cell, flexRender } from '@tanstack/react-table';
import type { DkdGridTheme } from '../theme/types';

interface GridCellProps<T> {
  cell: Cell<T, unknown>;
  theme: DkdGridTheme;
  isSelected?: boolean;
  onClick?: () => void;
}

export function GridCell<T>({ 
  cell, 
  theme, 
  isSelected = false,
  onClick 
}: GridCellProps<T>) {
  const { colors, typography, spacing, layout } = theme;
  const isRTL = layout.direction === 'rtl';
  const isActionColumn = cell.column.id === 'actions';
  
  return (
    <Box
      style={{
        background: isSelected ? colors.row.selectedBackground : colors.row.background,
        color: colors.row.text,
        borderBottom: `1px solid ${colors.row.border}`,
        borderRight: `1px solid ${colors.row.border}`,
        padding: spacing.padding,
        fontSize: typography.cellFontSize,
        cursor: onClick ? 'pointer' : 'default',
        height: spacing.rowHeight,
        display: 'flex',
        alignItems: 'center',
        justifyContent: isRTL ? 'flex-end' : 'flex-start',
        transition: 'background-color 0.2s ease',
        width: cell.column.getSize(),
        minWidth: layout.minColumnWidth,
        maxWidth: layout.maxColumnWidth,
        boxSizing: 'border-box',
        position: isActionColumn && isRTL ? 'sticky' : 'relative',
        left: isActionColumn && isRTL ? 0 : 'auto',
        zIndex: isActionColumn && isRTL ? 1 : 'auto',
        '&:hover': {
          background: colors.row.hoverBackground,
        },
      }}
      onClick={onClick}
    >
      {flexRender(cell.column.columnDef.cell, cell.getContext())}
    </Box>
  );
} 