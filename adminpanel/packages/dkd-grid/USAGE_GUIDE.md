# راهنمای جامع استفاده از DkdGrid

این راهنما نحوه استفاده از کامپوننت پیشرفته جدول داده (DkdGrid) را در پروژه‌های React/Next.js با جزئیات کامل و مثال‌های کاربردی توضیح می‌دهد.

---

## معرفی

`DkdGrid` یک جدول داده پیشرفته با قابلیت‌های مرتب‌سازی، فیلتر، صفحه‌بندی، اکشن‌های ردیف، پشتیبانی از RTL، تم سفارشی و ... است که بر پایه Mantine و React Table توسعه یافته است.

---

## نصب پیش‌نیازها

```bash
pnpm add @dkd-grid @mantine/core @mantine/hooks @tanstack/react-table
```

> توجه: این پکیج نیازمند React 18 و Mantine 7 است.

---

## ایمپورت و استفاده پایه

```tsx
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';

const columns: ColumnDef<User>[] = [
  { accessorKey: 'id', header: 'شناسه' },
  { accessorKey: 'name', header: 'نام' },
  { accessorKey: 'email', header: 'ایمیل' },
];

const data = [
  { id: 1, name: 'علی', email: 'ali@email.com' },
  { id: 2, name: 'زهرا', email: 'zahra@email.com' },
];

<DkdGrid columns={columns} data={data} />
```

---

## پراپرتی‌ها و ویژگی‌ها

| پراپرتی           | نوع                | توضیحات                                                                 |
|-------------------|--------------------|------------------------------------------------------------------------|
| columns           | ColumnDef<T>[]     | تعریف ستون‌ها (سازگار با React Table)                                  |
| data              | T[]                | آرایه داده‌ها                                                          |
| isLoading         | boolean            | نمایش لودر هنگام بارگذاری                                              |
| error             | string             | نمایش پیام خطا                                                         |
| theme             | Partial<DkdGridTheme> | تم سفارشی جدول                                                        |
| rtl               | boolean            | فعال‌سازی حالت راست‌به‌چپ                                              |
| height            | number/string      | ارتفاع جدول (پیش‌فرض: 400)                                            |
| maxHeight         | number/string      | حداکثر ارتفاع جدول                                                    |
| onRowClick        | (row) => void      | هندل کلیک روی ردیف                                                    |
| onEdit            | (row) => void      | اکشن ویرایش (ستون عملیات)                                             |
| onDelete          | (row) => void      | اکشن حذف (ستون عملیات)                                                |
| onAdd             | () => void         | اکشن افزودن (ستون عملیات)                                             |
| selectedRowId     | string             | آی‌دی ردیف انتخاب‌شده                                                 |
| initialPageSize   | number             | تعداد ردیف در هر صفحه (پیش‌فرض: 10)                                   |
| pinActionColumn   | boolean            | پین کردن ستون عملیات                                                  |
| idField           | keyof T            | کلید یکتا برای هر ردیف (پیش‌فرض: 'id')                                |
| onExport          | () => void         | اکشن خروجی گرفتن از داده‌ها                                            |
| onAdvancedSearch  | () => void         | اکشن جستجوی پیشرفته                                                   |
| ...               | ...                | سایر اکشن‌های سفارشی (راهنما، بازخورد و ...)                          |

---

## مثال‌های پیشرفته

### ۱. اکشن‌های CRUD و انتخاب ردیف

```tsx
<DkdGrid
  columns={columns}
  data={data}
  onEdit={(row) => alert('ویرایش: ' + row.name)}
  onDelete={(row) => alert('حذف: ' + row.name)}
  onAdd={() => alert('افزودن جدید')}
  selectedRowId={selectedId}
  onRowClick={(row) => setSelectedId(row.original.id)}
/>
```

### ۲. تم سفارشی و حالت تاریک

```tsx
import { createDefaultTheme } from '@dkd-grid';
import { useMantineTheme } from '@mantine/core';

const mantineTheme = useMantineTheme();
const customTheme = {
  ...createDefaultTheme(mantineTheme),
  colors: {
    ...createDefaultTheme(mantineTheme).colors,
    header: { ...createDefaultTheme(mantineTheme).colors.header, background: '#22223b', text: '#fff' },
  },
};

<DkdGrid columns={columns} data={data} theme={customTheme} />
```

### ۳. حالت RTL (راست‌به‌چپ)

```tsx
<DkdGrid columns={columns} data={data} rtl />
```

### ۴. صفحه‌بندی و اندازه جدول

```tsx
<DkdGrid columns={columns} data={data} initialPageSize={20} height={600} maxHeight={800} />
```

### ۵. اتصال به سرویس CRUD و واکشی داده (مثال با dkd-query)

```tsx
import { useCrudQueries, CrudService } from '@dkd-query';

const userService = new CrudService<User>({
  baseUrl: '/api/users',
  endpoints: {
    getAll: '/api/users',
    getById: (id) => `/api/users/${id}`,
    create: '/api/users',
    update: (id) => `/api/users/${id}`,
    delete: (id) => `/api/users/${id}`,
    getPaginated: (params) => `/api/users?${params}`,
  },
});

const { useGetAll } = useCrudQueries(userService);
const { data, isLoading, error } = useGetAll();

<DkdGrid
  columns={columns}
  data={data?.result || []}
  isLoading={isLoading}
  error={error?.message}
/>
```

---

## نکات و بهترین‌تمرین‌ها

- برای عملکرد بهتر، ستون‌ها را با useMemo تعریف کنید.
- اگر داده‌ها بزرگ هستند، صفحه‌بندی را فعال کنید.
- برای سفارشی‌سازی تم، از createDefaultTheme و پراپرتی theme استفاده کنید.
- برای پروژه‌های فارسی و عربی، پراپرتی rtl را فعال نمایید.
- اکشن‌های onEdit، onDelete و onAdd را برای نمایش ستون عملیات اضافه کنید.
- برای دسترسی‌پذیری بهتر، از selectedRowId و onRowClick استفاده کنید.
- می‌توانید هر اکشن سفارشی (onExport، onAdvancedSearch و ...) را به جدول اضافه کنید.

---

## جمع‌بندی

DkdGrid یک جدول داده قدرتمند و منعطف برای پروژه‌های React است که با امکانات پیشرفته و قابلیت سفارشی‌سازی بالا، نیازهای مختلف شما را پوشش می‌دهد.

---

> هرگونه سوال یا نیاز به مثال بیشتر داشتید، مطرح کنید تا راهنمایی تکمیلی ارائه شود. 