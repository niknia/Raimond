# راهنمای پیشرفته SfrGender با dkd-query (پوشش کامل امکانات و سناریوهای خاص)

این راهنما نحوه پیاده‌سازی حرفه‌ای سرویس SfrGender را با استفاده از تمام امکانات پکیج dkd-query و همچنین افزودن endpointهای سفارشی (غیر CRUD) به صورت گام‌به‌گام و با مثال‌های عملی توضیح می‌دهد.

---

## ۱. مدل‌های TypeScript (DTOs)

ابتدا مدل‌های داده را مطابق با ساختار Swagger تعریف کنید:

```ts
// model.ts
import { BaseEntity } from '@dkd-query/types/base';

export interface SfrGenderDto extends BaseEntity {
  createBy?: number | null;
  createTime?: string | null;
  modifyBy?: number | null;
  modifyTime?: string | null;
  name?: string | null;
}

export interface SfrGenderCreationDto {
  name?: string | null;
}

export interface SfrGenderUpdationDto {
  name?: string | null;
}
```

---

## ۲. تعریف endpointها با buildResourceEndpoints و UriString

برای ساخت endpointها به صورت استاندارد و قابل نگهداری، از `buildResourceEndpoints` و `UriString` استفاده کنید:

```ts
import { buildResourceEndpoints } from '@dkd-query/utils/endpointBuilder';
import { UriString } from '@dkd-axios';
import { SfrGenderDto } from './model';

const baseUrl = new UriString('/BaseInfo/api/sfrgenders');
const endpoints = buildResourceEndpoints<SfrGenderDto>(baseUrl);
```

---

## ۳. ساخت سرویس CRUD با Result و ResultPage

سرویس را با استفاده از CrudService و endpointهای ساخته‌شده ایجاد کنید. خروجی متدها از نوع `Result<T>` یا `ResultPage<T>` خواهد بود:

```ts
import { CrudService } from '@dkd-query/services/crud';
import { Result, ResultPage } from '@dkd-query/types/base';

export class SfrGenderService extends CrudService<SfrGenderDto> {
  constructor() {
    super({ baseUrl: baseUrl.toPath(), endpoints });
  }
}

export const sfrGenderService = new SfrGenderService();
```

---

## ۴. استفاده از هوک‌های React Query

برای اتصال سرویس به React:

```ts
import { useCrudQueries } from '@dkd-query/hooks/useCrud';
import { sfrGenderService } from './service';

export const useSfrGender = () => useCrudQueries(sfrGenderService);
```

### مثال استفاده در یک کامپوننت:

```tsx
const { useGetAll } = useSfrGender();
const { data, isLoading, error } = useGetAll();

if (data) {
  // data: Result<SfrGenderDto[]>
  const genders = data.result;
}
```

### صفحه‌بندی:
```tsx
const { useGetPaginated } = useSfrGender();
const { data } = useGetPaginated({ page: 1, limit: 10 });

if (data) {
  // data: ResultPage<SfrGenderDto>
  const items = data.result.data;
  const total = data.result.totalCount;
}
```

---

## ۵. افزودن endpoint سفارشی (غیر CRUD)

فرض کنید سرویس شما یک endpoint خاص دارد که در CrudService نیست (مثلاً جستجو بر اساس نام):

### ۱. افزودن endpoint به endpoints:
```ts
const endpoints = {
  ...buildResourceEndpoints<SfrGenderDto>(baseUrl),
  getByName: (name: string) => `${baseUrl.toPath()}/by-name/${name}`,
};
```

### ۲. افزودن متد به سرویس:
```ts
export class SfrGenderService extends CrudService<SfrGenderDto> {
  constructor() {
    super({ baseUrl: baseUrl.toPath(), endpoints });
  }

  getByName(name: string) {
    // خروجی: Promise<Result<SfrGenderDto[]>>
    return this.get<Result<SfrGenderDto[]>>(endpoints.getByName(name));
  }
}
```

### ۳. هوک سفارشی برای endpoint جدید:
```ts
import { useQuery } from '@tanstack/react-query';

export function useGenderByName(name: string) {
  return useQuery({
    queryKey: ['sfrGender', 'byName', name],
    queryFn: () => sfrGenderService.getByName(name),
    enabled: !!name,
  });
}
```

### استفاده در کامپوننت:
```tsx
const { data } = useGenderByName('مرد');
if (data) {
  // data: Result<SfrGenderDto[]>
  const genders = data.result;
}
```

---

## ۶. نکات و Best Practices

- همیشه مدل‌ها را با Swagger هماهنگ نگه دارید.
- از Result و ResultPage برای مدیریت خروجی‌ها استفاده کنید.
- endpointها را با buildResourceEndpoints و UriString بسازید.
- برای endpointهای سفارشی، متد جدید به سرویس اضافه کنید و هوک اختصاصی بنویسید.
- از QueryProvider پکیج dkd-query برای مدیریت context استفاده کنید.

---

## ۷. نمونه QueryProvider

```tsx
import { QueryProvider } from '@dkd-query/components/QueryProvider';

export default function App({ children }) {
  return <QueryProvider>{children}</QueryProvider>;
}
```

---

## ۸. جمع‌بندی

با این ساختار می‌توانید هر سرویس مشابهی را با سرعت و کیفیت بالا به پروژه اضافه کنید و از امکانات پیشرفته dkd-query بهره ببرید. همچنین افزودن endpointهای خاص و غیر CRUD به سادگی قابل انجام است.

---

> **پیشنهاد:** اگر نیاز به مثال‌های بیشتر یا راهنمایی برای تست و توسعه دارید، درخواست دهید تا راهنمای تکمیلی ارائه شود. 