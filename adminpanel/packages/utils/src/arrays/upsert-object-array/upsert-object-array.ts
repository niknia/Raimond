/**
 * Adds or updates an object with a unique `id` property in an array of objects.
 * If an object with the same `id` already exists in the array, it will be replaced with the new object.
 * If the object doesn't exist, it will be added to the end of the array.
 *
 * @param newObj - The object to add or update in the array.
 * @param arr - The array of objects to add the new object to.
 * @returns A new array with the new or updated object.
 */
export const upsertObjectArray = <T extends { id: string }>(
  newObj: T,
  arr: Array<T>
): Array<T> => {
  const index = arr.findIndex((obj: T) => newObj.id === obj.id)
  if (-1 === index) {
    return [...arr, newObj]
  }

  return [...arr.slice(0, index), newObj, ...arr.slice(index + 1)]
}
