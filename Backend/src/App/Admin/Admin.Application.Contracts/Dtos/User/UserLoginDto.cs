namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Login Information
/// </summary>
public class UserLoginDto : InputDto
{
    /// <summary>
    /// Account
    /// </summary>
    public string Account { get; set; } = string.Empty;

    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
