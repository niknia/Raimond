namespace Dkd.Infra.Text.Translations.DeepL;

public sealed class DeepLTranslationOptions
{
    public string AuthKey { get; set; }

    public decimal CostsPerCharacterInEUR { get; set; } = 20m / 1_000_000;

    public Dictionary<string, string> Mapping { get; set; }
}
