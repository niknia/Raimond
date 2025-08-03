namespace Dkd.Infra.Text.Translations;

public sealed class MissingKeys
{
    private const string MissingFileName = "__missing.txt";
    private readonly object lockObject = new();
    private readonly HashSet<string> missingTranslations;

    public MissingKeys()
    {
        if (File.Exists(MissingFileName))
        {
            var missing = File.ReadAllLines(MissingFileName);

            missingTranslations = new HashSet<string>(missing);
        }
        else
        {
            missingTranslations = [];
        }
    }

    public void Log(string key)
    {
        lock (lockObject)
        {
            if (!missingTranslations.Add(key))
            {
                File.AppendAllLines(MissingFileName, [key]);
            }
        }
    }
}
