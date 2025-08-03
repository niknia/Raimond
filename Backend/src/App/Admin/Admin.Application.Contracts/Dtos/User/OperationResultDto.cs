
namespace Dkd.App.Admin.Application.Contracts.Dtos;
public class OperationResultDto
{
    public OperationResultDto(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    /// <summary>
    /// نشان‌دهنده موفقیت‌آمیز بودن عملیات
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// پیام مربوط به نتیجه عملیات
    /// </summary>
    public string Message { get; set; }
}
