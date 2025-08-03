import React, { useEffect, useRef } from 'react';
import { Box, Paper, type CSSProperties } from '@mantine/core';
import {
  useReactTable,
  getCoreRowModel,
  getSortedRowModel,
  getFilteredRowModel,
  getPaginationRowModel,
} from '@tanstack/react-table';
import type {
  ColumnDef,
  Row,
  SortingState,
  VisibilityState,
  ColumnSizingState,
} from '@tanstack/react-table';
import type { DkdGridTheme } from '../theme/types';
import { GridHeader } from './GridHeader';
import { GridBody } from './GridBody';
import { GridPagination } from './GridPagination';
import { ActionColumn } from './ActionColumn';
import { createDefaultTheme } from '../theme/default-theme';
import { useMantineTheme } from '@mantine/core';



export interface DkdGridProps<T extends object> {
  columns: ColumnDef<T>[];
  data: T[];
  isLoading?: boolean;
  error?: string;
  theme?: Partial<DkdGridTheme>;
  rtl?: boolean;
  height?: number | string;
  maxHeight?: number | string;
  onRowClick?: (row: Row<T>) => void;
  onEdit?: (row: T) => void;
  onDelete?: (row: T) => void;
  onAdd?: () => void;
  selectedRowId?: string;
  initialPageSize?: number;
  pinActionColumn?: boolean;
  idField?: keyof T;
  onExport?: () => void;
  onAdvancedSearch?: () => void;
  onReportBuilder?: () => void;
  onDocumentation?: () => void;
  onVideoTutorials?: () => void;
  onLiveChat?: () => void;
  onFeedback?: () => void;
  onHelp?: () => void;
}

