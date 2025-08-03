"use client";
import { Switch } from '@mantine/core';
import { useTheme } from 'next-themes';
import { useEffect, useState } from 'react';

export function ThemeToggle() {
  const { theme, setTheme } = useTheme();
  const [mounted, setMounted] = useState(false);

  useEffect(() => setMounted(true), []);

  if (!mounted) return null;

  return (
    <Switch
      checked={theme === 'dark'}
      onChange={(e: React.ChangeEvent<HTMLInputElement>) => setTheme(e.currentTarget.checked ? 'dark' : 'light')}
      label={theme === 'dark' ? 'حالت تاریک' : 'حالت روشن'}
    />
  );
}