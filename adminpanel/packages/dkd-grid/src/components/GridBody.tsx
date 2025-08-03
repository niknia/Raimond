import type { ReactElement } from 'react';
import { Box, Center, Loader, Text, type CSSProperties } from '@mantine/core';
import type { Table, Row } from '@tanstack/react-table';
import { flexRender } from '@tanstack/react-table';
import type { DkdGridTheme } from '../theme/types';


interface GridBodyProps<T extends object> {
  table: Table<T>;
  theme: DkdGridTheme;
  isLoading?: boolean;
  error?: string;
  selectedRowId?: string;
  onRowClick?: (row: Row<T>) => void;
  idField?: keyof T;
}

export function GridBody<T extends object>({
  table,
  theme,
  isLoading = false,
  error,
  selectedRowId,
  onRowClick,
  idField = 'id' as keyof T,
}: GridBodyProps<T>): ReactElement {
  const { colors, typography, spacing, layout } = theme;
  
  
  

  if (isLoading) {
    return (
      <Center style={{ height: '200px' }}>
        <Loader />
      </Center>
    );
  }

  if (error) {
    return (
      <Center style={{ height: '200px' }}>
        <Text style={{ color: colors.error }}>
          {layout.direction === 'rtl' ? `خطا: ${error}` : `Error: ${error}`}
        </Text>
      </Center>
    );
  }

  const rows = table.getRowModel().rows;
  console.log('rows',rows)
  if (rows.length === 0) {
    return (
      <Center style={{ height: '200px' }}>
        <Text>
          {layout.direction === 'rtl' ? 'داده‌ای یافت نشد' : 'No data found'}
        </Text>
      </Center>
    );
  }

  const totalWidth = table.getTotalSize();
  const containerStyle: CSSProperties = {
    minWidth: totalWidth,
    width: '100%',
    position: 'relative',
    direction: layout.direction,
    overflowY: 'auto',
    overflowX: 'auto',
  };

  const getCellStyle = (cell: any, rowIndex: number): CSSProperties => {
    const isActionColumn = cell.column.id === 'actions';
    const isRTL = layout.direction === 'rtl';
    const isSelected = selectedRowId === cell.row.original[idField];
    const isEvenRow = rowIndex % 2 === 0;
    const baseFontSize = typeof typography.cellFontSize === 'string' 
      ? Number.parseInt(typography.cellFontSize, 10)
      : typography.cellFontSize;
    
    const baseStyle: CSSProperties = {
      color: isSelected ? colors.row.selectedText : colors.row.text,
      borderRight: `1px solid ${isSelected ? colors.row.selectedBorder : colors.row.border}`,
      padding: spacing.padding,
      height: spacing.rowHeight,
      display: 'flex',
      alignItems: 'center',
      justifyContent: isRTL ? 'flex-end' : 'flex-start',
      width: cell.column.getSize(),
      minWidth: layout.minColumnWidth,
      maxWidth: layout.maxColumnWidth,
      fontFamily: isRTL ? typography.fontFamily.rtl : typography.fontFamily.ltr,
      fontSize: isSelected ? `${baseFontSize + 2}px` : typography.cellFontSize,
      flexShrink: 0,
      whiteSpace: 'nowrap',
      overflow: 'hidden',
      textOverflow: 'ellipsis',
      boxSizing: 'border-box',
      fontWeight: isSelected ? 600 : 400,
    };

    if (isActionColumn && isRTL) {
      return {
        ...baseStyle,
        position: 'sticky',
        right: 0,
        background: isSelected 
          ? colors.row.selectedBackground 
          : isEvenRow 
            ? colors.row.background 
            : colors.row.alternateBackground,
        zIndex: 1,
        borderRight: 'none',
        borderLeft: `1px solid ${isSelected ? colors.row.selectedBorder : colors.row.border}`,
      };
    }

    return baseStyle;
  };

  return (
    <Box style={containerStyle}>
      {rows.map((row, index) => {
        const isSelected = selectedRowId === row.original[idField];
        return (
          <Box
            key={String(row.original[idField])}
            className="grid-row"
            style={{
              display: 'flex',
              direction: layout.direction,
              background: isSelected
                ? colors.row.selectedBackground 
                : index % 2 === 0 
                  ? colors.row.background 
                  : colors.row.alternateBackground,
              borderBottom: `1px solid ${isSelected ? colors.row.selectedBorder : colors.row.border}`,
              cursor: onRowClick ? 'pointer' : 'default',
              transition: 'all 0.2s ease',
              boxShadow: isSelected ? '0 2px 4px rgba(0,0,0,0.1)' : 'none',
              '&:hover': {
                background: colors.row.hoverBackground,
              },
            }}
            onClick={() => onRowClick?.(row)}
          >
            {row.getVisibleCells().map(cell => (
              <Box
                key={cell.id}
                style={getCellStyle(cell, index)}
              >
                {flexRender(cell.column.columnDef.cell, cell.getContext())}
              </Box>
            ))}
          </Box>
        );
      })}
      
    </Box>
  );
} 