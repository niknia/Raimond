
export const dashboardStats = [
  { title: "کاربران فعال", value: "۱,۲۳۴", change: "+۱۲٪", trend: "up", color: "blue" },
  { title: "درآمد ماهانه", value: "۵,۶۷۸,۹۰۰ تومان", change: "+۸٪", trend: "up", color: "green" },
  { title: "سفارشات امروز", value: "۴۵", change: "-۳٪", trend: "down", color: "orange" },
  { title: "بازدید سایت", value: "۸,۷۶۵", change: "+۲۳٪", trend: "up", color: "purple" },
];

export const recentOrders = [
  { id: "۱۰۰۱", customer: "علی محمدی", date: "۱۴۰۲/۰۳/۱۰", amount: "۷۸۰,۰۰۰", status: "completed" },
  { id: "۱۰۰۲", customer: "سارا احمدی", date: "۱۴۰۲/۰۳/۰۹", amount: "۱,۲۵۰,۰۰۰", status: "processing" },
  { id: "۱۰۰۳", customer: "رضا کریمی", date: "۱۴۰۲/۰۳/۰۸", amount: "۴۵۰,۰۰۰", status: "completed" },
  { id: "۱۰۰۴", customer: "مریم حسینی", date: "۱۴۰۲/۰۳/۰۸", amount: "۲,۱۰۰,۰۰۰", status: "pending" },
  { id: "۱۰۰۵", customer: "امیر تهرانی", date: "۱۴۰۲/۰۳/۰۷", amount: "۶۳۰,۰۰۰", status: "cancelled" },
];

export const topProducts = [
  { id: 1, name: "گوشی موبایل سامسونگ", sales: 158, revenue: "۸۹,۷۰۰,۰۰۰", trend: "up" },
  { id: 2, name: "هدفون بی‌سیم اپل", sales: 123, revenue: "۵۸,۴۰۰,۰۰۰", trend: "down" },
  { id: 3, name: "لپ‌تاپ اچ‌پی", sales: 97, revenue: "۱۲۷,۵۰۰,۰۰۰", trend: "up" },
  { id: 4, name: "ساعت هوشمند شیائومی", sales: 85, revenue: "۳۶,۹۰۰,۰۰۰", trend: "up" },
];

export const usersList = [
  { id: "۱", name: "علی محمدی", email: "ali@example.com", role: "مدیر", status: "فعال", lastLoginDate: "۱۴۰۲/۰۳/۱۰" },
  { id: "۲", name: "سارا احمدی", email: "sara@example.com", role: "مدیر محتوا", status: "فعال", lastLoginDate: "۱۴۰۲/۰۳/۰۹" },
  { id: "۳", name: "رضا کریمی", email: "reza@example.com", role: "پشتیبانی", status: "غیرفعال", lastLoginDate: "۱۴۰۲/۰۳/۰۱" },
  { id: "۴", name: "مریم حسینی", email: "maryam@example.com", role: "بازاریاب", status: "فعال", lastLoginDate: "۱۴۰۲/۰۳/۰۸" },
  { id: "۵", name: "امیر تهرانی", email: "amir@example.com", role: "پشتیبانی", status: "فعال", lastLoginDate: "۱۴۰۲/۰۳/۰۷" },
];

export const salesData = [
  { name: "فروردین", sales: 4000, target: 2400 },
  { name: "اردیبهشت", sales: 3000, target: 2800 },
  { name: "خرداد", sales: 2000, target: 2800 },
  { name: "تیر", sales: 2780, target: 3000 },
  { name: "مرداد", sales: 1890, target: 3100 },
  { name: "شهریور", sales: 2390, target: 3200 },
  { name: "مهر", sales: 3490, target: 3300 },
];

export const userRoles = [
  { id: "۱", name: "مدیر", permissions: ["همه دسترسی‌ها"], users: 2 },
  { id: "۲", name: "مدیر محتوا", permissions: ["مدیریت محتوا", "مشاهده محصولات"], users: 5 },
  { id: "۳", name: "پشتیبانی", permissions: ["مدیریت سفارشات", "مشاهده کاربران"], users: 8 },
  { id: "۴", name: "بازاریاب", permissions: ["مشاهده گزارشات فروش"], users: 4 },
  { id: "۵", name: "کارمند", permissions: ["مشاهده داشبورد"], users: 12 },
];
