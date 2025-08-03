import { NextResponse } from 'next/server';
import type { NextRequest } from 'next/server';
import { BASE_URL } from './lib/constants';

export async function middleware(request: NextRequest) {
  const { pathname } = request.nextUrl;
  console.log('Middleware triggered for path:', pathname);

// مسیرهای عمومی که نیازی به احراز هویت ندارند
  const publicPaths = [
    '/_next', // فایل‌های Next.js
    '/assets', // فایل‌های استاتیک
    '/images', // تصاویر
    '/logo', // لوگو
    '/fonts', // فونت‌ها
    '/favicon.ico', // فاویکون
    '/login', // صفحه ورود
    '/Register', // صفحه ثبت‌نام
    '/forgot-password', // صفحه فراموشی رمز
    '/auth/api/session', // API سشن
    '/api/auth/login', // API ورود
    '/api/admin/wbmstations/list'
  ];

// بررسی مسیرهای عمومی
  const isPublicPath = publicPaths.some(publicPath => {
    // برای مسیرهای دقیق مثل '/login' فقط تطبیق دقیق
    if (publicPath === '/login' || publicPath === '/Register' || publicPath === '/forgot-password') {
      return pathname === publicPath;
    }
    // برای بقیه مسیرها، شروع با آن مسیر کافی است
    return pathname === publicPath || pathname.startsWith(publicPath);
  });

if (isPublicPath) {
    console.log('Public route accessed:', pathname);
    
    // تنظیم هدرهای کش برای فایل‌های استاتیک
    if (pathname.startsWith('/assets') || pathname.startsWith('/images')) {
      const response = NextResponse.next();
      response.headers.set('Cache-Control', 'public, max-age=31536000, immutable');
      return response;
    }

    // مدیریت callbackUrl برای لاگین - حذف شده چون باعث redirect loop می‌شود
    // if (pathname.startsWith('/login')) {
    //   const callbackUrl = request.nextUrl.searchParams.get('callbackUrl');
    //   if (callbackUrl?.includes('localhost')) {
    //     const newUrl = new URL(callbackUrl, BASE_URL);
    //     const redirectUrl = new URL(request.nextUrl);
    //     redirectUrl.searchParams.set('callbackUrl', newUrl.toString());
    //     return NextResponse.redirect(redirectUrl);
    //   }
    // }
    
    return NextResponse.next();
  }

  // برای همه مسیرهای دیگر (غیر از publicPaths) نیاز به احراز هویت است
    try {
      // بررسی وجود توکن در کوکی‌ها
      const accessToken = request.cookies.get('accessToken')?.value;
      console.log('Access token found:', !!accessToken);
      
      // اگر توکن وجود نداشته باشد، ریدایرکت به صفحه لاگین
      if (!accessToken) {
        console.log('No access token found, redirecting to login');
      const redirectUrl = new URL('/login', request.url);
        redirectUrl.searchParams.set('callbackUrl', request.url);
        return NextResponse.redirect(redirectUrl);
      }

    console.log('Access token valid, proceeding to route');
      return NextResponse.next();
    } catch (error) {
      console.error('Middleware error:', error);
      return NextResponse.redirect(new URL('/login', request.url));
    }
}

export const config = {
  matcher: [
    /*
     * تطبیق همه مسیرها به جز:
     * - _next/static (فایل‌های استاتیک)
     * - _next/image (فایل‌های بهینه‌سازی تصویر)
     * - favicon.ico (فایل فاویکون)
     */
    '/((?!_next/static|_next/image|favicon.ico).*)',
  ],
};