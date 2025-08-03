namespace Dkd.Shared.Repository.EfCoreEntities;

/// <summary>
/// Event tracking/processing information
/// </summary>
/// <remarks>
/// EventId, TrackerName need to create a unique composite index
/// CREATE UNIQUE INDEX UK_EventId_TrackerNam ON EventTracker(EventId, TrackerName);
/// </remarks>
public class EventTracker : EfBasicAuditEntity
{
    public long EventId { get; set; }

    public string TrackerName { get; set; } = string.Empty;
}
