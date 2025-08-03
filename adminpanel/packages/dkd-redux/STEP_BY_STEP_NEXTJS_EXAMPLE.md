# آموزش مرحله به مرحله استفاده از dkd-redux در Next.js (ساختار page structure)

در این راهنما، نحوه راه‌اندازی و استفاده از dkd-redux برای مدیریت لیست تسک‌ها (Task) در یک پروژه Next.js با ساختار page structure را مرحله به مرحله توضیح می‌دهیم.

---

## مرحله ۱: تعریف مدل Task

```ts
// types/Task.ts
import type { BaseEntity } from 'dkd-redux';
export interface Task extends BaseEntity {
  title: string;
  completed: boolean;
}
```

---

## مرحله ۲: ساخت thunk برای دریافت لیست تسک‌ها از API

```ts
// store/taskThunks.ts
import { createAsyncThunk } from '@reduxjs/toolkit';
import type { Task } from '../types/Task';

export const fetchTasks = createAsyncThunk<Task[]>('tasks/fetchAll', async () => {
  const res = await fetch('/api/tasks');
  return res.json();
});
```

---

## مرحله ۳: ساخت اسلایس تسک با extraReducers

```ts
// store/taskSlice.ts
import { createGenericSlice } from 'dkd-redux';
import { fetchTasks } from './taskThunks';
import type { Task } from '../types/Task';

export const taskSlice = createGenericSlice<Task>({
  name: 'tasks',
  extraReducers: (builder) => {
    builder
      .addCase(fetchTasks.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(fetchTasks.fulfilled, (state, action) => {
        state.loading = false;
        state.error = null;
        state.entities = {};
        state.ids = [];
        for (const task of action.payload) {
          state.entities[task.id] = task;
          state.ids.push(task.id);
        }
      })
      .addCase(fetchTasks.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'خطا در دریافت تسک‌ها';
      });
  }
});

export const taskReducer = taskSlice.reducer;
export const taskActions = taskSlice.actions;
```

---

## مرحله ۴: ساخت استور و اتصال به Next.js

```ts
// store/index.ts
import { configureGenericStore } from 'dkd-redux';
import { taskReducer } from './taskSlice';

export const store = configureGenericStore({ tasks: taskReducer });
```

---

## مرحله ۵: ساخت صفحه نمایش لیست تسک‌ها (page structure)

```tsx
// app/tasks/page.tsx
'use client';
import React, { useEffect } from 'react';
import { Provider } from 'react-redux';
import { store } from '../store';
import { useEntityStore } from 'dkd-redux';
import { fetchTasks } from '../store/taskThunks';
import type { Task } from '../types/Task';

function TaskList() {
  const { entities, ids, loading, error } = useEntityStore<Task>('tasks');
  useEffect(() => {
    store.dispatch(fetchTasks());
  }, []);
  if (loading) return <div>در حال بارگذاری...</div>;
  if (error) return <div>خطا: {error}</div>;
  return (
    <ul>
      {ids.map(id => (
        <li key={id}>
          {entities[id].title} - {entities[id].completed ? 'انجام شده' : 'در حال انجام'}
        </li>
      ))}
    </ul>
  );
}

export default function TasksPage() {
  return (
    <Provider store={store}>
      <TaskList />
    </Provider>
  );
}
```

---

## مرحله ۶: افزودن عملیات CRUD (مثال افزودن تسک)

```tsx
// app/tasks/AddTaskForm.tsx
'use client';
import React, { useState } from 'react';
import { store } from '../store';
import { taskActions } from '../store/taskSlice';

export default function AddTaskForm() {
  const [title, setTitle] = useState('');
  const handleAdd = () => {
    if (title.trim()) {
      store.dispatch(taskActions.createEntity({ title, completed: false }));
      setTitle('');
    }
  };
  return (
    <div>
      <input value={title} onChange={e => setTitle(e.target.value)} placeholder="عنوان تسک" />
      <button onClick={handleAdd}>افزودن</button>
    </div>
  );
}
```

---

## مرحله ۷: استفاده از فرم افزودن در صفحه تسک‌ها

```tsx
// app/tasks/page.tsx (ادامه)
import AddTaskForm from './AddTaskForm';

export default function TasksPage() {
  return (
    <Provider store={store}>
      <AddTaskForm />
      <TaskList />
    </Provider>
  );
}
```

---

## جمع‌بندی
در این مثال مرحله به مرحله یاد گرفتید:
- مدل خود را تعریف کنید
- عملیات async (دریافت لیست) را با thunk پیاده‌سازی کنید
- اسلایس جنریک بسازید و extraReducers اضافه کنید
- استور را راه‌اندازی و به صفحه Next.js متصل کنید
- عملیات CRUD را با اکشن‌های آماده انجام دهید

این ساختار برای پروژه‌های page structure در Next.js بسیار مناسب و توسعه‌پذیر است. 