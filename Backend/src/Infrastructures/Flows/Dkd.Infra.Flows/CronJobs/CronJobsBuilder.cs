namespace Microsoft.Extensions.DependencyInjection;

public sealed class CronJobsBuilder(IServiceCollection services)
{
    public IServiceCollection Services { get; } = services;
}
