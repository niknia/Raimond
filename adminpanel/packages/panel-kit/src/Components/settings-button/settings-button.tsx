"use client"

import { useState } from "react"
import { ActionIcon } from "@mantine/core"
import { Settings } from "lucide-react"
// import { useDirection } from "@providers"
import { SettingsDrawer } from "../settings-drawer"

export function SettingsButton() {
  const [opened, setOpened] = useState(false)
  // const { direction } = useDirection()

  return (
    <>
    <ActionIcon
			aria-label="Documentation"
  		component="button"
       onClick={() => setOpened(true)}
			>
								<Settings size={16} />
			</ActionIcon>

      <SettingsDrawer opened={opened} onClose={() => setOpened(false)} />
    </>
  )
}

