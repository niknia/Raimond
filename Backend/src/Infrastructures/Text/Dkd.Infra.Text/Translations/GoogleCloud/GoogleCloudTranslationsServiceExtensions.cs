using Dkd.Infra.Text.Translations;
using Dkd.Infra.Text.Translations.Configuration;
using Dkd.Infra.Text.Translations.GoogleCloud;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class GoogleCloudTranslationsServiceExtensions
{
    public static IServiceCollection AddGoogleCloudTranslations(
        this IServiceCollection services,
        IConfigurationSection googleCloudSection,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(googleCloudSection, nameof(googleCloudSection));

        if (services.HasRegistered(nameof(AddGoogleCloudTranslations)))
        {
            return services;
        }

        services.Configure<GoogleCloudTranslationOptions>(googleCloudSection);
        services.AddTranslations();

        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<ITranslationService, GoogleCloudTranslationService>();
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped<ITranslationService, GoogleCloudTranslationService>();
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<ITranslationService, GoogleCloudTranslationService>();
                break;
        }

        return services;
    }
}
