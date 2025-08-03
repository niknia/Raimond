namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Department
/// </summary>
public class OrganizationCreationDto : InputDto
{
    /// <summary>
    /// Parent ID
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// Department code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Department full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Department status
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// Order number
    /// </summary>
    public int Ordinal { get; set; }
}
