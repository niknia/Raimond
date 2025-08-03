# مثال‌های پیشرفته و خلاقانه dkd-redux در Next.js

در این فایل چند سناریوی پیشرفته و حرفه‌ای برای استفاده از dkd-redux در پروژه‌های Next.js آورده شده است تا امکانات و انعطاف‌پذیری این کتابخانه را به‌خوبی نمایش دهد.

---

## 1. مدیریت چند مدل با روابط (User, Product, Order)

### تعریف مدل‌ها
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
  stock: number;
}

// types/Order.ts
import type { BaseEntity } from 'dkd-redux';
export interface Order extends BaseEntity {
  userId: string;
  productIds: string[];
  total: number;
  status: 'pending' | 'paid' | 'shipped';
}
```

---

## 2. Thunk پیچیده: ثبت سفارش و بروزرسانی موجودی

```ts
// store/orderThunks.ts
import { createAsyncThunk } from '@reduxjs/toolkit';
import type { Order } from '../types/Order';
import type { Product } from '../types/Product';

export const placeOrder = createAsyncThunk<
  Order,
  { userId: string; productIds: string[] },
  { state: any }
>('orders/placeOrder', async ({ userId, productIds }, { getState, dispatch }) => {
  // فرض: API ثبت سفارش و بروزرسانی موجودی
  const products: Product[] = productIds.map(id => getState().products.entities[id]);
  const total = products.reduce((sum, p) => sum + p.price, 0);
  // ثبت سفارش
  const orderRes = await fetch('/api/orders', {
    method: 'POST',
    body: JSON.stringify({ userId, productIds, total })
  });
  const order = await orderRes.json();
  // بروزرسانی موجودی محصولات
  await Promise.all(
    products.map(p =>
      fetch(`/api/products/${p.id}/stock`, {
        method: 'PATCH',
        body: JSON.stringify({ stock: p.stock - 1 })
      })
    )
  );
  return order;
});
```

---

## 3. ساخت اسلایس با extraReducers و optimistic update

```ts
// store/orderSlice.ts
import { createGenericSlice } from 'dkd-redux';
import { placeOrder } from './orderThunks';
import type { Order } from '../types/Order';

export const orderSlice = createGenericSlice<Order>({
  name: 'orders',
  extraReducers: (builder) => {
    builder
      .addCase(placeOrder.pending, (state, action) => {
        // optimistic update: سفارش را به صورت موقت اضافه کن
        const tempOrder: any = {
          id: 'temp-' + Date.now(),
          userId: action.meta.arg.userId,
          productIds: action.meta.arg.productIds,
          total: 0,
          status: 'pending',
          createdAt: Date.now(),
          updatedAt: Date.now(),
          version: 1
        };
        state.entities[tempOrder.id] = tempOrder;
        state.ids.push(tempOrder.id);
      })
      .addCase(placeOrder.fulfilled, (state, action) => {
        // حذف optimistic و جایگزینی با سفارش واقعی
        state.ids = state.ids.filter(id => !id.startsWith('temp-'));
        state.entities = Object.fromEntries(
          Object.entries(state.entities).filter(([id]) => !id.startsWith('temp-'))
        );
        state.entities[action.payload.id] = action.payload;
        state.ids.push(action.payload.id);
      })
      .addCase(placeOrder.rejected, (state, action) => {
        // حذف optimistic در صورت خطا
        state.ids = state.ids.filter(id => !id.startsWith('temp-'));
        state.entities = Object.fromEntries(
          Object.entries(state.entities).filter(([id]) => !id.startsWith('temp-'))
        );
        state.error = action.error.message || 'خطا در ثبت سفارش';
      });
  }
});
```

---

## 4. استفاده از middleware سفارشی برای لاگ‌گیری و مدیریت خطا

```ts
// store/loggerMiddleware.ts
import type { Middleware } from '@reduxjs/toolkit';

export const loggerMiddleware: Middleware = store => next => action => {
  console.log('اکشن اجرا شد:', action.type, action);
  return next(action);
};

export const errorMiddleware: Middleware = store => next => action => {
  const result = next(action);
  if (store.getState().orders.error) {
    alert('خطا در سفارش: ' + store.getState().orders.error);
  }
  return result;
};
```

---

## 5. ساخت استور با چند اسلایس و middleware سفارشی و preloadedState (برای SSR)

```ts
// store/index.ts
import { configureGenericStore } from 'dkd-redux';
import { userReducer } from './userSlice';
import { productReducer } from './productSlice';
import { orderReducer } from './orderSlice';
import { loggerMiddleware, errorMiddleware } from './loggerMiddleware';

export const store = configureGenericStore(
  {
    users: userReducer,
    products: productReducer,
    orders: orderReducer
  },
  typeof window === 'undefined' ? globalThis.__PRELOADED_STATE__ : undefined,
  {
    middleware: [loggerMiddleware, errorMiddleware],
    devTools: true
  }
);
```

---

## 6. هوک سفارشی برای انتخاب داده‌های مشتق‌شده (سفارشات کاربر)

```ts
// hooks/useUserOrders.ts
import { useEntityStore } from 'dkd-redux';
import type { Order } from '../types/Order';

export function useUserOrders(userId: string) {
  const { entities, ids } = useEntityStore<Order>('orders');
  return ids
    .map(id => entities[id])
    .filter(order => order.userId === userId);
}
```

---

## 7. استفاده در صفحه Next.js با SSR و هیدراسیون

```tsx
// app/orders/page.tsx
'use client';
import React, { useEffect } from 'react';
import { Provider } from 'react-redux';
import { store } from '../store';
import { useUserOrders } from '../hooks/useUserOrders';
import { placeOrder } from '../store/orderThunks';

function OrdersList({ userId }: { userId: string }) {
  const orders = useUserOrders(userId);
  return (
    <ul>
      {orders.map(order => (
        <li key={order.id}>{order.status} - {order.total} تومان</li>
      ))}
    </ul>
  );
}

export default function OrdersPage() {
  // فرض: userId از session یا props گرفته می‌شود
  const userId = 'u1';
  useEffect(() => {
    // ثبت سفارش تستی
    store.dispatch(placeOrder({ userId, productIds: ['p1', 'p2'] }));
  }, []);
  return (
    <Provider store={store}>
      <OrdersList userId={userId} />
    </Provider>
  );
}
```

---

## جمع‌بندی
این مثال‌ها نشان می‌دهند که چگونه می‌توانید با dkd-redux:
- چند مدل مرتبط را مدیریت کنید
- عملیات async پیچیده و optimistic update داشته باشید
- middleware سفارشی اضافه کنید
- داده‌های مشتق‌شده را با هوک‌های سفارشی انتخاب کنید
- SSR و هیدراسیون را به راحتی پیاده‌سازی کنید

این انعطاف‌پذیری و قدرت، dkd-redux را به ابزاری مناسب برای پروژه‌های پیشرفته Next.js تبدیل می‌کند. 