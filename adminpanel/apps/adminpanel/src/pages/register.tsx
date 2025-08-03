import { useState } from 'react';
import { useRouter } from 'next/router';
import { useForm } from '@mantine/form';
import {
  Container,
  Grid,
  TextInput,
  PasswordInput,
  Button,
  Title,
  Text,
  Anchor,
  Stack,
  Box,
} from '@mantine/core';
import { IconLock, IconMail, IconUser } from '@tabler/icons-react';
import { useNotification } from '../hooks/useNotification';

interface RegisterFormData {
  name: string;
  email: string;
  password: string;
  confirmPassword: string;
}

export default function RegisterPage() {
  const router = useRouter();
  const [loading, setLoading] = useState(false);
  const { showSuccess, showError } = useNotification();
  const form = useForm<RegisterFormData>({
    initialValues: {
      name: '',
      email: '',
      password: '',
      confirmPassword: '',
    },
    validate: {
      name: (value) => (value.length < 2 ? 'نام باید حداقل 2 کاراکتر باشد' : null),
      email: (value) => (/^\S+@\S+$/.test(value) ? null : 'ایمیل نامعتبر است'),
      password: (value) => (value.length < 8 ? 'رمز عبور باید حداقل 8 کاراکتر باشد' : null),
      confirmPassword: (value, values) =>
        value !== values.password ? 'رمز عبور و تکرار آن مطابقت ندارند' : null,
    },
  });

  const onSubmit = async (values: RegisterFormData) => {
    setLoading(true);
    try {
      // TODO: Implement registration logic
      console.log(values);
      showSuccess({ message: 'ثبت‌نام موفقیت‌آمیز بود' });
      await router.push('/login');
    } catch (error) {
      console.error(error);
      showError({ message: 'خطا در ثبت‌نام' });
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

        {/* Right side - Register form */}
        <Grid.Col span={{ base: 12, md: 6 }} h="100%" style={{ display: 'flex', alignItems: 'center' }}>
          <Container size="sm" w="100%" px="xl">
            <Stack gap="xl">
              <div>
                <Title order={2} ta="center" mb="md">
                  ثبت‌نام در شبکه محافظ
                </Title>
                <Text c="dimmed" size="sm" ta="center" mb="xl">
                  لطفا اطلاعات خود را برای ثبت‌نام وارد کنید
                </Text>
              </div>

              <form onSubmit={form.onSubmit(onSubmit)}>
                <Stack gap="md">
                  <TextInput
                    required
                    label="نام و نام خانوادگی"
                    placeholder="نام خود را وارد کنید"
                    leftSection={<IconUser size={16} />}
                    {...form.getInputProps('name')}
                  />

                  <TextInput
                    required
                    label="ایمیل"
                    placeholder="your@email.com"
                    leftSection={<IconMail size={16} />}
                    {...form.getInputProps('email')}
                  />

                  <PasswordInput
                    required
                    label="رمز عبور"
                    placeholder="رمز عبور خود را وارد کنید"
                    leftSection={<IconLock size={16} />}
                    {...form.getInputProps('password')}
                  />

                  <PasswordInput
                    required
                    label="تکرار رمز عبور"
                    placeholder="رمز عبور را مجددا وارد کنید"
                    leftSection={<IconLock size={16} />}
                    {...form.getInputProps('confirmPassword')}
                  />

                  <Button type="submit" loading={loading} fullWidth mt="xl">
                    ثبت‌نام
                  </Button>

                  <Text ta="center" size="sm">
                    قبلا ثبت‌نام کرده‌اید؟{' '}
                    <Anchor component="button" onClick={() => router.push('/login')}>
                      وارد شوید
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