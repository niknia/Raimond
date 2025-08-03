namespace Dkd.Infra.Repository;

public abstract class EfFullAuditEntity : EfEntity, IFullAuditInfo
{
    /// <summary>
    /// Creator
    /// </summary>
    public long CreateBy { get; set; }

    /// <summary>
    /// Creation time/Registration time
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// Last updater
    /// </summary>
    public long? ModifyBy { get; set; }

    /// <summary>
    /// Last update time
    /// </summary>
    public DateTime? ModifyTime { get; set; }
}
