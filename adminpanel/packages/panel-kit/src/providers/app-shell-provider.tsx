"use client"

import { createContext, useContext, useState, useEffect } from "react"
// import { MantineProvider, createTheme } from "@mantine/core"
import "@mantine/core/styles.css"
import { useDirection } from "./direction-provider"
// import { useTheme as useNextTheme } from "next-themes"

type NavigationMode = "sidebar" | "horizontal"

type AppShellContextType = {
  opened: boolean
  toggle: () => void
  close: () => void
  collapsed: boolean
  toggleCollapsed: () => void
  navigationMode: NavigationMode
  setNavigationMode: (mode: NavigationMode) => void
  toggleNavigationMode: () => void
}

const AppShellContext = createContext<AppShellContextType>({
  opened: false,
  toggle: () => {},
  close: () => {},
  collapsed: false,
  toggleCollapsed: () => {},
  navigationMode: "sidebar",
  setNavigationMode: () => {},
  toggleNavigationMode: () => {},
})

export const useAppShell = () => {
  const context = useContext(AppShellContext)
  if (!context) {
    throw new Error("useAppShell must be used within an AppShellProvider")
  }
  return context
}

export function AppShellProvider({
  children,
}: {
  children: React.ReactNode
}) {
  const [opened, setOpened] = useState(true) // تغییر به true برای desktop
  const [collapsed, setCollapsed] = useState(false)
  const [navigationMode, setNavigationMode] = useState<NavigationMode>("sidebar")
  const { direction } = useDirection()
  // const { theme } = useNextTheme()
  const [mounted, setMounted] = useState(false)

  const toggle = () => setOpened((o) => !o)
  const close = () => setOpened(false)
  const toggleCollapsed = () => setCollapsed((c) => !c)
  const toggleNavigationMode = () => setNavigationMode((prev) => (prev === "sidebar" ? "horizontal" : "sidebar"))

  // Ensure we only render theme components on the client to avoid hydration mismatch
  useEffect(() => {
    setMounted(true)
  }, [])



  // Force recalculation when direction changes
  useEffect(() => {
    window.dispatchEvent(new Event("resize"))
  }, [direction])

  if (!mounted) {
    return null
  }

  return (
    // <MantineProvider theme={mantineTheme} key={providerKey}>
      <AppShellContext.Provider
        value={{
          opened,
          toggle,
          close,
          collapsed,
          toggleCollapsed,
          navigationMode,
          setNavigationMode,
          toggleNavigationMode,
        }}
      >
        {children}
      </AppShellContext.Provider>
    // </MantineProvider>
  )
}