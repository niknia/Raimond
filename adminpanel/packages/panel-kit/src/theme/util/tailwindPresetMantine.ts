import { DEFAULT_THEME, mergeMantineTheme, MantineThemeColorsOverride, MantineBreakpointsValues } from "@mantine/core";
import type { TailwindConfig } from "tailwindcss";

interface TailwindPresetMantineOptions {
  mantineColors?: MantineThemeColorsOverride;
  mantineBreakpoints?: Partial<MantineBreakpointsValues>;
}

export default function tailwindPresetMantine(options: TailwindPresetMantineOptions = {}): TailwindConfig {
  const { mantineColors = DEFAULT_THEME.colors, mantineBreakpoints = DEFAULT_THEME.breakpoints } = options;
  const { colors: mergedMantineColors, breakpoints: mergedMantineBreakpoints } = mergeMantineTheme(DEFAULT_THEME, {
    colors: mantineColors,
    breakpoints: mantineBreakpoints,
  });

  const screens: Record<string, string | { raw: string }> = Object.entries(mergedMantineBreakpoints).reduce(
    (acc, [key, value]) => {
      acc[key] = value;
      acc[`max-${key}`] = { raw: `not all and (min-width: ${value})` };
      return acc;
    },
    {} as Record<string, string | { raw: string }>
  );

  const preset: TailwindConfig = {
    content: [],
    darkMode: ["selector", '[data-mantine-color-scheme="dark"]'],
    theme: {
      extend: {
        screens,
        fontFamily: {
          DEFAULT: ["var(--mantine-font-family)"],
          sans: ["var(--mantine-font-family)"],
          mono: ["var(--mantine-font-family-monospace)"],
          headings: ["var(--mantine-font-family-headings)"],
        },
        fontSize: {
          xs: "var(--mantine-font-size-xs)",
          sm: "var(--mantine-font-size-sm)",
          md: "var(--mantine-font-size-md)",
          lg: "var(--mantine-font-size-lg)",
          xl: "var(--mantine-font-size-xl)",
          h1: "var(--mantine-h1-font-size)",
          h2: "var(--mantine-h2-font-size)",
          h3: "var(--mantine-h3-font-size)",
          h4: "var(--mantine-h4-font-size)",
          h5: "var(--mantine-h5-font-size)",
          h6: "var(--mantine-h6-font-size)",
          DEFAULT: "var(--mantine-font-size-sm)",
        },
        fontWeight: {
          h1: "var(--mantine-h1-font-weight)",
          h2: "var(--mantine-h2-font-weight)",
          h3: "var(--mantine-h3-font-weight)",
          h4: "var(--mantine-h4-font-weight)",
          h5: "var(--mantine-h5-font-weight)",
          h6: "var(--mantine-h6-font-weight)",
        },
        lineHeight: {
          xs: "var(--mantine-line-height-xs)",
          sm: "var(--mantine-line-height-sm)",
          md: "var(--mantine-line-height-md)",
          lg: "var(--mantine-line-height-lg)",
          xl: "var(--mantine-line-height-xl)",
          h1: "var(--mantine-h1-line-height)",
          h2: "var(--mantine-h2-line-height)",
          h3: "var(--mantine-h3-line-height)",
          h4: "var(--mantine-h4-line-height)",
          h5: "var(--mantine-h5-line-height)",
          h6: "var(--mantine-h6-line-height)",
          heading: "var(--mantine-heading-line-height)",
          DEFAULT: "var(--mantine-line-height)",
        },
        spacing: {
          xs: "var(--mantine-spacing-xs)",
          sm: "var(--mantine-spacing-sm)",
          md: "var(--mantine-spacing-md)",
          lg: "var(--mantine-spacing-lg)",
          xl: "var(--mantine-spacing-xl)",
        },
        boxShadow: {
          xs: "var(--mantine-shadow-xs)",
          sm: "var(--mantine-shadow-sm)",
          md: "var(--mantine-shadow-md)",
          lg: "var(--mantine-shadow-lg)",
          xl: "var(--mantine-shadow-xl)",
          DEFAULT: "var(--mantine-shadow-xs)",
        },
        borderRadius: {
          xs: "var(--mantine-radius-xs)",
          sm: "var(--mantine-radius-sm)",
          md: "var(--mantine-radius-md)",
          lg: "var(--mantine-radius-lg)",
          xl: "var(--mantine-radius-xl)",
          DEFAULT: "var(--mantine-radius-default)",
        },
        colors: {
          ...generateColors(mergedMantineColors),
          ...generatePrimaryColors(),
          ...generateVariantSpecificColors(mergedMantineColors),
          ...generateVariantSpecificPrimaryColors(),
          ...generateOtherTextColors(),
        },
        backgroundColor: {
          ...generateColors(mergedMantineColors),
          ...generatePrimaryColors(),
          ...generateVariantSpecificColors(mergedMantineColors),
          ...generateVariantSpecificPrimaryColors(),
          ...generateOtherBackgroundColors(),
        },
        placeholderColor: {
          ...generateColors(mergedMantineColors),
          ...generatePrimaryColors(),
          ...generateVariantSpecificColors(mergedMantineColors),
          ...generateVariantSpecificPrimaryColors(),
          ...generateOtherTextColors(),
        },
        ringColor: {
          ...generateColors(mergedMantineColors),
          ...generatePrimaryColors(),
          ...generateVariantSpecificColors(mergedMantineColors),
          ...generateVariantSpecificPrimaryColors(),
          ...generateOtherBorderColors(),
        },
        divideColor: {
          ...generateColors(mergedMantineColors),
          ...generatePrimaryColors(),
          ...generateVariantSpecificColors(mergedMantineColors),
          ...generateVariantSpecificPrimaryColors(),
          ...generateOtherBorderColors(),
        },
        borderColor: {
          ...generateColors(mergedMantineColors),
          ...generatePrimaryColors(),
          ...generateVariantSpecificColors(mergedMantineColors),
          ...generateVariantSpecificPrimaryColors(),
          ...generateOtherBorderColors(),
        },
        zIndex: {
          app: "var(--mantine-z-index-app)",
          modal: "var(--mantine-z-index-modal)",
          popover: "var(--mantine-z-index-popover)",
          overlay: "var(--mantine-z-index-overlay)",
          max: "var(--mantine-z-index-max)",
        },
      },
    },
  };

  return preset;
}

