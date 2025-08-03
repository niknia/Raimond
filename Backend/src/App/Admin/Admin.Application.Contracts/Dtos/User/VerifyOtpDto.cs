namespace Dkd.App.Admin.Application.Contracts.Dtos;
public class VerifyOtpDto
{
    /// <summary>
    /// شماره موبایل کاربر
    /// </summary>
    public string MobileNo { get; set; }

    /// <summary>
    /// کد OTP دریافتی توسط کاربر
    /// </summary>
    public string Otp { get; set; }
}
