
namespace Dkd.App.Admin.Application.Contracts.Dtos;

[Serializable]
public class UserRegisterDto
{
    /// <summary>
    /// User mobile number
    /// </summary>
    public string Mobile { get; set; } = string.Empty;
    /// <summary>
    /// User password
    /// </summary>
    public string Password { get; set; } = string.Empty;
    /// <summary>
    /// User Repassword
    /// </summary>
    public string RePassword { get; set; } = string.Empty;

    /// <summary>
    /// User name
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
