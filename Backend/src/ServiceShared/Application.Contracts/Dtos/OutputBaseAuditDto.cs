namespace Dkd.Shared.Application.Contracts.Dtos;

[Serializable]
public abstract class OutputBaseAuditDto : OutputDto
{
    /// <summary>
    /// Created by
    /// </summary>
    public virtual long CreateBy { get; set; }

    /// <summary>
    /// Creation time / Registration time
    /// </summary>
    public virtual DateTime CreateTime { get; set; }
}
