namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Role
/// </summary>
[Serializable]
public class RoleDto : RoleCreationDto
{
    /// <summary>
    /// Role ID
    /// </summary>
    public long Id { get; set; }
}
