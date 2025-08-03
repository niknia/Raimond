import { BasePage } from '@/components/layouts/BasePage';
import { Title, Text, Button, Group, Container } from '@mantine/core';
import { IconArrowLeft } from '@tabler/icons-react';
import { useRouter } from 'next/router';

export default function NotFoundPage() {
  const router = useRouter();

  return (
    <BasePage>
      <Container size="sm" py="xl">
        <Title order={1} ta="center" mb="xl">404 - Page Not Found</Title>
        <Text size="lg" ta="center" mb="xl">
          The page you are looking for might have been removed, had its name changed,
          or is temporarily unavailable.
        </Text>
        <Group justify="center">
          <Button
            leftSection={<IconArrowLeft size={20} />}
            onClick={() => router.back()}
          >
            Go Back
          </Button>
          <Button
            variant="light"
            onClick={() => router.push('/')}
          >
            Go to Homepage
          </Button>
        </Group>
      </Container>
    </BasePage>
  );
} 