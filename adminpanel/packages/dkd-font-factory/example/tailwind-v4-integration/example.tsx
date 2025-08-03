
/**
 * This is an example file for documentation purposes only
 * In a real project, you would have already installed the required dependencies
 */

// Example component showing how to use Persian fonts with Tailwind v4
export default function FarsiTailwindV4Example() {
  return (
    <div className="container mx-auto p-8 rtl">
      <h1 className="text-3xl font-vazirmatn font-bold mb-6">
        نمونه استفاده از فونت‌های فارسی با Tailwind CSS v4
      </h1>
      
      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <div className="border p-4 rounded-lg">
          <h2 className="text-xl font-vazirmatn font-bold mb-3">وزیرمتن</h2>
          <p className="font-vazirmatn">
            این متن با فونت وزیرمتن نمایش داده می‌شود که فونت پیش‌فرض کتابخانه است.
          </p>
        </div>
        
        <div className="border p-4 rounded-lg">
          <h2 className="text-xl font-iransansx font-bold mb-3">ایران‌سنس</h2>
          <p className="font-iransansx">
            این متن با فونت ایران‌سنس نمایش داده می‌شود که یکی از محبوب‌ترین فونت‌های فارسی است.
          </p>
        </div>
        
        <div className="border p-4 rounded-lg">
          <h2 className="text-xl font-sahel font-bold mb-3">ساحل</h2>
          <p className="font-sahel">
            این متن با فونت ساحل نمایش داده می‌شود که یک فونت زیبا و خوانا برای متون فارسی است.
          </p>
        </div>
      </div>
    </div>
  );
}
