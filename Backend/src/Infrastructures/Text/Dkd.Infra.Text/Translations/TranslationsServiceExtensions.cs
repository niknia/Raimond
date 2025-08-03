using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Dkd.Infra.Text.Translations;

public static class TranslationsServiceExtensions
{
    public static IServiceCollection AddTranslations(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.TryAddSingleton<ITranslator, Translator>();

        return services;
    }
}
