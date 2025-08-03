
import { getI18n } from 'react-i18next'

export function getTranslation(translationKey: string): string {
  return getI18n()?.t(translationKey) ?? translationKey
}
