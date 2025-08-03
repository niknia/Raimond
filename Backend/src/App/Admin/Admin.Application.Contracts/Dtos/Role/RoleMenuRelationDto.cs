namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Menu-Role relation
/// </summary>
[Serializable]
public class RoleMenuRelationDto : IDto
{
    /// <summary>
    /// Menu ID
    /// </summary>
    public long MenuId { get; set; }

    /// <summary>
    /// Role ID
    /// </summary>
    public long RoleId { get; set; }
}
