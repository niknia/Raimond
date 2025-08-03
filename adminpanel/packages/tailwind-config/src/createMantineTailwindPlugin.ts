import plugin from "tailwindcss/plugin";
import { DEFAULT_THEME } from "@mantine/core";
import type { MantineTheme } from "@mantine/core";

export const mantineTailwindPlugin = plugin(({ addBase }) => {
  const mantineTheme: MantineTheme = DEFAULT_THEME;

  // تعریف متغیرهای CSS برای استفاده در Tailwind
  const cssVariables: Record<string, string> = {};

  for (const [colorName, shades] of Object.entries(mantineTheme.colors)) {
    for (let i = 0; i < shades.length; i++) {
      cssVariables[`--mantine-color-${colorName}-${i}`] = shades[i];
      cssVariables[`--mantine-${colorName}-color-${i}`] = shades[i];
    }
    cssVariables[`--mantine-color-${colorName}-filled`] = shades[5];
    cssVariables[`--mantine-${colorName}-color-filled`] = shades[5];
  }

  cssVariables["--font-family"] = mantineTheme.fontFamily;
  cssVariables["--font-family-mono"] = mantineTheme.fontFamilyMonospace;
  cssVariables["--font-family-headings"] = mantineTheme.headings.fontFamily;

  for (const [key, value] of Object.entries(mantineTheme.fontSizes)) {
    cssVariables[`--font-size-${key}`] = value;
  }

  for (const [key, value] of Object.entries(mantineTheme.lineHeights)) {
    cssVariables[`--line-height-${key}`] = value;
  }

  for (const [key, value] of Object.entries(mantineTheme.spacing)) {
    cssVariables[`--spacing-${key}`] = value;
  }

  for (const [key, value] of Object.entries(mantineTheme.radius)) {
    cssVariables[`--border-radius-${key}`] = value;
  }

  for (const [key, value] of Object.entries(mantineTheme.shadows)) {
    cssVariables[`--shadow-${key}`] = value;
  }

  // Z-Index ها
  cssVariables["--z-index-app"] = mantineTheme.other?.["z-index-app"] ?? "10";
  cssVariables["--z-index-modal"] = mantineTheme.other?.["z-index-modal"] ?? "100";
  cssVariables["--z-index-popover"] = mantineTheme.other?.["z-index-popover"] ?? "200";
  cssVariables["--z-index-overlay"] = mantineTheme.other?.["z-index-overlay"] ?? "300";
  cssVariables["--z-index-max"] = "9999";

  addBase({
    ":root": cssVariables,
  });
});

/**
 * مقدار `extend` که در `tailwind.config.mjs` اضافه می‌شود.
 */
export const mantineTailwindExtend = {
  colors: Object.keys(DEFAULT_THEME.colors).reduce((acc, colorName) => {
    acc[colorName] = Array.from({ length: 10 }, (_, i) => `var(--color-${colorName}-${i})`);
    return acc;
  }, {} as Record<string, string[]>),

  fontFamily: {
    sans: "var(--font-family)",
  },

  fontSize: {
    sm: "var(--font-size-sm)",
    md: "var(--font-size-md)",
    lg: "var(--font-size-lg)",
    xl: "var(--font-size-xl)",
  },

  spacing: {
    xs: "var(--spacing-xs)",
    sm: "var(--spacing-sm)",
    md: "var(--spacing-md)",
    lg: "var(--spacing-lg)",
    xl: "var(--spacing-xl)",
  },

  borderRadius: {
    sm: "var(--border-radius-sm)",
    md: "var(--border-radius-md)",
    lg: "var(--border-radius-lg)",
  },

  boxShadow: {
    sm: "var(--shadow-sm)",
    md: "var(--shadow-md)",
    lg: "var(--shadow-lg)",
  },
};
