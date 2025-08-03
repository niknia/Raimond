import {
  MantineSize,
  getBreakpointValue,
  getSize,
  px,
  useMantineTheme,
} from '@mantine/core';
import { useMediaQuery } from '@mantine/hooks';

export const useResponsive = (query: 'up' | 'down', start: MantineSize) => {
  const theme = useMantineTheme();

  const breakpointValue = getSize({ size: start, sizes: theme.breakpoints });
  // در صورتی که breakpointValue تعریف نشده باشد، یک مقدار پیش‌فرض (مثلاً 0 یا یک مقدار مناسب) در نظر بگیرید
  const bp = breakpointValue !== undefined ? breakpointValue : 0;

  const mediaUp = useMediaQuery(
    `(min-width: ${px(getBreakpointValue(bp, theme.breakpoints))}px)`,
    true,
    {
      getInitialValueInEffect: false,
    }
  );

  const mediaDown = useMediaQuery(
    `(max-width: ${px(getBreakpointValue(bp, theme.breakpoints) - 1)}px)`,
    true,
    {
      getInitialValueInEffect: false,
    }
  );

  return query === 'down' ? mediaDown : mediaUp;
};
