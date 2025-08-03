import dynamic from 'next/dynamic';
import { Container, Grid, Title, Text, Stack, Box, useMantineTheme } from '@mantine/core';
import { useMediaQuery } from '@mantine/hooks';
import MatrixEffect from '@/components/MatrixEffect';
import { LoginForm } from '@/components/auth/LoginForm';

// const LoginForm = dynamic(() => import('../components/auth/LoginForm').then(mod => mod.LoginForm), {
//   ssr: false,
//   loading: () => (
//     <div className="flex items-center justify-center h-64">
//       <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-blue-600"></div>
//     </div>
//   ),
// });

export default function LoginPage() {

  const theme = useMantineTheme();
  const isMobile = useMediaQuery(`(max-width: ${theme.breakpoints.md}px)`);

  console.log('login.tsx is loaded');

  return (
    <Container fluid h="100vh" p={0} style={{ overflow: 'hidden' }}>
      <Grid h="100%" m={0} style={{ overflow: 'hidden' }}>
        {/* Right side - Login form centered on the page */}
        <Grid.Col 
          span={{ base: 12, md: 6 }} 
          h="100vh" 
          style={{ 
            display: 'flex', 
            alignItems: 'center', 
            justifyContent: 'center',
            overflow: 'hidden'
          }}
        >
          <Box
            style={{
              width: '100%',
              maxWidth: '400px',
              padding: '2rem',
              border: '1px solid #e9ecef',
              borderRadius: '8px',
              boxShadow: '0 2px 10px rgba(0, 0, 0, 0.1)',
              backgroundColor: 'white'
            }}
          >
            <Stack gap="xl">
              <LoginForm />
            </Stack>
          </Box>
        </Grid.Col>

        {/* Left side - MatrixEffect centered */}
        {!isMobile && (
          <Grid.Col span={6} h="100vh" p={0} style={{ overflow: 'hidden' }}>
            <Box
              h="100%"
              w="100%"
              style={{
                background: 'var(--mantine-color-body)',
                display: 'flex',
                alignItems: 'center',
                justifyContent: 'center',
                padding: '2rem',
                overflow: 'hidden',
              }}
            >
              <Box
                style={{
                  display: 'flex',
                  alignItems: 'center',
                  justifyContent: 'center',
                  width: '100%',
                  height: '100%',
                }}
              >
                <MatrixEffect 
                  style={{
                    opacity: 0.9,
                    filter: 'drop-shadow(0 4px 12px rgba(0, 0, 0, 0.15))',
                    maxWidth: '100%',
                    height: 'auto',
                  }}
                />
              </Box>
            </Box>
          </Grid.Col>
        )}
      </Grid>
    </Container>
  );
}