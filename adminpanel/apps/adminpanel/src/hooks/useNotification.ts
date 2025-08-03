import { notifications } from '@mantine/notifications';

interface NotificationOptions {
  title?: string;
  message: string;
  autoClose?: number;
}

export function useNotification() {
  const showSuccess = ({ title = 'موفق', message, autoClose = 5000 }: NotificationOptions) => {
    notifications.show({
      title,
      message,
      color: 'green',
      autoClose,
    });
  };

  const showError = ({ title = 'خطا', message, autoClose = 5000 }: NotificationOptions) => {
    notifications.show({
      title,
      message,
      color: 'red',
      autoClose,
    });
  };

  const showWarning = ({ title = 'هشدار', message, autoClose = 5000 }: NotificationOptions) => {
    notifications.show({
      title,
      message,
      color: 'yellow',
      autoClose,
    });
  };

  const showInfo = ({ title = 'اطلاعات', message, autoClose = 5000 }: NotificationOptions) => {
    notifications.show({
      title,
      message,
      color: 'blue',
      autoClose,
    });
  };

  return {
    showSuccess,
    showError,
    showWarning,
    showInfo,
  };
} 