namespace Dkd.Infra.Text.Translations.GoogleCloud;

public sealed class GoogleCloudTranslationOptions
{
    public string ProjectId { get; set; }

    public decimal CostsPerCharacterInEUR { get; set; } = 20m / 1_000_000;

    public Dictionary<string, string> Mapping { get; set; }
}
