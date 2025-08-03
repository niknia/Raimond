# مثال استفاده پیشرفته از dkd-redux در Next.js

این مثال نحوه استفاده از قابلیت‌های جدید کتابخانه شامل:
- ترکیب چند اسلایس (combineReducers)
- استفاده از thunk و extraReducers برای عملیات async
را در یک پروژه Next.js نشان می‌دهد.

---

## 1. تعریف مدل‌ها

```ts
// types/User.ts
import type { BaseEntity } from 'dkd-redux';
export interface User extends BaseEntity {
  name: string;
  email: string;
}

// types/Product.ts
import type { BaseEntity } from 'dkd-redux';
export interface Product extends BaseEntity {
  title: string;
  price: number;
}
```

---

## 2. تعریف thunk برای عملیات async

```ts
// store/userThunks.ts
import { createAsyncThunk } from '@reduxjs/toolkit';
import type { User } from '../types/User';

export const fetchUsers = createAsyncThunk<User[]>('users/fetchAll', async () => {
  const res = await fetch('/api/users');
  return res.json();
});
```

---

## 3. ساخت اسلایس‌ها با extraReducers

```ts
// store/userSlice.ts
import { createGenericSlice } from 'dkd-redux';
import { fetchUsers } from './userThunks';
import type { User } from '../types/User';

export const userSlice = createGenericSlice<User>({
  name: 'users',
  extraReducers: (builder) => {
    builder
      .addCase(fetchUsers.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchUsers.fulfilled, (state, action) => {
        state.loading = false;
        state.error = null;
        state.entities = {};
        state.ids = [];
        for (const user of action.payload) {
          state.entities[user.id] = user;
          state.ids.push(user.id);
        }
      })
      .addCase(fetchUsers.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'خطا در دریافت کاربران';
      });
  }
});

export const userReducer = userSlice.reducer;
export const userActions = userSlice.actions;

// store/productSlice.ts
import { createGenericSlice } from 'dkd-redux';
import type { Product } from '../types/Product';

export const productSlice = createGenericSlice<Product>({ name: 'products' });
export const productReducer = productSlice.reducer;
export const productActions = productSlice.actions;
```

---

## 4. ساخت استور با چند اسلایس

```ts
// store/index.ts
import { configureGenericStore } from 'dkd-redux';
import { userReducer } from './userSlice';
import { productReducer } from './productSlice';

export const store = configureGenericStore(
  {
    users: userReducer,
    products: productReducer
  }
);
```

---

## 5. استفاده در Next.js (مثال کامپوننت)

```tsx
// app/users/page.tsx
'use client';
import React, { useEffect } from 'react';
import { Provider } from 'react-redux';
import { store } from '../store';
import { useEntityStore } from 'dkd-redux';
import { fetchUsers } from '../store/userThunks';
import type { User } from '../types/User';

function UserList() {
  const { entities, ids, loading, error } = useEntityStore<User>('users');
  useEffect(() => {
    store.dispatch(fetchUsers());
  }, []);
  if (loading) return <div>در حال بارگذاری...</div>;
  if (error) return <div>خطا: {error}</div>;
  return (
    <ul>
      {ids.map(id => (
        <li key={id}>{entities[id].name} - {entities[id].email}</li>
      ))}
    </ul>
  );
}

export default function UsersPage() {
  return (
    <Provider store={store}>
      <UserList />
    </Provider>
  );
}
```

---

## نکات مهم
- می‌توانید هر تعداد اسلایس دلخواه را به استور اضافه کنید.
- با استفاده از extraReducers و thunk، عملیات async را به راحتی مدیریت کنید.
- ساختار state و عملیات CRUD همچنان تایپ‌سیف و ساده باقی می‌ماند.

---

## جمع‌بندی
این مثال نشان می‌دهد که چگونه می‌توانید با نسخه جدید dkd-redux، همزمان چند مدل را مدیریت کنید و عملیات async را به صورت حرفه‌ای و ساده در پروژه Next.js پیاده‌سازی نمایید. 