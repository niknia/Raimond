import type { THEME_TRANSITIONS } from './transition.constants'

export interface IThemeTransitionsProps {
  duration?: keyof (typeof THEME_TRANSITIONS)['duration']
  property?: keyof (typeof THEME_TRANSITIONS)['property']
  timing?: keyof (typeof THEME_TRANSITIONS)['timing']
}

export type SystemStyleObject = {
  transitionDuration?: string
  transitionProperty?: string
  transitionTimingFunction?: string
}
