namespace Dkd.Infra.Flows.CronJobs;

public interface ICronJobManager<TContext>
{
    void Subscribe(Func<CronJob<TContext>, CancellationToken, Task> handler);

    Task AddAsync(CronJob<TContext> cronJob,
        CancellationToken ct = default);

    Task RemoveAsync(string id,
        CancellationToken ct = default);

    Task UpdateAllAsync(
        CancellationToken ct = default);

    IReadOnlyList<string> GetAvailableTimezoneIds();

    bool IsValidCronExpression(string expression);

    bool IsValidTimezone(string? timezone);
}
