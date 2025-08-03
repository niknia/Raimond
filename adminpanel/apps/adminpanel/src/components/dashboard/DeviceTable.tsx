'use client';

import {
  Table,
  Text,
  Badge
} from '@mantine/core';
import {
  IconCircleCheck,
  IconAlertTriangle,
  IconX,
} from '@tabler/icons-react';

interface Device {
  id: string;
  name: string;
  type: string;
  ip: string;
  status: 'good' | 'warning' | 'error' | 'offline';
  lastSeen: string;
  uptime: number;
}

interface DeviceTableProps {
  devices: Device[];
}

export function DeviceTable({ devices }: DeviceTableProps) {
  const getStatusBadge = (status: string) => {
    switch (status) {
      case 'good':
        return <Badge color="green" leftSection={<IconCircleCheck size={14} />}>Good</Badge>;
      case 'warning':
        return <Badge color="yellow" leftSection={<IconAlertTriangle size={14} />}>Warning</Badge>;
      case 'error':
        return <Badge color="red" leftSection={<IconX size={14} />}>Error</Badge>;
      case 'offline':
        return <Badge color="gray" leftSection={<IconX size={14} />}>Offline</Badge>;
      default:
        return null;
    }
  };

  const formatUptime = (seconds: number) => {
    const days = Math.floor(seconds / 86400);
    const hours = Math.floor((seconds % 86400) / 3600);
    const minutes = Math.floor((seconds % 3600) / 60);
    return `${days}d ${hours}h ${minutes}m`;
  };

  return (
    <Table>
      <Table.Thead>
        <Table.Tr>
          <Table.Th>Name</Table.Th>
          <Table.Th>Type</Table.Th>
          <Table.Th>IP Address</Table.Th>
          <Table.Th>Status</Table.Th>
          <Table.Th>Last Seen</Table.Th>
          <Table.Th>Uptime</Table.Th>
        </Table.Tr>
      </Table.Thead>
      <Table.Tbody>
        {devices.map((device) => (
          <Table.Tr key={device.id}>
            <Table.Td>
              <Text fw={500}>{device.name}</Text>
            </Table.Td>
            <Table.Td>{device.type}</Table.Td>
            <Table.Td>{device.ip}</Table.Td>
            <Table.Td>{getStatusBadge(device.status)}</Table.Td>
            <Table.Td>{device.lastSeen}</Table.Td>
            <Table.Td>{formatUptime(device.uptime)}</Table.Td>
          </Table.Tr>
        ))}
      </Table.Tbody>
    </Table>
  );
} 