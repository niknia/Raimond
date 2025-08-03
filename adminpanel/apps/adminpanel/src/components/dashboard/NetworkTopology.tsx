'use client';

import { Box } from '@mantine/core';

interface Node {
  id: string;
  label: string;
  type: string;
  x: number;
  y: number;
  status: 'good' | 'warning' | 'error';
}

interface Link {
  source: string;
  target: string;
  status: 'good' | 'warning' | 'error';
}

interface NetworkTopologyProps {
  nodes: Node[];
  links: Link[];
}

export function NetworkTopology({ nodes, links }: NetworkTopologyProps) {
  return (
    <Box h={400} bg="gray.0" style={{ borderRadius: 'var(--mantine-radius-md)' }}>
      {/* Add your network topology visualization here */}
      <Box p="md">
        <Box>Network topology visualization will be implemented here</Box>
      </Box>
    </Box>
  );
} 