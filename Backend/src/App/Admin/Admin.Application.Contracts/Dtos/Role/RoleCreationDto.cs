namespace Dkd.App.Admin.Application.Contracts.Dtos;

public class RoleCreationDto : InputDto
{
    /// <summary>
    /// Role name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Role code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Role status
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// Data scope
    /// </summary>
    public int DataScope { get; set; }

    /// <summary>
    /// Order number
    /// </summary>
    public int Ordinal { get; set; }
}
