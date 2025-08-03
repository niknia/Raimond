namespace Dkd.Infra.Flows.CronJobs;

public sealed class CronJobsOptions
{
    public TimeSpan UpdateInterval { get; set; } = TimeSpan.FromMinutes(10);

    public TimeSpan UpdateLimit { get; set; } = TimeSpan.FromMinutes(5);

    public TimeSpan MinimumInterval { get; set; } = TimeSpan.FromHours(2);
}
