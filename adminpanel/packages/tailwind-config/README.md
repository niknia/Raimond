# @basepanel/tailwind-config

Shared Tailwind CSS configuration for BasePanel projects.

## Features

- ESM compatible
- TypeScript support
- Shared color palette
- Custom spacing and shadows
- Pre-configured plugins
- Optimized for Next.js and React

## Installation

```bash
pnpm add -D @basepanel/tailwind-config
```

## Usage

In your project's `tailwind.config.js` or `tailwind.config.ts`:

```typescript
import config from '@basepanel/tailwind-config';

export default config;
```

## Included Plugins

- @tailwindcss/forms
- @tailwindcss/typography
- @tailwindcss/aspect-ratio

## Customization

The configuration includes:

- Primary and secondary color palettes
- Custom font families
- Sidebar and header spacing
- Card shadows
- Border radius utilities

## Building

```bash
pnpm build
```

## Development

```bash
pnpm dev
``` 