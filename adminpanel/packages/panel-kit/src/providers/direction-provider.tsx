"use client"

import type React from "react"

import { createContext, useContext, useState, useEffect } from "react"

type Direction = "ltr" | "rtl"

type DirectionContextType = {
  direction: Direction
  toggleDirection: () => void
  setDirection: (dir: Direction) => void
}

const DirectionContext = createContext<DirectionContextType>({
  direction: "rtl", // Default to RTL
  toggleDirection: () => {},
  setDirection: () => {},
})

export const useDirection = () => {
  const context = useContext(DirectionContext)
  if (!context) {
    throw new Error("useDirection must be used within a DirectionProvider")
  }
  return context
}

export function DirectionProvider({
  children,
}: {
  children: React.ReactNode
}) {
  const [direction, setDirection] = useState<Direction>("rtl") // Default to RTL

  const toggleDirection = () => {
    setDirection((prev) => (prev === "ltr" ? "rtl" : "ltr"))
  }

  useEffect(() => {
    document.documentElement.dir = direction
    document.documentElement.lang = direction === "rtl" ? "fa" : "en"

    // Add a class to the body for additional styling hooks
    document.body.classList.remove("ltr", "rtl")
    document.body.classList.add(direction)

    // Force any RTL-aware libraries to recalculate
    window.dispatchEvent(new Event("resize"))
  }, [direction])

  return (
    <DirectionContext.Provider value={{ direction, toggleDirection, setDirection }}>
      {children}
    </DirectionContext.Provider>
  )
}

