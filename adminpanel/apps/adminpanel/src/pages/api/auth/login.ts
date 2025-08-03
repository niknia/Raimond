import type { NextApiRequest, NextApiResponse } from 'next';
import { serialize } from 'cookie';
import { csrf } from '@dkd-axios';
import { API_URL } from '../../../lib/constants';

export default async function handler(req: NextApiRequest, res: NextApiResponse) {
  if (req.method !== 'POST') return res.status(405).json({ error: 'Method not allowed' });

  const { account, password } = req.body;

  // Validate required fields
  if (!account || !password) {
    return res.status(400).json({ error: 'Account and password are required' });
  }

  // Check if API_URL is configured
  if (!process.env.NEXT_PUBLIC_API_URL_PROD) {
    console.error('LOGIN API: API_URL is not configured');
    return res.status(500).json({ error: 'Server configuration error' });
  }

  try {
    // Generate and set CSRF token
    //  csrf.setToken();
    //  const csrfToken = csrf.getToken();

    console.log('LOGIN API: Making request to:', `${process.env.NEXT_PUBLIC_API_URL_PROD}api/auth/session`);

    // ارسال درخواست به سرور اصلی
    const apiRes = await fetch(`${process.env.NEXT_PUBLIC_API_URL_PROD}api/auth/session`, {
      method: 'POST',
      headers: {
        'accept': 'text/plain',
        'Content-Type': 'application/json',
        //  'X-CSRF-Token': csrfToken || ''
      },
      body: JSON.stringify({ account, password }),
    });

    console.log('LOGIN API: External API response status:', apiRes.status);

    if (!apiRes.ok) {
      const errorText = await apiRes.text();
      console.error('LOGIN API: External API error:', errorText);
      
      // Try to parse as JSON, fallback to text
      let errorData;
      try {
        errorData = JSON.parse(errorText);
      } catch {
        errorData = { message: errorText || 'External API error' };
      }
      
      return res.status(apiRes.status).json({ 
        error: errorData.message || `External API error: ${apiRes.status}` 
      });
    }

    const data = await apiRes.json();
    console.log('LOGIN API: External API response data:', data);

    if (!data.result?.token) {
      return res.status(400).json({ error: data.message || 'No token received from external API' });
    }

    // ست کردن کوکی HttpOnly در دامنه Next.js
    console.log('LOGIN API: Setting accessToken cookie:', data.result.token);
    res.setHeader('Set-Cookie', serialize('accessToken', data.result.token, {
      httpOnly: false,
      secure: false, // فقط برای تست لوکال
      sameSite: 'lax', // اگر cross-origin داری، 'none'
      path: '/',
      maxAge: 60 * 60 * 24 * 7,
    }));

    return res.status(200).json({ success: true });
  } catch (error) {
    console.error('LOGIN API: Unexpected error:', error);
    return res.status(500).json({ error: 'Internal server error' });
  }
} 