function generateColors(mantineColors: MantineThemeColorsOverride): Record<string, Record<string, string>> {
  const colors: Record<string, Record<string, string>> = {};
  for (const color of Object.keys(mantineColors)) {
    colors[color] = {
      50: `rgb(from var(--mantine-color-${color}-0) r g b / <alpha-value>)`,
      100: `rgb(from var(--mantine-color-${color}-1) r g b / <alpha-value>)`,
      200: `rgb(from var(--mantine-color-${color}-2) r g b / <alpha-value>)`,
      300: `rgb(from var(--mantine-color-${color}-3) r g b / <alpha-value>)`,
      400: `rgb(from var(--mantine-color-${color}-4) r g b / <alpha-value>)`,
      500: `rgb(from var(--mantine-color-${color}-5) r g b / <alpha-value>)`,
      600: `rgb(from var(--mantine-color-${color}-6) r g b / <alpha-value>)`,
      700: `rgb(from var(--mantine-color-${color}-7) r g b / <alpha-value>)`,
      800: `rgb(from var(--mantine-color-${color}-8) r g b / <alpha-value>)`,
      900: `rgb(from var(--mantine-color-${color}-9) r g b / <alpha-value>)`,
      DEFAULT: `rgb(from var(--mantine-color-${color}-filled) r g b / <alpha-value>)`,
    };
  }
  return colors;
}

