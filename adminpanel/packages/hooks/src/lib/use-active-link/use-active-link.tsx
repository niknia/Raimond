import { useRouter } from 'next/router'

/**

Hook that checks whether a link is currently active or not.
@param {string} path - The path to check.
@param {boolean} [deep=true] - Whether to check for deep links or not.
@returns {{ active: boolean, isExternalLink: boolean }} - An object with two boolean properties: active (whether the link is active) and isExternalLink (whether the link is an external link).
*/
export const useActiveLink = (
  path: string,
  deep = true
): { active: boolean; isExternalLink: boolean } => {
  const { pathname, asPath } = useRouter()

  const checkPath = path.startsWith('#')

  const currentPath = path === '/' ? '/' : `${path}`

  const normalActive =
    (!checkPath && pathname === currentPath) ||
    (!checkPath && asPath === currentPath)

  const deepActive =
    (!checkPath && pathname.includes(currentPath)) ||
    (!checkPath && asPath.includes(currentPath))

  return {
    active: deep ? deepActive : normalActive,
    isExternalLink: path.includes('http'),
  }
}
