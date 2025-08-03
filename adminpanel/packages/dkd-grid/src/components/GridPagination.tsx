import type { ReactElement } from 'react';
import { Group, Select, Pagination, Box, type CSSProperties, ActionIcon } from '@mantine/core';
import type { DkdGridTheme } from '../theme/types';
import { IconChevronLeft , IconChevronsLeft , IconChevronRight , IconChevronsRight , IconReport ,IconDownload, IconAdjustmentsHorizontal} from '@tabler/icons-react';
import FabActionButton from '../Fab/FabActionButton';
import FabActionItem from '../Fab/FabActionItem';
import { useMediaQuery } from '@mantine/hooks';

interface GridPaginationProps {
  currentPage: number;
  pageSize: number;
  totalPages: number;
  onPageChange: (page: number) => void;
  onPageSizeChange: (size: number) => void;
  theme: DkdGridTheme;
  onReport?: () => void;
  onAdvancedSearch?: () => void;
  onExport?: () => void;
}

const pageSizeOptions = [
  { value: '5', label: '5' },
  { value: '10', label: '10' },
  { value: '20', label: '20' },
  { value: '50', label: '50' },
  { value: '100', label: '100' },
];

export function GridPagination({
  currentPage,
  pageSize,
  totalPages,
  onPageChange,
  onPageSizeChange,
  theme,
  onReport,
  onAdvancedSearch,
  onExport,
}: GridPaginationProps): ReactElement {
  const { colors, typography, spacing, layout } = theme;
  const isMobile = useMediaQuery('(max-width: 768px)');

  const containerStyle: CSSProperties = {
    display: 'flex',
    flexDirection: isMobile ? 'column' : 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    padding: spacing.padding,
    background: colors.pagination.background,
    borderTop: `0px solid ${colors.pagination.border}`,
    fontFamily: layout.direction === 'rtl' ? typography.fontFamily.rtl : typography.fontFamily.ltr,
    direction: layout.direction,
    position: 'relative',
    gap: isMobile ? '1rem' : '0',
  };


  const pageSizeLabel = layout.direction === 'rtl' ? 'تعداد در صفحه:' : 'Rows per page:';


  const handlePageChange = (page: number) => {
    if (page >= 1 && page <= totalPages) {
      onPageChange(page);
    }
  };


  return (
    <Box style={containerStyle}>
      {/* Page size selector - Hidden on mobile */}
      {!isMobile && (
        <Group gap={8}>
          <Select
            label={pageSizeLabel}
            value={pageSize.toString()}
            onChange={(value) => onPageSizeChange(Number(value))}
            data={pageSizeOptions}
            size="xs"
            style={{ width: 100 }}
          />
        </Group>
      )}


      {/* Spacer */}
      {!isMobile && <div style={{ flex: 1 }} />}


      {/* Pagination */}
      {isMobile ? (
        <Group gap={8} justify="center">
          <ActionIcon
            variant="light"
            color={theme.colors.primary}
            onClick={() => handlePageChange(1)}
            disabled={currentPage === 1}
            aria-label={layout.direction === 'rtl' ? 'صفحه اول' : 'First page'}
          >
            {layout.direction === 'rtl' ? <IconChevronsRight  size={18} /> : <IconChevronsLeft  size={18} />}
          </ActionIcon>
          <ActionIcon
            variant="light"
            color={theme.colors.primary}
            onClick={() => handlePageChange(currentPage - 1)}
            disabled={currentPage === 1}
            aria-label={layout.direction === 'rtl' ? 'صفحه قبل' : 'Previous page'}
          >
            {layout.direction === 'rtl' ? <IconChevronRight  size={18} /> : <IconChevronLeft  size={18} />}
          </ActionIcon>
          <Box style={{ padding: '0 8px' }}>
            {currentPage} / {totalPages}
          </Box>
          <ActionIcon
            variant="light"
            color={theme.colors.primary}
            onClick={() => handlePageChange(currentPage + 1)}
            disabled={currentPage === totalPages}
            aria-label={layout.direction === 'rtl' ? 'صفحه بعد' : 'Next page'}
          >
            {layout.direction === 'rtl' ? <IconChevronLeft  size={18} /> : <IconChevronRight  size={18} />}
          </ActionIcon>
          <ActionIcon
            variant="light"
            color={theme.colors.primary}
            onClick={() => handlePageChange(totalPages)}
            disabled={currentPage === totalPages}
            aria-label={layout.direction === 'rtl' ? 'صفحه آخر' : 'Last page'}
          >
            {layout.direction === 'rtl' ? <IconChevronsLeft  size={18} /> : <IconChevronsRight  size={18} />}
          </ActionIcon>
        </Group>
      ) : (
        <Pagination
          value={currentPage}
          onChange={onPageChange}
          total={totalPages}
          size="sm"
          withEdges
          dir={layout.direction}
        />
      )}


      {/* Floating Action Button */}
      <FabActionButton
        direction="up"
        position={{
          top: "-50px",
          [layout.direction === 'ltr' ? 'right' : 'left']: "10px"
        }}
        rtl={layout.direction === 'rtl'}
        >
        <FabActionItem 
          icon={<IconReport  size={18} />} 
          onClick={onReport} 
          label={layout.direction === 'rtl' ? 'گزارش' : 'Report'} 
          rtl={layout.direction === 'rtl'}
        />
        <FabActionItem 
          icon={<IconAdjustmentsHorizontal  size={18} />} 
          onClick={onAdvancedSearch} 
          label={layout.direction === 'rtl' ? 'فیلتر پیشرفته' : 'Advanced Filter'} 
          rtl={layout.direction === 'rtl'}
        />
        <FabActionItem 
          icon={<IconDownload size={18} />} 
          onClick={onExport} 
          label={layout.direction === 'rtl' ? 'ارسال به فایل' : 'Export'} 
          rtl={layout.direction === 'rtl'}
        />
      </FabActionButton>
    </Box>
  );
}
