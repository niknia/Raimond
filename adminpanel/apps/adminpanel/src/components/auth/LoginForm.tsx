'use client';

import { useEffect, useMemo, useState } from 'react';
import { useRouter, useSearchParams } from 'next/navigation';
import { useForm } from 'react-hook-form';
import {
  Button,
  Text,
  Group,
  Checkbox,
  Stack,
  useMantineColorScheme,
} from '@mantine/core';
import { TextInput, PasswordInput } from '@dkd/hook-form-mantine';
import { IconLock, IconMail } from '@tabler/icons-react';
import { useAuth } from '@/providers/AuthContext';
import Image from 'next/image';
import * as z from 'zod';
import { zodResolver } from '@hookform/resolvers/zod';
import { BASE_URL } from '@/lib/constants';

const loginSchema = z.object({
  account: z.string().min(1, 'نام کاربری الزامی است'),
  password: z.string().min(1, 'رمز عبور الزامی است'),
  rememberMe: z.boolean().optional()
});

type LoginFormData = z.infer<typeof loginSchema>;

export function LoginForm() {
  const router = useRouter();
  const [mounted, setMounted] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [isRedirecting, setIsRedirecting] = useState(false);
  const searchParams = useSearchParams();
  const { login, isLoading, isAuthenticated } = useAuth();

  const callbackUrl = useMemo(() => {
  const url = searchParams.get('callbackUrl') || '/';
  return BASE_URL ? url.replace('http://localhost:3000', BASE_URL) : url;
}, [searchParams]);

  const { control, handleSubmit, formState: { errors } } = useForm<LoginFormData>({
    defaultValues: {
      account: '',
      password: '',
      rememberMe: false
    },
    mode: 'onChange',
    resolver: zodResolver(loginSchema)
  });
  const { colorScheme } = useMantineColorScheme();

  const errorMessage = error ? 'نام کاربری یا رمز عبور اشتباه است' : '';
  const logoSrc = colorScheme === 'dark' ? '/assets/images/logoshafag-dark.svg' : '/assets/images/logoshafag.svg';

  useEffect(() => {
    setMounted(true);
  }, []);

  useEffect(() => {
    if (isAuthenticated && mounted && !isRedirecting) {
      console.log('Login page - User is authenticated, redirecting to:', callbackUrl);
      console.log('Login page - Current auth state:', { isAuthenticated, mounted });
      setIsRedirecting(true);
      router.push(callbackUrl);
    }
  }, [isAuthenticated, router, callbackUrl, mounted, isRedirecting]);

  const onSubmit = async (data: LoginFormData) => {
    if (isRedirecting) return;
    
    try {
      setError(null);
      console.log('Login page - Attempting login...');
      await login(data);
      console.log('Login page - Login successful');
    } catch (err: unknown) {
      console.error('Login page - Login error:', err);
      setError(err instanceof Error ? err.message : 'خطا در ورود به سیستم');
    }
  };

  const handleNavigation = (path: string) => {
    router.push(path);
  };

  if (!mounted) return null;

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col h-full md:pt-3 md:mt-3">
      <Stack gap="md">
        <Group justify="center" align="center" gap="xs" mb="sm">
          <Image
            src="/logo/logocompany.png"
            alt="لوگوی شرکت"
            width={192}
            height={192}
            style={{ borderRadius: 8 }}
          />
        </Group>

        <TextInput
          name="account"
          control={control}
          label="نام کاربری"
          placeholder="نام کاربری خود را وارد کنید"
          leftSection={<IconMail size={16} />}
          required
        />
        <PasswordInput
          name="password"
          control={control}
          label="رمز عبور"
          placeholder="رمز عبور خود را وارد کنید"
          leftSection={<IconLock size={16} />}
          required
        />
        <Group justify="space-between">
          <Checkbox
            label="مرا به خاطر بسپار"
            {...control.register('rememberMe')}
          />
          <Button
            variant="subtle"
            color="blue"
            size="sm"
            onClick={() => handleNavigation('/forgot-password')}
            style={{ padding: 0 }}
          >
            فراموشی رمز عبور؟
          </Button>
        </Group>

        <Button type="submit" loading={isLoading} fullWidth mt="xl">
          ورود به سیستم
        </Button>

        <Group justify="center" gap="xs">
          <Text size="sm">حساب کاربری ندارید؟</Text>
          <Button
            variant="subtle"
            color="blue"
            size="sm"
            onClick={() => handleNavigation('/register')}
            style={{ padding: 0 }}
          >
            ثبت نام
          </Button>
        </Group>
      </Stack>
    </form>
  );
} 