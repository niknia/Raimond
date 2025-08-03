import { useLayoutEffect, useRef, useState } from 'react'

/**
 * A React hook that detects whether a DOM element has overflow.
 * @param ref - The ref object for the DOM element to check for overflow.
 * @param callback - An optional callback function to call when the overflow status changes.
 * @returns True if the element has overflow, false otherwise.
 */
export const useIsOverflow = <T extends HTMLElement>(
  callback?: (hasOverflow: boolean) => void
) => {
  const ref = useRef<T | HTMLElement>(null)
  const [isOverflow, setIsOverflow] = useState<boolean | undefined>(undefined)

  useLayoutEffect(() => {
    const { current } = ref

    const trigger = () => {
      const hasOverflow =
        current?.scrollHeight || current?.clientHeight
          ? current?.scrollHeight > current?.clientHeight
          : false

      setIsOverflow(hasOverflow)

      if (callback) {
        callback(hasOverflow)
      }
    }

    if (current) {
      trigger()
    }
  }, [callback, ref])

  return [ref, isOverflow] as const
}
