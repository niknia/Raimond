import React from 'react';
import { Box } from '@mantine/core';
import type { Row } from '@tanstack/react-table';
import type { DkdGridTheme } from '../theme/types';
import { GridCell } from './GridCell';

interface GridRowProps<T> {
  row: Row<T>;
  theme: DkdGridTheme;
  isSelected?: boolean;
  onRowClick?: (row: Row<T>) => void;
}

export function GridRow<T>({ 
  row, 
  theme, 
  isSelected = false,
  onRowClick 
}: GridRowProps<T>) {
  const cells = row.getVisibleCells();
  const isRTL = theme.layout.direction === 'rtl';
  
  // If RTL, reverse the cells array to match header order
  const orderedCells = isRTL ? [...cells].reverse() : cells;

  return (
    <Box
      style={{
        display: 'flex',
        flexDirection: isRTL ? 'row-reverse' : 'row',
        width: '100%',
      }}
    >
      {orderedCells.map((cell) => (
        <GridCell
          key={cell.id}
          cell={cell}
          theme={theme}
          isSelected={isSelected}
          onClick={onRowClick ? () => onRowClick(row) : undefined}
        />
      ))}
    </Box>
  );
} 