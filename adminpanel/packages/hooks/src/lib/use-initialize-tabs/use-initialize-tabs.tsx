import { useStore } from '@omnidash/store'
import { useEffect } from 'react'

export const useInitializeTabs = () => {
  const {
    actions: { initializeCurrentTabs },
  } = useStore.use.globalTabs()

  useEffect(() => {
    initializeCurrentTabs()
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])
}
