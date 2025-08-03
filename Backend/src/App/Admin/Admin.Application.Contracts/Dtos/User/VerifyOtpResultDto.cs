
namespace Dkd.App.Admin.Application.Contracts.Dtos;
public class VerifyOtpResultDto : IDto
{
    public VerifyOtpResultDto() 
    {
    }

    /// <summary>
    /// شناسه کاربر در صورت تأیید موفق OTP
    /// </summary>
    public long? UserId { get; set; }

    public string account { get; set; }
    /// <summary>
    /// توکن احراز هویت در صورت تأیید موفق OTP
    /// </summary>
    //public string? Token { get; set; }

    public DateTime? expiry { get; set; }
    public double timeResendToken { get; set; }
}
