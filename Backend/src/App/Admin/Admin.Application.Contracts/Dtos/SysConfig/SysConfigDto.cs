namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// System configuration
/// </summary>
[Serializable]
public class SysConfigDto : SysConfigCreationDto
{
    /// <summary>
    /// Parameter ID
    /// </summary>
    public long Id { get; set; }
}
