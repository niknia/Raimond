
namespace Dkd.App.Admin.Application.Contracts.Dtos;
public class SendOtpResultDto : OperationResultDto
{
    public SendOtpResultDto(bool success, string message) : base(success, message)
    {
    }

    /// <summary>
    /// زمان باقیمانده تا امکان ارسال مجدد OTP (به ثانیه)
    /// </summary>
    public int? ResendDelaySeconds { get; set; }

    /// <summary>
    /// زمان انقضای OTP ارسال شده (اختیاری)
    /// </summary>
    public DateTime? OtpExpiryTime { get; set; }
}
