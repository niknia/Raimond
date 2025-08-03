/**
 * Generates a random number between a minimum and maximum value, with a bias towards lower numbers.
 * @param {number} min - The minimum value that can be generated.
 * @param {number} max - The maximum value that can be generated.
 * @param {number} skewFactor - A factor that determines the amount of skew to apply to the generated number. Higher values will result in a greater bias towards lower numbers.
 * @returns {number} The generated random number.
 */
export const rand = (min: number, max: number, skewFactor: number): number => {
  const range = max - min
  const baseNumber = Math.random() * range + min
  const skew = Math.pow(Math.random(), skewFactor)

  const skewedNumber = Math.floor(baseNumber * skew)

  return skewedNumber
}
