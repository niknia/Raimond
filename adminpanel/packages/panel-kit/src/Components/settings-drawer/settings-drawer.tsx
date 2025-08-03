"use client"

import { useState, useEffect } from "react"
import { Drawer, Switch, Stack, Tabs, Card, useMantineTheme, Divider, useMantineColorScheme, ActionIcon } from "@mantine/core"
import { useDirection } from "../../providers"
import { useAppShell } from "../../providers"
import { SelectThemeButton } from "../select-theme-button"
import { sortedThemeNames } from "../../theme"
import { Moon, Sun, Languages, PanelLeft, Menu } from "lucide-react"

interface SettingsDrawerProps {
  opened: boolean
  onClose: () => void
}

export function SettingsDrawer({ opened, onClose }: SettingsDrawerProps) {
  const { direction, toggleDirection } = useDirection()
  const {  toggleCollapsed,  toggleNavigationMode } = useAppShell()
  const [mounted, setMounted] = useState(false)
  const [activeTab, setActiveTab] = useState<string | null>("theme")

  const mantineTheme = useMantineTheme()
  const { colorScheme, setColorScheme } = useMantineColorScheme()

  const handleColorSchemeChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const newColorScheme = event.currentTarget.checked ? "dark" : "light"
    setColorScheme(newColorScheme)
    if (typeof window !== 'undefined') {
      window.localStorage.setItem('mantine-color-scheme-value', newColorScheme)
      // Sync with Tailwind dark mode
      if (newColorScheme === 'dark') {
        document.documentElement.classList.add('dark')
      } else {
        document.documentElement.classList.remove('dark')
      }
    }
  }

  useEffect(() => {
    setMounted(true)
  }, [])

  if (!mounted) {
    return null
  }

  return (
    <Drawer
      opened={opened}
      onClose={onClose}
      position={direction === "rtl" ? "right" : "right"}
      transitionProps={{
        transition: direction === "rtl" ? "slide-right" : "slide-left",
      }}
      size="md"
      title={direction === "rtl" ? "تنظیمات" : "Settings"}
      classNames={{
        title: direction === "rtl" ? "font-vazirmatn mr-2" : "",
        header: "border-b pb-2",
        body: "py-4",
      }}
    >
      <Tabs value={activeTab} onChange={setActiveTab}>
        <Tabs.List>
          <Tabs.Tab value="theme">{direction === "rtl" ? "تم" : "Theme"}</Tabs.Tab>
          <Tabs.Tab value="colors">{direction === "rtl" ? "رنگ‌ها" : "Colors"}</Tabs.Tab>
        </Tabs.List>

        <Tabs.Panel value="theme" className="p-4">
          <Card
            withBorder
            mb={3}
            shadow="lg"
            radius="lg"
            style={{
              color: colorScheme === "dark" ? "white" : "black",
            }}
          >
            <div className="space-y-6 px-3">
              <div className="space-y-3">
                <h3 className={`text-lg font-medium ${direction === "rtl" ? "text-right font-vazirmatn" : ""}`}>
                  {direction === "rtl" ? "تم" : "Theme"}
                </h3>
                <div className="flex items-center justify-between">
                  <span className={`text-sm ${direction === "rtl" ? "font-vazirmatn" : ""}`}>
                    {direction === "rtl" ? "حالت تاریک" : "Dark Mode"}
                  </span>
                  <Switch
                    checked={colorScheme === "dark"}
                    onChange={handleColorSchemeChange}
                    size="md"
                    onLabel={<Sun size="1rem" />}
                    offLabel={<Moon size="1rem" />}
                  />
                </div>
              </div>
            </div>
          </Card>

          
          
          <Card
            withBorder
            mt={2}
            shadow="md"
            radius="lg"
            style={{
              color: colorScheme === "dark" ? "white" : "black",
            }}
          >
            <div className="grid grid-cols-3 gap-3 text-center">
              <div className="flex flex-col items-center space-y-2">
                <h3 className="text-lg font-medium font-vazirmatn">زبان</h3>
                <ActionIcon
                  variant="primary"
                  size="lg"
                  radius="md"
                  aria-label="Settings"
                  onClick={toggleDirection}
                >
                  <Languages style={{ width: "70%", height: "70%" }} />
                </ActionIcon>
              </div>

              <div className="flex flex-col items-center space-y-2">
                <h3 className="text-lg font-medium font-vazirmatn">ناوبری</h3>
                <ActionIcon
                  variant="primary"
                  size="lg"
                  radius="md"
                  aria-label="Settings"
                  onClick={toggleNavigationMode}
                >
                  <Menu style={{ width: "70%", height: "70%" }} />
                </ActionIcon>
              </div>

              <div className="flex flex-col items-center space-y-2">
                <h3 className="text-lg font-medium font-vazirmatn">منوی کناری</h3>
                <ActionIcon
                  variant="primary"
                  size="lg"
                  radius="md"
                  aria-label="Settings"
                  onClick={toggleCollapsed}
                >
                  <PanelLeft style={{ width: "70%", height: "70%" }} />
                </ActionIcon>
              </div>
            </div>
          </Card>
        </Tabs.Panel>

        <Tabs.Panel value="colors" className="p-4">
          <h3 className="text-lg font-medium">{direction === "rtl" ? "رنگ‌ها" : "Colors"}</h3>
          <Stack gap="xs">
            {sortedThemeNames.map((themeName) => (
              <SelectThemeButton key={themeName} themeName={themeName} />
            ))}
          </Stack>
        </Tabs.Panel>
      </Tabs>
    </Drawer>
  )
}


