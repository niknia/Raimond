// util/inject-theme-css-vars.ts

type ColorShades = string[];

export function injectColorVars(
  colorName: string,
  shades: ColorShades,
  mode: 'light' | 'dark' = 'light'
): Record<string, string> {
  return shades.reduce((vars, color, index) => {
    const prefix = mode === 'light' ? '' : 'dark-';
    vars[`--mantine-${prefix}${colorName}-color-${index}`] = color;
    return vars;
  }, {} as Record<string, string>);
}

export function injectMultipleColorVars(
    colors: Record<string, string[]>,
    mode: 'light' | 'dark'
  ): Record<string, string> {
    const prefix = `--mantine-${mode}-color`;
  
    return Object.fromEntries(
      Object.entries(colors).flatMap(([colorName, shades]) =>
        shades.map((shade, index) => [
          `${prefix}-${colorName}-${index}`,
          shade
        ])
      )
    );
  }
  
