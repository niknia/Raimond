using Dkd.Infra.Text.Translations;
using Dkd.Infra.Text.Translations.DeepL;
using Microsoft.Extensions.Configuration;


namespace Microsoft.Extensions.DependencyInjection;

public static class DeepLTranslationsServiceExtensions
{
    public static IServiceCollection AddDeepLTranslations(
        this IServiceCollection services,
        IConfigurationSection deeplSection,
        ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(services));
        ArgumentNullException.ThrowIfNull(deeplSection, nameof(deeplSection));

        if (services.HasRegistered(nameof(AddDeepLTranslations)))
        {
            return services;
        }

        services.AddHttpClient("DeepL");
        services.Configure<DeepLTranslationOptions>(deeplSection);
        services.AddTranslations();

        switch (serviceLifetime)
        {
            case ServiceLifetime.Singleton:
                services.AddSingleton<ITranslationService, DeepLTranslationService>();
                break;
            case ServiceLifetime.Scoped:
                services.AddScoped<ITranslationService, DeepLTranslationService>();
                break;
            case ServiceLifetime.Transient:
                services.AddTransient<ITranslationService, DeepLTranslationService>();
                break;
        }

        return services;
    }
}
