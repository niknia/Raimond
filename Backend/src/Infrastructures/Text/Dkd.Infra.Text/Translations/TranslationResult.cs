#pragma warning disable SA1313 // Parameter names should begin with lower-case letter

namespace Dkd.Infra.Text.Translations;

public sealed record TranslationResult(
    TranslationStatus Status,
    string? Text = null,
    string? SourceLanguage = null,
    Exception? Error = null,
    decimal EstimatedCostsInEUR = 0)
{
    public static readonly TranslationResult Unauthorized = new(TranslationStatus.Unauthorized);

    public static readonly TranslationResult NotConfigured = new(TranslationStatus.NotConfigured);

    public static readonly TranslationResult NotTranslated = new(TranslationStatus.NotTranslated);

    public static readonly TranslationResult LanguageNotSupported = new(TranslationStatus.LanguageNotSupported);

    public static TranslationResult Failed(Exception? exception = null)
    {
        return new TranslationResult(TranslationStatus.Failed, Error: exception);
    }

    public static TranslationResult Success(string text, string sourceLanguage, decimal estimatedCostsInEUR)
    {
        return new TranslationResult(TranslationStatus.Translated, text, sourceLanguage, null, estimatedCostsInEUR);
    }
}
