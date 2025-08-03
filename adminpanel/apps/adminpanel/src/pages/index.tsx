'use client';

import React, { useEffect, useState } from 'react';
import {
  Title,
  Text,
  Card,
  Grid,
  Group,
  Stack,
  Progress,
  Badge,
  Box,
  Paper,
} from '@mantine/core';
import {
  IconServer,
  IconAlertTriangle,
  IconAlertCircle,
  IconClock,
  IconActivity,
  IconBolt,
  IconCpu,
  IconDatabase,
} from '@tabler/icons-react';
import { BasePage } from '@/components/layouts/BasePage';
import { useAuth } from '@/providers/AuthContext';
import { useRouter } from 'next/navigation';

type QuickStats = {
  throughput: string;
  storage: string;
  services: string;
  uptime: string;
};

type DashboardData = {
  stats: any;
  systemResources: any;
  quickStats: QuickStats;
  recentAlerts: any[];
};


interface StatCardProps {
  title: string;
  value: string | number;
  icon: React.ComponentType<{ size: number; color: string }>;
  iconColor: string;
  delta: number;
  deltaType: 'increase' | 'decrease';
}

interface ResourceCardProps {
  title: string;
  value: number;
  color: string;
}

interface QuickStatCardProps {
  title: string;
  value: string | number;
  icon: React.ComponentType<{ size: number; color: string }>;
  iconColor: string;
}

interface AlertCardProps {
  type: 'error' | 'warning' | 'info';
  title: string;
  device: string;
  time: string;
}

export default function IndexPage() {
  const { isAuthenticated, isLoading, user } = useAuth();
  const [mounted, setMounted] = useState(false);
  const router = useRouter();


  useEffect(() => {
    if (mounted && !isLoading && !isAuthenticated) {
      console.log('Home page - User not authenticated, redirecting to login');
      console.log('Home page - Current auth state:', { isAuthenticated, isLoading, mounted });
      router.push(`/login?callbackUrl=${encodeURIComponent(window.location.href)}`);
    }
  }, [isLoading, isAuthenticated, router, mounted]);
  const StatCard = ({ title, value, icon: Icon, iconColor, delta, deltaType }: StatCardProps) => (
    <Card withBorder p="md">
      <Group justify="space-between" mb="xs">
        <Text size="sm" c="dimmed">{title}</Text>
        <Icon size={20} color={iconColor} />
      </Group>
      <Group align="flex-end" gap="xs">
        <Text size="xl" fw={700}>{value}</Text>
        <Badge
          color={deltaType === 'increase' ? 'red' : 'green'}
          variant="light"
        >
          {deltaType === 'increase' ? '+' : '-'}{delta}
        </Badge>
      </Group>
    </Card>
  );

  const ResourceCard = ({ title, value, color }: ResourceCardProps) => (
    <Box>
      <Group justify="space-between" mb={4}>
        <Text size="sm" c="dimmed">{title}</Text>
        <Text size="sm" fw={500}>{value}%</Text>
      </Group>
      <Progress value={value} color={color} size="sm" />
    </Box>
  );

  const QuickStatCard = ({ title, value, icon: Icon, iconColor }: QuickStatCardProps) => (
    <Paper p="md" bg="gray.0">
      <Group gap="xs" mb={4}>
        <Icon size={16} color={iconColor} />
        <Text size="sm" c="dimmed">{title}</Text>
      </Group>
      <Text size="lg" fw={700}>{value}</Text>
    </Paper>
  );

  const AlertCard = ({ type, title, device, time }: AlertCardProps) => {
    const colors = {
      error: { bg: 'red.0', text: 'red.8', icon: 'red.6' },
      warning: { bg: 'yellow.0', text: 'yellow.8', icon: 'yellow.6' },
      info: { bg: 'blue.0', text: 'blue.8', icon: 'blue.6' }
    };

    const icons = {
      error: IconAlertCircle,
      warning: IconAlertTriangle,
      info: IconActivity
    };

    const Icon = icons[type as keyof typeof icons];
    const color = colors[type as keyof typeof colors];

    return (
      <Paper p="md" bg={color.bg}>
        <Group gap="xs">
          <Icon size={20} color={color.icon} />
          <Box>
            <Text size="sm" fw={500} c={color.text}>{title}</Text>
            <Text size="xs" c={color.text}>{device} • {time}</Text>
          </Box>
        </Group>
      </Paper>
    );
  };

  return (
    <BasePage>
      <Stack gap="lg">
        <Box>
          <Title order={2}>Network Dashboard</Title>
          <Text c="dimmed">Monitor your network performance and health</Text>
        </Box>

        
      </Stack>
    </BasePage>
  );
}
