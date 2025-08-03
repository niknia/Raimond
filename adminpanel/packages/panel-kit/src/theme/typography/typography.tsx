const TYPOGRAPHY_WEIGHT = {
  heading: {
    regular: {
      fontWeight: 600,
    },
    bold: {
      fontWeight: 700,
    },
    black: {
      fontWeight: 800,
    },
  },
  body: {
    light: {
      fontWeight: 300,
    },
    regular: {
      fontWeight: 400,
    },
    medium: {
      fontWeight: 500,
    },
    bold: {
      fontWeight: 800,
    },
  },
}

const TYPOGRAPHY = {
  h1: {
    fontSize: '51px',
    lineHeight: '71px',
    letterSpacing: 0.3,
  },
  h2: {
    fontSize: '41px',
    lineHeight: '57px',
    letterSpacing: 0.3,
  },
  h3: {
    fontSize: '28px',
    lineHeight: '39px',
    letterSpacing: 0.3,
  },
  h4: {
    fontSize: '21px',
    lineHeight: '29px',
    letterSpacing: 0.3,
  },
  h5: {
    fontSize: '16px',
    lineHeight: '22px',
    letterSpacing: 0.3,
  },
  'body-xl': {
    fontSize: '18px',
    lineHeight: '24px',
    letterSpacing: 0.6,
  },
  'body-lg': {
    fontSize: '16px',
    lineHeight: '24px',
    letterSpacing: 0.6,
  },
  'body-md': {
    fontSize: '14px',
    lineHeight: '20px',
    letterSpacing: 0.6,
  },
  'body-sm': {
    fontSize: '12px',
    lineHeight: '18px',
    letterSpacing: 0.6,
  },
  'overline-lg': {
    fontSize: '12px',
    lineHeight: '18px',
    letterSpacing: 1.8,
  },
  'overline-md': {
    fontSize: '10px',
    lineHeight: '18px',
    letterSpacing: 1.8,
  },
  'overline-sm': {
    fontSize: '9px',
    lineHeight: '18px',
    letterSpacing: 1.8,
  },
}

export const ThemeTypography = {
  overline: {
    lg: {
      regular: {
        ...TYPOGRAPHY['overline-lg'],
        ...TYPOGRAPHY_WEIGHT.body.regular,
      },
      medium: {
        ...TYPOGRAPHY['overline-lg'],
        ...TYPOGRAPHY_WEIGHT.body.medium,
      },
    },
    md: {
      regular: {
        ...TYPOGRAPHY['overline-md'],
        ...TYPOGRAPHY_WEIGHT.body.regular,
      },
      medium: {
        ...TYPOGRAPHY['overline-md'],
        ...TYPOGRAPHY_WEIGHT.body.medium,
      },
    },
    sm: {
      regular: {
        ...TYPOGRAPHY['overline-sm'],
        ...TYPOGRAPHY_WEIGHT.body.regular,
      },
      medium: {
        ...TYPOGRAPHY['overline-sm'],
        ...TYPOGRAPHY_WEIGHT.body.medium,
      },
    },
  },
  h1: {
    bold: { ...TYPOGRAPHY.h1, ...TYPOGRAPHY_WEIGHT.heading.bold },
    black: { ...TYPOGRAPHY.h1, ...TYPOGRAPHY_WEIGHT.heading.black },
    medium: { ...TYPOGRAPHY.h1, ...TYPOGRAPHY_WEIGHT.heading.regular },
  },
  h2: {
    bold: { ...TYPOGRAPHY.h2, ...TYPOGRAPHY_WEIGHT.heading.bold },
    black: { ...TYPOGRAPHY.h2, ...TYPOGRAPHY_WEIGHT.heading.black },
    medium: { ...TYPOGRAPHY.h2, ...TYPOGRAPHY_WEIGHT.heading.regular },
  },
  h3: {
    bold: { ...TYPOGRAPHY.h3, ...TYPOGRAPHY_WEIGHT.heading.bold },
    black: { ...TYPOGRAPHY.h3, ...TYPOGRAPHY_WEIGHT.heading.black },
    medium: { ...TYPOGRAPHY.h3, ...TYPOGRAPHY_WEIGHT.heading.regular },
  },
  h4: {
    bold: { ...TYPOGRAPHY.h4, ...TYPOGRAPHY_WEIGHT.heading.bold },
    black: { ...TYPOGRAPHY.h4, ...TYPOGRAPHY_WEIGHT.heading.black },
    medium: { ...TYPOGRAPHY.h4, ...TYPOGRAPHY_WEIGHT.heading.regular },
  },
  h5: {
    bold: { ...TYPOGRAPHY.h5, ...TYPOGRAPHY_WEIGHT.heading.bold },
    black: { ...TYPOGRAPHY.h5, ...TYPOGRAPHY_WEIGHT.heading.black },
    medium: { ...TYPOGRAPHY.h5, ...TYPOGRAPHY_WEIGHT.heading.regular },
  },
  body: {
    xl: {
      light: {
        ...TYPOGRAPHY['body-xl'],
        ...TYPOGRAPHY_WEIGHT.body.light,
      },
      regular: {
        ...TYPOGRAPHY['body-xl'],
        ...TYPOGRAPHY_WEIGHT.body.regular,
      },
      medium: {
        ...TYPOGRAPHY['body-xl'],
        ...TYPOGRAPHY_WEIGHT.body.medium,
      },
      bold: {
        ...TYPOGRAPHY['body-xl'],
        ...TYPOGRAPHY_WEIGHT.body.bold,
      },
    },
    lg: {
      light: {
        ...TYPOGRAPHY['body-lg'],
        ...TYPOGRAPHY_WEIGHT.body.light,
      },
      regular: {
        ...TYPOGRAPHY['body-lg'],
        ...TYPOGRAPHY_WEIGHT.body.regular,
      },
      medium: {
        ...TYPOGRAPHY['body-lg'],
        ...TYPOGRAPHY_WEIGHT.body.medium,
      },
      bold: {
        ...TYPOGRAPHY['body-lg'],
        ...TYPOGRAPHY_WEIGHT.body.bold,
      },
    },
    md: {
      light: { ...TYPOGRAPHY['body-md'], ...TYPOGRAPHY_WEIGHT.body.light },
      regular: { ...TYPOGRAPHY['body-md'], ...TYPOGRAPHY_WEIGHT.body.regular },
      medium: {
        ...TYPOGRAPHY['body-md'],
        ...TYPOGRAPHY_WEIGHT.body.medium,
      },
      bold: { ...TYPOGRAPHY['body-md'], ...TYPOGRAPHY_WEIGHT.body.bold },
    },
    sm: {
      light: { ...TYPOGRAPHY['body-sm'], ...TYPOGRAPHY_WEIGHT.body.light },
      regular: { ...TYPOGRAPHY['body-sm'], ...TYPOGRAPHY_WEIGHT.body.regular },
      medium: {
        ...TYPOGRAPHY['body-sm'],
        ...TYPOGRAPHY_WEIGHT.body.medium,
      },
      bold: { ...TYPOGRAPHY['body-sm'], ...TYPOGRAPHY_WEIGHT.body.bold },
    },
  },
} as const
