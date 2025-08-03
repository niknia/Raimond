namespace Dkd.Infra.Repository;

public abstract class EfBasicAuditEntity : EfEntity, IBasicAuditInfo
{
    /// <summary>
    /// Creator
    /// </summary>
    public long CreateBy { get; set; }

    /// <summary>
    /// Creation time/Registration time
    /// </summary>
    public DateTime CreateTime { get; set; }
}
