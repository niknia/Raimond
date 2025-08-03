# Sidebar Components

This directory contains the refactored sidebar components that have been broken down into smaller, more manageable pieces for better readability and maintainability.

## Component Structure

### Main Components

- **AppSidebar.tsx** - The main sidebar container component
- **SidebarMenuItem.tsx** - Wrapper component that decides between collapsed and expanded states

### Sub-Components

- **CollapsedMenuItem.tsx** - Handles collapsed menu items with popover functionality
- **ExpandedMenuItem.tsx** - Handles expanded menu items with collapse functionality
- **PopoverSubMenu.tsx** - Manages submenu content within popovers
- **ThirdLevelMenu.tsx** - Renders third-level menu items
- **MenuButton.tsx** - Reusable button component for menu items

### Utilities

- **useMenuStyles.ts** - Custom hook for managing menu styling and theme calculations

## Benefits of Refactoring

1. **Improved Readability**: Each component has a single responsibility
2. **Better Maintainability**: Changes to specific functionality are isolated
3. **Reusability**: Components like `MenuButton` can be reused
4. **Testability**: Smaller components are easier to test
5. **Performance**: Better code splitting and optimization opportunities

## Usage

```tsx
import AppSidebar from './AppSidebar';

<AppSidebar collapsed={isCollapsed} />
```

## Component Hierarchy

```
AppSidebar
├── SidebarMenuItem (decides collapsed vs expanded)
│   ├── CollapsedMenuItem (with popover)
│   │   └── PopoverSubMenu
│   │       └── ThirdLevelMenu
│   └── ExpandedMenuItem (with collapse)
│       └── SubMenuItemComponent (existing)
```

## Styling

All styling logic is centralized in the `useMenuStyles` hook, making it easier to maintain consistent theming across all components. 