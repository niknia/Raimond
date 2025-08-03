import { ReactNode } from 'react'

export interface IScrollSizeContextType {
  items: Record<string, any>
  upsertItem: (id: string, item: any) => void
}

export interface IScrollSizeProviderProps {
  children: ReactNode
  inherit?: boolean
  items?: Record<string, any>
}
