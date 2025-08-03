import React, { createContext, useContext, useEffect, useState } from 'react'
import dynamic from 'next/dynamic'
import type {
  IScrollSizeContextType,
  IScrollSizeProviderProps,
} from './scroll-size.types'

const ScrollSizeContext = createContext<IScrollSizeContextType>({
  items: {},
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  upsertItem: () => {},
})

/**
 * Returns the current scroll size context
 * @returns IScrollSizeContextType object with items and upsertItem function
 */
export const useScrollSizeContext = (): IScrollSizeContextType => {
  return useContext(ScrollSizeContext)
}

/**
 * Returns a hook to update a specific scroll size item
 * @param key The key of the scroll size item to update
 * @returns UseResizeDetectorReturn object of the specified scroll size item
 */
export const useScrollSizeUpsert = async (
  key: string
) => {
  const { useResizeDetector } = await import('react-resize-detector')
  const { upsertItem } = useContext(ScrollSizeContext)
  const item = useResizeDetector()

  useEffect(() => {
    upsertItem(key, item)
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [item.width])

  return item
}

/**
 * Returns the UseResizeDetectorReturn object of a specific scroll size item
 * @param key The key of the scroll size item to get
 * @returns UseResizeDetectorReturn object of the specified scroll size item
 */
export const useScrollSizeGetItem = (
  key: string
) => {
  return useContext(ScrollSizeContext)?.items[key]
}

/**
 * Provider component to set up the scroll size context
 * @param children The child components to render
 * @param inherit Whether to inherit from parent context or not
 * @param items The scroll size items to initialize the context with
 * @returns ScrollSizeContext.Provider component
 */
export const ScrollSizeProvider = ({
  children,
  inherit,
  items,
}: IScrollSizeProviderProps): React.JSX.Element => {
  const [localItems, setLocalItems] = useState<Record<string, any>>({})

  /**
   * Updates or inserts an item into the scroll size context
   * @param id The key of the item to update or insert
   * @param item The UseResizeDetectorReturn object to set as the item
   */
  const upsertItem = (
    id: string,
    item: any
  ): void => {
    setLocalItems(state => {
      const currentItem = state[id]

      if (!currentItem) {
        return { ...state, [id]: item }
      }

      if (
        currentItem?.width !== item.width ||
        currentItem?.height !== item.width
      ) {
        return { ...state, [id]: item }
      }

      return state
    })
  }

  // Merge items from parent context if `inherit` is true
  const { items: parentItems } = useContext(ScrollSizeContext)
  const mergedItems = inherit ? { ...parentItems, ...localItems } : localItems

  return (
    <ScrollSizeContext.Provider
      value={{ items: items ?? mergedItems, upsertItem }}
    >
      {children}
    </ScrollSizeContext.Provider>
  )
}
