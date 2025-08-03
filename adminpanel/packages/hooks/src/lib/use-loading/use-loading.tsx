import { useState } from 'react'

/**
 * Custom hook to manage loading state
 * @param initial - Initial loading state
 * @returns Returns a tuple with loading state and an object containing start, stop, and toggle functions to update the loading state
 */
export const useLoading = (initial?: boolean) => {
  const [loading, setLoading] = useState<boolean>(initial ?? false)

  const start = () => setLoading(true)

  const stop = () => setLoading(false)

  const toggle = () => setLoading(state => !state)

  return [loading, { start, stop, toggle }] as const
}
