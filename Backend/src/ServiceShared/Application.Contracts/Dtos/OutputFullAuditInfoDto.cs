namespace Dkd.Shared.Application.Contracts.Dtos;

/// <summary>
/// DTO base class
/// </summary>
[Serializable]
public abstract class OutputFullAuditInfoDto : OutputBaseAuditDto
{
    /// <summary>
    /// Last updated by
    /// </summary>
    public virtual long ModifyBy { get; set; }

    /// <summary>
    /// Last update time
    /// </summary>
    public virtual DateTime ModifyTime { get; set; }
}
