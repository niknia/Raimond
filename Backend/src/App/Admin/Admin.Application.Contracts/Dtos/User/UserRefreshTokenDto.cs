namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Refresh token entity
/// </summary>
public class UserRefreshTokenDto : InputDto
{
    /// <summary>
    /// Refresh token
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;
}
