namespace Dkd.Infra.Flows.CronJobs.Internal;

public sealed record CronJobEntry<T>
{
    public required CronJob<T> Job { get; set; }

    public required Instant NextTime { get; set; }
}
