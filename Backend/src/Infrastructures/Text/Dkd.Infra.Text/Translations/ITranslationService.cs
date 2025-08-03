namespace Dkd.Infra.Text.Translations;

public interface ITranslationService
{
    bool IsConfigured { get; }

    Task<IReadOnlyList<TranslationResult>> TranslateAsync(IEnumerable<string> texts, string targetLanguage,
        string? sourceLanguage = null,
        CancellationToken ct = default);
}
