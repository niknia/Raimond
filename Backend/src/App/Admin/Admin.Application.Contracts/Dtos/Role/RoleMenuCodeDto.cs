namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Role, Permission
/// </summary>
[Serializable]
public class RoleMenuCodeDto : IDto
{
    /// <summary>
    /// Role ID
    /// </summary>
    public long RoleId { get; set; }

    /// <summary>
    /// Permission codes
    /// </summary>
    public string[] Perms { get; set; } = [];
}
