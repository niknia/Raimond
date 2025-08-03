namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Department tree
/// </summary>
[Serializable]
public class OrganizationTreeDto : OrganizationDto
{
    public List<OrganizationTreeDto> Children { get; set; } = [];
}
