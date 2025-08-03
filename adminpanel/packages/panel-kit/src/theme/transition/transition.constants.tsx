export const THEME_TRANSITIONS = {
  property: {
    none: 'none',
    all: 'all',
    default:
      'background-color, border-color, color, fill, stroke, opacity, box-shadow, transform, border, outline',
    borders: 'border, outline',
    colors: 'background-color, border-color, color, fill, stroke',
    opacity: 'opacity',
    shadow: 'box-shadow',
    transform: 'transform',
  },
  timing: {
    linear: 'linear',
    in: 'cubic-bezier(0.4, 0, 1, 1)',
    out: 'cubic-bezier(0, 0, 0.2, 1)',
    'in-out': 'cubic-bezier(0.4, 0, 0.2, 1)',
  },
  duration: {
    xs: '75ms',
    sm: '100ms',
    md: '150ms',
    lg: '200ms',
    xl: '300ms',
  },
}
