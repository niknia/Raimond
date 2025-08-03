import { useState } from 'react';
import { useRouter } from 'next/router';
import { useForm } from '@mantine/form';
import {
  Container,
  Grid,
  PasswordInput,
  Button,
  Title,
  Text,
  Anchor,
  Stack,
  Box,
} from '@mantine/core';
import { IconLock } from '@tabler/icons-react';
import { useNotification } from '../hooks/useNotification';

interface ResetPasswordFormData {
  password: string;
  confirmPassword: string;
}

export default function ResetPasswordPage() {
  const router = useRouter();
  const [loading, setLoading] = useState(false);
  const { showSuccess, showError } = useNotification();
  const form = useForm<ResetPasswordFormData>({
    initialValues: {
      password: '',
      confirmPassword: '',
    },
    validate: {
      password: (value) => (value.length < 8 ? 'رمز عبور باید حداقل 8 کاراکتر باشد' : null),
      confirmPassword: (value, values) =>
        value !== values.password ? 'رمز عبور و تکرار آن مطابقت ندارند' : null,
    },
  });

  const onSubmit = async (values: ResetPasswordFormData) => {
    setLoading(true);
    try {
      // TODO: Implement reset password logic
      console.log(values);
      showSuccess({ message: 'رمز عبور با موفقیت تغییر کرد' });
      await router.push('/login');
    } catch (error) {
      console.error(error);
      showError({ message: 'خطا در تغییر رمز عبور' });
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

        {/* Right side - Reset password form */}
        <Grid.Col span={{ base: 12, md: 6 }} h="100%" style={{ display: 'flex', alignItems: 'center' }}>
          <Container size="sm" w="100%" px="xl">
            <Stack gap="xl">
              <div>
                <Title order={2} ta="center" mb="md">
                  بازنشانی رمز عبور
                </Title>
                <Text c="dimmed" size="sm" ta="center" mb="xl">
                  لطفا رمز عبور جدید خود را وارد کنید
                </Text>
              </div>

              <form onSubmit={form.onSubmit(onSubmit)}>
                <Stack gap="md">
                  <PasswordInput
                    required
                    label="رمز عبور جدید"
                    placeholder="رمز عبور جدید خود را وارد کنید"
                    leftSection={<IconLock size={16} />}
                    {...form.getInputProps('password')}
                  />

                  <PasswordInput
                    required
                    label="تکرار رمز عبور جدید"
                    placeholder="رمز عبور جدید را مجددا وارد کنید"
                    leftSection={<IconLock size={16} />}
                    {...form.getInputProps('confirmPassword')}
                  />

                  <Button type="submit" loading={loading} fullWidth mt="xl">
                    بازنشانی رمز عبور
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