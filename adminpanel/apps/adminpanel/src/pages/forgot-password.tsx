import { useState } from 'react';
import { useRouter } from 'next/router';
import { useForm } from '@mantine/form';
import {
  Container,
  Grid,
  TextInput,
  Button,
  Title,
  Text,
  Anchor,
  Stack,
  Box,
} from '@mantine/core';
import { IconMail } from '@tabler/icons-react';
import { useNotification } from '../hooks/useNotification';

interface ForgotPasswordFormData {
  email: string;
}

export default function ForgotPasswordPage() {
  const router = useRouter();
  const [loading, setLoading] = useState(false);
  const { showSuccess, showError } = useNotification();
  const form = useForm<ForgotPasswordFormData>({
    initialValues: {
      email: '',
    },
    validate: {
      email: (value) => (/^\S+@\S+$/.test(value) ? null : 'ایمیل نامعتبر است'),
    },
  });

  const onSubmit = async (values: ForgotPasswordFormData) => {
    setLoading(true);
    try {
      // TODO: Implement forgot password logic
      console.log(values);
      showSuccess({ message: 'لینک بازیابی رمز عبور به ایمیل شما ارسال شد' });
      await router.push('/login');
    } catch (error) {
      console.error(error);
      showError({ message: 'خطا در ارسال لینک بازیابی رمز عبور' });
    } finally {
      setLoading(false);
    }
  };

  return (
    <Container fluid h="100vh" p={0}>
      <Grid h="100%" m={0}>
        {/* Left side - Gradient background */}
        <Grid.Col span={{ base: 12, md: 6 }} h="100%" p={0}>
          <Box
            h="100%"
            style={{
              background: 'linear-gradient(135deg, #1a365d 0%, #2a4365 100%)',
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
              padding: '2rem',
            }}
          >
            <Stack gap="xl" align="center">
              <Title order={1} c="white" ta="center">
                شبکه محافظ
              </Title>
              <Text c="white" size="lg" ta="center">
                سیستم مدیریت امنیت شبکه
              </Text>
            </Stack>
          </Box>
        </Grid.Col>

        {/* Right side - Forgot password form */}
        <Grid.Col span={{ base: 12, md: 6 }} h="100%" style={{ display: 'flex', alignItems: 'center' }}>
          <Container size="sm" w="100%" px="xl">
            <Stack gap="xl">
              <div>
                <Title order={2} ta="center" mb="md">
                  بازیابی رمز عبور
                </Title>
                <Text c="dimmed" size="sm" ta="center" mb="xl">
                  لطفا ایمیل خود را وارد کنید تا لینک بازیابی رمز عبور برای شما ارسال شود
                </Text>
              </div>

              <form onSubmit={form.onSubmit(onSubmit)}>
                <Stack gap="md">
                  <TextInput
                    required
                    label="ایمیل"
                    placeholder="your@email.com"
                    leftSection={<IconMail size={16} />}
                    {...form.getInputProps('email')}
                  />

                  <Button type="submit" loading={loading} fullWidth mt="xl">
                    ارسال لینک بازیابی
                  </Button>

                  <Text ta="center" size="sm">
                    <Anchor component="button" onClick={() => router.push('/login')}>
                      بازگشت به صفحه ورود
                    </Anchor>
                  </Text>
                </Stack>
              </form>
            </Stack>
          </Container>
        </Grid.Col>
      </Grid>
    </Container>
  );
} 