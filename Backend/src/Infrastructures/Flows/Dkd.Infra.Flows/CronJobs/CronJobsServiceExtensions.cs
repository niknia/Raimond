namespace Microsoft.Extensions.DependencyInjection;

public static class CronJobsServiceExtensions
{
    public static CronJobsBuilder AddCronJobsCore(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        return new CronJobsBuilder(services);
    }

    public static CronJobsBuilder AddCronJobs<TContext>(this IServiceCollection services,
        IConfigurationSection cronJobsSection,
        Action<CronJobsOptions>? configure = null,
        ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(cronJobsSection, nameof(cronJobsSection));

        services.Configure<CronJobsOptions>(cronJobsSection);

        if (configure != null)
        {
            services.Configure(configure);
        }

        // ثبت سرویس‌ها بر اساس ServiceLifetime
        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.TryAddSingleton<ICronJobManager<TContext>, DefaultCronJobManager<TContext>>();
                services.TryAddSingleton<ICronTimezoneProvider, NodaCronTimezoneProvider>();
                break;
            case ServiceLifetime.Scoped:
                services.TryAddScoped<ICronJobManager<TContext>, DefaultCronJobManager<TContext>>();
                services.TryAddScoped<ICronTimezoneProvider, NodaCronTimezoneProvider>();
                break;
            case ServiceLifetime.Transient:
                services.TryAddTransient<ICronJobManager<TContext>, DefaultCronJobManager<TContext>>();
                services.TryAddTransient<ICronTimezoneProvider, NodaCronTimezoneProvider>();
                break;
        }

        // ثبت JsonSerializerOptions به صورت جداگانه
        services.TryAddSingleton<JsonSerializerOptions>(provider =>
        {
            var options = new JsonSerializerOptions(JsonSerializerOptions.Default);
            return options.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
        });

        return new CronJobsBuilder(services);
    }

    public static CronJobsBuilder AddWorker<TContext>(this CronJobsBuilder builder)
    {
        builder.Services.AddSingleton<CronJobWorker<TContext>>();

        return builder;
    }
}
