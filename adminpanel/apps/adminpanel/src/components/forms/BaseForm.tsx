import { ReactNode } from 'react';
import { Form, useForm } from '@mantine/form';

interface BaseFormProps {
  children: ReactNode;
  onSubmit: (values: any) => void;
}

export function BaseForm({ children, onSubmit }: BaseFormProps) {
  const form = useForm();
  return (
    <Form form={form} onSubmit={onSubmit}>
      {children}
    </Form>
  );
} 