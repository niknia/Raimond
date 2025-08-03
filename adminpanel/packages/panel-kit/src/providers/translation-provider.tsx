'use client'

import { createInstance, Resource } from 'i18next'
import { PropsWithChildren, ReactElement } from 'react'
import { I18nextProvider } from 'react-i18next'

import {initTranslations} from '@dkd/utils'

interface TranslationProviderProps {
  locale: string
  resources: Resource
}

export function TranslationProvider({
  children,
  locale,
  resources,
}: PropsWithChildren<TranslationProviderProps>): ReactElement {
  const i18n = createInstance()

  initTranslations(locale, i18n, resources)

  return <I18nextProvider i18n={i18n}>{children}</I18nextProvider>
}
