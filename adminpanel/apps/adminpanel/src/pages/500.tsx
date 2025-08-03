import { BasePage } from '@/components/layouts/BasePage';
import { Title, Text, Button, Group, Container } from '@mantine/core';
import { IconRefresh } from '@tabler/icons-react';
import { useRouter } from 'next/router';

export default function ServerErrorPage() {
  const router = useRouter();

  return (
    <BasePage>
      <Container size="sm" py="xl">
        <Title order={1} ta="center" mb="xl">500 - Server Error</Title>
        <Text size="lg" ta="center" mb="xl">
          Oops! Something went wrong on our servers. We are working to fix the problem.
          Please try again later.
        </Text>
        <Group justify="center">
          <Button
            leftSection={<IconRefresh size={20} />}
            onClick={() => router.reload()}
          >
            Try Again
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