using Dkd.Infra.Flows;
using Dkd.Infra.Flows.Steps;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json;
using NodaTime.Serialization.SystemTextJson;

namespace Microsoft.Extensions.DependencyInjection;

public static class FlowsServiceExtensions
{
    public static FlowsBuilder AddFlowsCore(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        return new FlowsBuilder(services);
    }

    public static FlowsBuilder AddFlows<TContext>(
        this IServiceCollection services,
        IConfigurationSection flowsSection,
        Action<FlowOptions>? configure = null,
        ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        where TContext : FlowContext
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(flowsSection, nameof(flowsSection));

        services.Configure<FlowOptions>(flowsSection);
        if (configure != null)
        {
            services.Configure(configure);
        }

        // ثبت سرویس‌ها بر اساس ServiceLifetime
        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.TryAddSingleton<IFlowManager<TContext>, DefaultFlowManager<TContext>>();
                services.TryAddSingleton<IFlowExecutor<TContext>, DefaultFlowExecutor<TContext>>();
                services.TryAddSingleton<IFlowErrorPolicy<TContext>, DefaultRetryErrorPolicy<TContext>>();
                services.TryAddSingleton<IFlowMiddleware, FlowConsoleMiddleware>();
                services.TryAddSingleton<IFlowStepRegistry, FlowStepRegistry>();
                break;
            case ServiceLifetime.Scoped:
                services.TryAddScoped<IFlowManager<TContext>, DefaultFlowManager<TContext>>();
                services.TryAddScoped<IFlowExecutor<TContext>, DefaultFlowExecutor<TContext>>();
                services.TryAddScoped<IFlowErrorPolicy<TContext>, DefaultRetryErrorPolicy<TContext>>();
                services.TryAddScoped<IFlowMiddleware, FlowConsoleMiddleware>();
                services.TryAddScoped<IFlowStepRegistry, FlowStepRegistry>();
                break;
            case ServiceLifetime.Transient:
                services.TryAddTransient<IFlowManager<TContext>, DefaultFlowManager<TContext>>();
                services.TryAddTransient<IFlowExecutor<TContext>, DefaultFlowExecutor<TContext>>();
                services.TryAddTransient<IFlowErrorPolicy<TContext>, DefaultRetryErrorPolicy<TContext>>();
                services.TryAddTransient<IFlowMiddleware, FlowConsoleMiddleware>();
                services.TryAddTransient<IFlowStepRegistry, FlowStepRegistry>();
                break;
        }

        // ثبت JsonSerializerOptions به صورت جداگانه
        services.TryAddSingleton<JsonSerializerOptions>(provider =>
        {
            var options = new JsonSerializerOptions(JsonSerializerOptions.Default);
            return options.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
        });

        // تنظیم FlowSteps پیش‌فرض
        services.Configure<FlowOptions>(options =>
        {
            options.AddStepIfNotExist(typeof(DelayFlowStep));
            options.AddStepIfNotExist(typeof(IfFlowStep));
        });

        return new FlowsBuilder(services);
    }

    public static FlowsBuilder AddFlows<TContext>(
        this IServiceCollection services,
        IConfiguration config,
        Action<FlowOptions>? configure = null,
        string configPath = "flows",
        ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        where TContext : FlowContext
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(config, nameof(config));

        var flowsSection = config.GetSection(configPath);
        return services.AddFlows<TContext>(flowsSection, configure, serviceLifetime);
    }

    public static FlowsBuilder AddWorker<TContext>(this FlowsBuilder builder)
        where TContext : FlowContext
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.Services.TryAddSingleton<FlowExecutionWorker<TContext>>();
        return builder;
    }

    public static void AddFlowStep<T>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        where T : FlowStep
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));

        services.Configure<FlowOptions>(options =>
        {
            options.Steps.Add(typeof(T));
        });

        // ثبت خود FlowStep
        switch (lifetime)
        {
            case ServiceLifetime.Singleton:
                services.TryAddSingleton<T>();
                break;
            case ServiceLifetime.Scoped:
                services.TryAddScoped<T>();
                break;
            case ServiceLifetime.Transient:
                services.TryAddTransient<T>();
                break;
        }
    }

    public static void AddFlowSteps(this IServiceCollection services, params Type[] stepTypes)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(stepTypes, nameof(stepTypes));

        services.Configure<FlowOptions>(options =>
        {
            foreach (var stepType in stepTypes)
            {
                if (typeof(FlowStep).IsAssignableFrom(stepType))
                {
                    options.Steps.Add(stepType);
                }
            }
        });
    }

    public static FlowsBuilder AddFlowStep<T>(this FlowsBuilder builder)
        where T : FlowStep
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));

        builder.Services.AddFlowStep<T>();
        return builder;
    }

    public static FlowsBuilder ConfigureFlowOptions(this FlowsBuilder builder, Action<FlowOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ArgumentNullException.ThrowIfNull(configure, nameof(configure));

        builder.Services.Configure(configure);
        return builder;
    }

    public static FlowsBuilder AddFlowSteps(this FlowsBuilder builder, params Type[] stepTypes)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ArgumentNullException.ThrowIfNull(stepTypes, nameof(stepTypes));

        builder.Services.AddFlowSteps(stepTypes);
        return builder;
    }
}
