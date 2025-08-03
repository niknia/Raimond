
// This is an example file for documentation purposes only
// In a real Next.js project, you would import components like Image

export default function Home() {
  return (
    <main className="min-h-screen flex flex-col items-center justify-center p-8">
      <div className="max-w-3xl mx-auto text-center">
        <h1 className="text-4xl font-bold mb-6">به کتابخانه فونت‌های فارسی خوش آمدید</h1>
        <p className="text-xl mb-8">
          این یک نمونه استفاده از فونت فارسی وزیرمتن در Next.js است.
        </p>
        
        <div className="grid gap-6 md:grid-cols-2 mb-12">
          <div className="border p-6 rounded-lg shadow-sm">
            <h2 className="text-2xl font-bold mb-3">ویژگی‌های کتابخانه</h2>
            <ul className="text-right space-y-2">
              <li>• پشتیبانی از فونت‌های محبوب فارسی</li>
              <li>• بهینه‌شده برای Next.js</li>
              <li>• سازگار با ES2020 و ESM</li>
              <li>• یکپارچه با Tailwind CSS</li>
            </ul>
          </div>
          
          <div className="border p-6 rounded-lg shadow-sm">
            <h2 className="text-2xl font-bold mb-3">فونت‌های موجود</h2>
            <ul className="text-right space-y-2">
              <li>• وزیرمتن (پیش‌فرض)</li>
              <li>• ایران‌سنس</li>
              <li>• ساحل</li>
              <li>• صمیم</li>
              <li>• تنها</li>
              <li>• ناهید</li>
            </ul>
          </div>
        </div>
        
        <div className="text-sm opacity-70">
          با استفاده از کتابخانه فارسی فونت فکتوری
        </div>
      </div>
    </main>
  );
}
