namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// System configuration
/// </summary>
public class SysConfigCreationDto : InputDto
{
    /// <summary>
    /// Parameter key
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Parameter name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Parameter value
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Remark
    /// </summary>
    public string Remark { get; set; } = string.Empty;
}
