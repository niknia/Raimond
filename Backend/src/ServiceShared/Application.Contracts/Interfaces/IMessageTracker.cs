using Dkd.Shared.Application.Contracts.Enums;

namespace Dkd.Shared.Application.Contracts.Interfaces;

public interface IMessageTracker
{
    TrackerKind Kind { get; }
    Task<bool> HasProcessedAsync(long eventId, string trackerName);
    Task MarkAsProcessedAsync(long eventId, string trackerName);
}