export function DkdGrid<T extends object>({
  columns,
  data,
  isLoading = false,
  error,
  theme: customTheme,
  rtl = false,
  height = 400,
  maxHeight = '100vh',
  onRowClick,
  onEdit,
  onDelete,
  onAdd,
  selectedRowId,
  initialPageSize = 10,
  pinActionColumn = true,
  idField = 'id' as keyof T,
  onExport,
  onAdvancedSearch,
  onReportBuilder,
  onDocumentation,
  onVideoTutorials,
  onLiveChat,
  onFeedback,
  onHelp,
}: DkdGridProps<T>) {
  const [sorting, setSorting] = React.useState<SortingState>([]);
  const [columnVisibility, setColumnVisibility] = React.useState<VisibilityState>({});
  const [columnSizing, setColumnSizing] = React.useState<ColumnSizingState>({});
  const [pageIndex, setPageIndex] = React.useState(0);
  const [pageSize, setPageSize] = React.useState(initialPageSize);
  const containerRef = useRef<HTMLDivElement>(null);
  const mantineTheme = useMantineTheme();
   
  
  
  const theme = React.useMemo(() => {
    const defaultTheme = createDefaultTheme(mantineTheme);
    const direction = rtl ? 'rtl' as const : 'ltr' as const;
    return {
      ...defaultTheme,
      ...customTheme,
      layout: {
        ...defaultTheme.layout,
        direction,
        ...customTheme?.layout,
      },
    } as DkdGridTheme;
  }, [mantineTheme, customTheme, rtl]);

  const columnsWithActions = React.useMemo(() => {
    if (!onEdit && !onDelete && !onAdd) return columns;
    
    // Check if action column already exists
    const hasActionColumn = columns.some(col => col.id === 'actions');
    if (hasActionColumn) return columns;
    
    const actionColumn: ColumnDef<T> = {
      id: 'actions',
      header: theme.layout.direction === 'rtl' ? 'عملیات' : 'Actions',
      size: 150,
      cell: ({ row }) => (
        <ActionColumn
          row={row.original}
          onEdit={onEdit ? () => onEdit(row.original) : undefined}
          onDelete={onDelete ? () => onDelete(row.original) : undefined}
          onAdd={onAdd}
          rtl={theme.layout.direction === 'rtl'}
          theme={theme}
        />
      ),
    };

    return theme.layout.direction === 'rtl'
      ? [actionColumn, ...columns]
      : [...columns, actionColumn];
  }, [columns, onEdit, onDelete, onAdd, theme]);

  const table = useReactTable({
    data,
    columns: columnsWithActions,
    state: {
      sorting,
      columnVisibility,
      columnSizing,
      pagination: { pageIndex, pageSize },
    },
    onSortingChange: setSorting,
    onColumnVisibilityChange: setColumnVisibility,
    onColumnSizingChange: setColumnSizing,
    getCoreRowModel: getCoreRowModel(),
    getSortedRowModel: getSortedRowModel(),
    getFilteredRowModel: getFilteredRowModel(),
    getPaginationRowModel: getPaginationRowModel(),
    enableSorting: true,
    enableFilters: true,
    columnResizeMode: 'onChange',
  });

  useEffect(() => {
    if (containerRef.current) {
      containerRef.current.focus();
    }
  }, []);

  const handleKeyPress = (e: React.KeyboardEvent) => {
    const rows = table.getRowModel().rows;
    const currentIndex = rows.findIndex(row => row.original[idField] === selectedRowId);
    const bodyElement = containerRef.current?.querySelector('[data-grid-body]');
    
    const scrollToRow = (index: number) => {
      if (bodyElement) {
        const rowElements = bodyElement.getElementsByClassName('grid-row');
        const rowElement = rowElements[index] as HTMLElement;
        
        if (rowElement) {
          const containerRect = bodyElement.getBoundingClientRect();
          const rowRect = rowElement.getBoundingClientRect();
          const rowHeight = rowRect.height;
          
          // If row is below viewport
          if (rowRect.bottom > containerRect.bottom) {
            bodyElement.scrollTop += rowRect.bottom - containerRect.bottom + rowHeight;
          }
          // If row is above viewport
          else if (rowRect.top < containerRect.top) {
            bodyElement.scrollTop -= containerRect.top - rowRect.top + rowHeight;
          }

          // Ensure row is visible after scrolling
          setTimeout(() => {
            rowElement.scrollIntoView({ block: 'nearest', behavior: 'smooth' });
          }, 0);
        }
      }
    };
    
    switch (e.key) {
      case 'ArrowUp':
        e.preventDefault(); // Prevent default scroll
        if (currentIndex > 0) {
          onRowClick?.(rows[currentIndex - 1]);
          scrollToRow(currentIndex - 1);
        }
        break;
      case 'ArrowDown':
        e.preventDefault(); // Prevent default scroll
        if (currentIndex < rows.length - 1) {
          onRowClick?.(rows[currentIndex + 1]);
          scrollToRow(currentIndex + 1);
        }
        break;
      case 'PageUp': {
        e.preventDefault();
        const prevIndex = Math.max(0, currentIndex - 10);
        onRowClick?.(rows[prevIndex]);
        scrollToRow(prevIndex);
        break;
      }
      case 'PageDown': {
        e.preventDefault();
        const nextIndex = Math.min(rows.length - 1, currentIndex + 10);
        onRowClick?.(rows[nextIndex]);
        scrollToRow(nextIndex);
        break;
      }
      case 'Home':
        e.preventDefault();
        if (rows.length > 0) {
          onRowClick?.(rows[0]);
          scrollToRow(0);
        }
        break;
      case 'End':
        e.preventDefault();
        if (rows.length > 0) {
          onRowClick?.(rows[rows.length - 1]);
          scrollToRow(rows.length - 1);
        }
        break;
      case 'Enter':
        if (currentIndex >= 0 && onEdit) {
          onEdit(rows[currentIndex].original);
        }
        break;
      case 'Delete':
        if (currentIndex >= 0 && onDelete) {
          onDelete(rows[currentIndex].original);
        }
        break;
      case 'Insert':
        if (onAdd) {
          onAdd();
        }
        break;
    }
  };

  const paperStyle: CSSProperties = {
    height,
    maxHeight,
    display: 'flex',
    flexDirection: 'column',
    outline: 'none',
    direction: theme.layout.direction,
    width: theme.layout.fullWidth ? '100%' : 'auto',
    fontFamily: theme.layout.direction === 'rtl' 
      ? theme.typography.fontFamily.rtl 
      : theme.typography.fontFamily.ltr,
    border: `1px solid ${theme.colors.header.border}`,
    borderRadius: '4px',
    overflow: 'hidden',
  };

  
  return (
    <Box style={{ position: 'relative' }}>
      <Paper
        ref={containerRef}
        tabIndex={0}
        onKeyDown={handleKeyPress}
        style={paperStyle}
      >
        <Box style={{ display: 'flex', flexDirection: 'column', height: '100%', minHeight: 0 }}>
          <Box style={{ 
            display: 'flex',
            position: 'sticky',
            top: 0,
            zIndex: 2,
            background: theme.colors.header.background,
            direction: theme.layout.direction,
          }}>
            {table.getHeaderGroups().map(headerGroup => (
              <Box
                key={headerGroup.id}
                style={{
                  display: 'flex',
                  width: '100%',
                  direction: theme.layout.direction,
                }}
              >
                {headerGroup.headers.map(header => (
                  <GridHeader
                    key={header.id}
                    table={table}
                    theme={theme}
                    header={header}
                  />
                ))}
              </Box>
            ))}
          </Box>
          <Box 
            data-grid-body
            style={{ 
              flex: 1, 
              overflow: 'auto', 
              minHeight: 0,
              direction: theme.layout.direction,
              scrollBehavior: 'smooth',
              position: 'relative',
            }}
          >
            <GridBody
              table={table}
              theme={theme}
              isLoading={isLoading}
              error={error}
              selectedRowId={selectedRowId}
              onRowClick={onRowClick}
              idField={idField}
            />
          </Box>
          
        </Box>
        <Box style={{ 
          position: 'sticky', 
          bottom: 0, 
          zIndex: 2,
          background: theme.colors.pagination.background,
          borderTop: `1px solid ${theme.colors.pagination.border}`,
        }}>
          <GridPagination
            currentPage={pageIndex + 1}
            pageSize={pageSize}
            totalPages={table.getPageCount()}
            onPageChange={page => setPageIndex(page - 1)}
            onPageSizeChange={setPageSize}
            theme={theme}
          />
        </Box>
      </Paper>
    </Box>
  );
} 