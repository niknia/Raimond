import { THEME_TRANSITIONS } from './transition.constants'
import type { IThemeTransitionsProps, SystemStyleObject } from './transition.types'

export const ThemeTransitions = (
  options?: IThemeTransitionsProps
): Pick<
  SystemStyleObject,
  'transitionDuration' | 'transitionTimingFunction' | 'transitionProperty'
> => ({
  transitionDuration: THEME_TRANSITIONS.duration[options?.duration ?? 'md'],
  transitionProperty:
    THEME_TRANSITIONS.property[options?.property ?? 'default'],
  transitionTimingFunction:
    THEME_TRANSITIONS.timing[options?.timing ?? 'in-out'],
})
