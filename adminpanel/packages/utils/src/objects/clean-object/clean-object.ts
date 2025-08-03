/**
 * Takes an object and removes all undefined values, returning a new object.
 *
 * @param obj - The object to clean.
 * @returns A new object with all undefined values removed.
 */
export const cleanObject = (
  obj: Record<string, unknown>
): Record<string, unknown> => {
  return Object.entries(obj)
    .filter(([_, value]) => value !== undefined)
    .reduce((acc, [key, value]) => {
      acc[key] = value
      return acc
    }, {} as Record<string, unknown>)
}
