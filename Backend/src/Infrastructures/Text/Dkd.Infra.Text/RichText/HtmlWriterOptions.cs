namespace Dkd.Infra.Text.RichText;

public struct HtmlWriterOptions
{
    public int Indentation { get; set; } = 4;

    public HtmlWriterOptions()
    {
        Indentation = 4;
    }
}
