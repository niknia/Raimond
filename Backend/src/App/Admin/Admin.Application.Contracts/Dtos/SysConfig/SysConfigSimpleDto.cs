namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// System configuration
/// </summary>
[Serializable]
public class SysConfigSimpleDto
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
}
