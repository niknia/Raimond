import * as TablerIcons from '@tabler/icons-react';
import type { TablerIconsProps } from '@tabler/icons-react';
import FuzzySearch from 'fuzzy-search';
import { useMemo } from 'react';

export type IconName = keyof typeof TablerIcons;

interface IconProps {
  name: string;
  size?: number;
  stroke?: number;
  className?: string;
  style?: React.CSSProperties;
}

/**
 * تبدیل نام ورودی به فرمت استاندارد Tabler: IconUserCircle
 */
const normalizeIconName = (rawName: string): IconName | null => {
  let name = rawName.trim().toLowerCase();

  // حذف پیشوندهای icon
  name = name.replace(/^icon[_\-]?/, '');

  // تبدیل camelCase به فاصله‌دار و سپس شکستن به کلمات
  const words = name
    .replace(/([a-z0-9])([A-Z])/g, '$1 $2')
    .split(/[\s_\-]+/)
    .filter(Boolean);

  // ساخت نام PascalCase با پیشوند Icon
  const pascalName = `Icon${words
    .map(word => word.charAt(0).toUpperCase() + word.slice(1))
    .join('')}`;

  // بررسی وجود نام دقیق در آیکون‌ها
  if (pascalName in TablerIcons) {
    return pascalName as IconName;
  }

  // اگر آیکون دقیق پیدا نشد، جستجوی تقریبی
  const allIconNames = Object.keys(TablerIcons);
  const searcher = new FuzzySearch(allIconNames, [], {
    caseSensitive: false,
    sort: true,
  });

  const result = searcher.search(pascalName);
  if (result.length > 0) {
    return result[0] as IconName;
  }

  // پیدا نشد
  return null;
};

/**
 * کامپوننت اصلی Icon
 */
export const Icon: React.FC<IconProps> = ({
  name,
  size = 20,
  stroke = 1.5,
  className = '',
  style = {},
}) => {
  const normalizedName = useMemo(() => normalizeIconName(name), [name]);

  if (!normalizedName) {
    console.warn(`Icon "${name}" not found or unrecognized.`);
    return null;
  }

  const IconComponent = TablerIcons[normalizedName] as React.ComponentType<TablerIconsProps>;

  return (
    <IconComponent
      size={size}
      stroke={stroke}
      className={className}
      style={style}
    />
  );
};

/**
 * Utility function to get a map of all available icons
 * @param {number} [size=20] - The size of the icons in pixels
 * @param {number} [stroke=1.5] - The stroke width of the icons
 * @returns {Record<IconName, React.ReactNode>} A record of all available icons
 * 
 * @example
 * // Get all icons with default size and stroke
 * const iconMap = getIconMap();
 * 
 * @example
 * // Get all icons with custom size and stroke
 * const iconMap = getIconMap(24, 2);
 */
export const getIconMap = (size = 20, stroke = 1.5): Record<IconName, React.ReactNode> => {
  return Object.entries(TablerIcons).reduce((acc, [name, Component]) => {
    if (typeof Component === 'function') {
      const IconComponent = Component as React.ComponentType<TablerIconsProps>;
      acc[name as IconName] = <IconComponent size={size} stroke={stroke} />;
    }
    return acc;
  }, {} as Record<IconName, React.ReactNode>);
};