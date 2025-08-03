namespace Dkd.Infra.Flows.CronJobs;

public sealed record CronJob<TContext>
{
    public required string Id { get; set; }

    public required string CronExpression { get; set; }

    public required string? CronTimezone { get; set; }

    public required TContext Context { get; set; }
}