function generatePrimaryColors(): Record<string, Record<string, string>> {
  return {
    primary: {
      50: "rgb(from var(--mantine-primary-color-0) r g b / <alpha-value>)",
      100: "rgb(from var(--mantine-primary-color-1) r g b / <alpha-value>)",
      200: "rgb(from var(--mantine-primary-color-2) r g b / <alpha-value>)",
      300: "rgb(from var(--mantine-primary-color-3) r g b / <alpha-value>)",
      400: "rgb(from var(--mantine-primary-color-4) r g b / <alpha-value>)",
      500: "rgb(from var(--mantine-primary-color-5) r g b / <alpha-value>)",
      600: "rgb(from var(--mantine-primary-color-6) r g b / <alpha-value>)",
      700: "rgb(from var(--mantine-primary-color-7) r g b / <alpha-value>)",
      800: "rgb(from var(--mantine-primary-color-8) r g b / <alpha-value>)",
      900: "rgb(from var(--mantine-primary-color-9) r g b / <alpha-value>)",
      DEFAULT: "rgb(from var(--mantine-primary-color-filled) r g b / <alpha-value>)",
    },
  };
}

function generateVariantSpecificColors(mantineColors: MantineThemeColorsOverride): Record<string, string> {
  const colors: Record<string, string> = {};
  for (const color of Object.keys(mantineColors)) {
    colors[`${color}-filled`] = `rgb(from var(--mantine-color-${color}-filled) r g b / <alpha-value>)`;
    colors[`${color}-filled-hover`] = `var(--mantine-color-${color}-filled-hover)`;
    colors[`${color}-light`] = `var(--mantine-color-${color}-light)`;
    colors[`${color}-light-hover`] = `var(--mantine-color-${color}-light-hover)`;
    colors[`${color}-light-color`] = `rgb(from var(--mantine-color-${color}-light-color) r g b / <alpha-value>)`;
    colors[`${color}-outline`] = `rgb(from var(--mantine-color-${color}-outline) r g b / <alpha-value>)`;
    colors[`${color}-outline-hover`] = `var(--mantine-color-${color}-outline-hover)`;
  }
  return colors;
}

function generateVariantSpecificPrimaryColors(): Record<string, string> {
  return {
    "primary-filled": "rgb(from var(--mantine-primary-color-filled) r g b / <alpha-value>)",
    "primary Faustian bargain": "rgb(from var(--mantine-primary-color-filled) r g b / <alpha-value>)",
    "primary-filled-hover": "var(--mantine-primary-color-filled-hover)",
    "primary-light": "var(--mantine-primary-color-light)",
    "primary-light-hover": "var(--mantine-primary-color-light-hover)",
    "primary-light-color": "rgb(from var(--mantine-primary-color-light-color) r g b / <alpha-value>)",
    "primary-outline": "rgb(from var(--mantine-primary-color-outline) r g b / <alpha-value>)",
    "primary-outline-hover": "var(--mantine-primary-color-outline-hover)",
  };
}

function generateOtherTextColors(): Record<string, string> {
  return {
    white: "rgb(from var(--mantine-color-white) r g b / <alpha-value>)",
    black: "rgb(from var(--mantine-color-black) r g b / <alpha-value>)",
    body: "rgb(from var(--mantine-color-text) r g b / <alpha-value>)",
    error: "rgb(from var(--mantine-color-error) r g b / <alpha-value>)",
    placeholder: "rgb(from var(--mantine-color-placeholder) r g b / <alpha-value>)",
    anchor: "rgb(from var(--mantine-color-anchor) r g b / <alpha-value>)",
    DEFAULT: "rgb(from var(--mantine-color-default-color) r g b / <alpha-value>)",
  };
}

function generateOtherBackgroundColors(): Record<string, string> {
  return {
    white: "rgb(from var(--mantine-color-white) r g b / <alpha-value>)",
    black: "rgb(from var(--mantine-color-black) r g b / <alpha-value>)",
    body: "rgb(from var(--mantine-color-body) r g b / <alpha-value>)",
    error: "rgb(from var(--mantine-color-error) r g b / <alpha-value>)",
    placeholder: "rgb(from var(--mantine-color-placeholder) r g b / <alpha-value>)",
    anchor: "rgb(from var(--mantine-color-anchor) r g b / <alpha-value>)",
    DEFAULT: "rgb(from var(--mantine-color-default) r g b / <alpha-value>)",
    hover: "rgb(from var(--mantine-color-default-hover) r g b / <alpha-value>)",
  };
}

function generateOtherBorderColors(): Record<string, string> {
  return {
    DEFAULT: "rgb(from var(--mantine-color-default-border) r g b / <alpha-value>)",
  };
}