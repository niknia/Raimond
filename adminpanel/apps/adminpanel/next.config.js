//@ts-check

// eslint-disable-next-line @typescript-eslint/no-var-requires
const { composePlugins, withNx } = require('@nx/next');
const path = require('path');


/**
 * @type {import('@nx/next/plugins/with-nx').WithNxOptions}
 **/
const nextConfig = {
  nx: {
    // Set this to true if you would like to use SVGR
    // See: https://github.com/gregberge/svgr
    svgr: false,
  },
  webpack: (config) => {
    config.resolve.alias['@'] = path.resolve(__dirname, 'src');
    return config;
  },
  transpilePackages: [
    '@mantine/core',
    '@mantine/hooks',
    '@mantine/dates',
    '@mantine/form',
    '@mantine/modals',
    '@mantine/notifications',
    '@mantine/nprogress',
    '@mantine/spotlight',
    '@dkd/utils',
    '@dkd/ui-kit',
    '@dkd/hook-form-mantine',
    '@dkd/panel-kit',
    'date-fns',
    'react-resize-detector'
  ],
  experimental: {
    esmExternals: true
  }
};

const plugins = [
  // Add more Next.js plugins to this list if needed.
  withNx,
];

module.exports = composePlugins(...plugins)(nextConfig);

