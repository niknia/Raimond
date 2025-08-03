# Advanced Usage Examples: SfrGender + dkd-query

در این راهنما، سناریوهای پیشرفته و کاربردی برای استفاده از سرویس SfrGender با پکیج dkd-query را با جزئیات و کد نمونه بررسی می‌کنیم.

---

## 1. استفاده از هوک‌های سفارشی با پارامترهای داینامیک

### جستجو بر اساس نام (Custom Endpoint)

فرض کنید endpoint جستجو بر اساس نام دارید:

```ts
// service.ts
endpoints.getByName = (name: string) => `${baseUrl}/by-name/${name}`;

export class SfrGenderService extends CrudService<SfrGenderDto> {
  getByName(name: string) {
    return this.get<SfrGenderDto[]>(endpoints.getByName(name));
  }
}
```

### هوک سفارشی:

```ts
import { useQuery } from '@tanstack/react-query';
import { sfrGenderService } from './service';

export function useGenderByName(name: string) {
  return useQuery({
    queryKey: ['sfrGender', 'byName', name],
    queryFn: () => sfrGenderService.getByName(name),
    enabled: !!name,
  });
}
```

---

## 2. مدیریت خطا و نمایش پیام

```tsx
const { useCreate } = useSfrGender();
const createGender = useCreate();

function handleCreate() {
  createGender.mutate(
    { name: 'جدید' },
    {
      onError: (error) => alert('خطا: ' + error.message),
      onSuccess: () => alert('ثبت موفق!'),
    }
  );
}
```

---

## 3. Optimistic Update (به‌روزرسانی خوش‌بینانه)

```tsx
const { useDelete } = useSfrGender();
const deleteGender = useDelete();

function handleDelete(id: number) {
  deleteGender.mutate(id, {
    onMutate: async (deletedId) => {
      // داده فعلی را ذخیره کن
      await queryClient.cancelQueries(['sfrGender', 'all']);
      const previous = queryClient.getQueryData(['sfrGender', 'all']);
      queryClient.setQueryData(['sfrGender', 'all'], (old: any) => ({
        ...old,
        result: old.result.filter((g: any) => g.id !== deletedId),
      }));
      return { previous };
    },
    onError: (err, variables, context) => {
      // بازگرداندن داده قبلی در صورت خطا
      queryClient.setQueryData(['sfrGender', 'all'], context.previous);
    },
    onSettled: () => {
      queryClient.invalidateQueries(['sfrGender', 'all']);
    },
  });
}
```

---

## 4. ادغام با کتابخانه‌های UI (مانتین، متریال، ...)

### مثال با Mantine

```tsx
import { Button, TextInput } from '@mantine/core';
import { useSfrGender } from '@/data/SfrGender/hooks';

export function AddGenderForm() {
  const [name, setName] = useState('');
  const { useCreate } = useSfrGender();
  const createGender = useCreate();

  return (
    <form onSubmit={e => { e.preventDefault(); createGender.mutate({ name }); }}>
      <TextInput label="نام جنسیت" value={name} onChange={e => setName(e.target.value)} />
      <Button type="submit" loading={createGender.isLoading}>ثبت</Button>
      {createGender.error && <div style={{color:'red'}}>{createGender.error.message}</div>}
    </form>
  );
}
```

---

## 5. ترکیب چند سرویس (Composition)

```tsx
import { useSfrGender } from '@/data/SfrGender/hooks';
import { useSfrUser } from '@/data/SfrUser/hooks';

export function UserGenderSelect({ userId }) {
  const { useGetAll: useGetAllGenders } = useSfrGender();
  const { useGetById: useGetUser } = useSfrUser();
  const { data: genders } = useGetAllGenders();
  const { data: user } = useGetUser(userId);

  return (
    <select value={user?.genderId}>
      {genders?.result?.map(g => <option key={g.id} value={g.id}>{g.name}</option>)}
    </select>
  );
}
```

---

## 6. تست هوک‌ها و سرویس‌ها

```ts
import { renderHook } from '@testing-library/react-hooks';
import { useSfrGender } from '@/data/SfrGender/hooks';

test('should fetch all genders', async () => {
  const { result, waitFor } = renderHook(() => useSfrGender().useGetAll());
  await waitFor(() => result.current.isSuccess);
  expect(result.current.data.result.length).toBeGreaterThan(0);
});
```

---

## 7. نکات پیشرفته

- می‌توانید endpointهای پیچیده‌تر (فیلتر، جستجو، ...) را به راحتی اضافه کنید.
- از قابلیت invalidate و refetch هوک‌ها برای همگام‌سازی داده‌ها استفاده کنید.
- برای هر سرویس جدید، فقط مدل و endpointها را تعریف کنید و بقیه ساختار را reuse کنید.

---

> **پیشنهاد:** اگر سناریوی خاصی مد نظر دارید، مطرح کنید تا مثال اختصاصی آن را هم اضافه کنیم. 