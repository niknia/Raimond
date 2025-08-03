export interface DkdGridThemeColors {
  primary: string;
  header: {
    background: string;
    text: string;
    border: string;
    resizer: string;
    resizerHover: string;
  };
  row: {
    background: string;
    text: string;
    border: string;
    hoverBackground: string;
    selectedBackground: string;
    selectedText: string;
    selectedBorder: string;
    alternateBackground: string;
  };
  pagination: {
    background: string;
    text: string;
    border: string;
    activeBackground: string;
    activeText: string;
  };
  error: string;
  actions: {
    background: string;
    text: string;
    iconColor: string;
    iconBackground: string;
    hoverBackground: string;
    iconHoverBackground: string;
    menuBackground: string;
  };
}

export interface DkdGridThemeTypography {
  fontFamily: {
    ltr: string;
    rtl: string;
  };
  headerFontSize: string;
  headerFontWeight: string | number;
  cellFontSize: string;
  actionFontSize: string;
}

export interface DkdGridThemeSpacing {
  padding: string | number;
  headerHeight: string | number;
  rowHeight: string | number;
  fabPosition: string | number;
}

export interface DkdGridThemeLayout {
  direction: 'ltr' | 'rtl';
  fullWidth: boolean;
  columnResizing: boolean;
  minColumnWidth: number;
  maxColumnWidth: number;
}

export interface DkdGridTheme {
  colors: DkdGridThemeColors;
  typography: DkdGridThemeTypography;
  spacing: DkdGridThemeSpacing;
  layout: DkdGridThemeLayout;
}

export interface DkdGridStyleProps {
  theme: DkdGridTheme;
} 