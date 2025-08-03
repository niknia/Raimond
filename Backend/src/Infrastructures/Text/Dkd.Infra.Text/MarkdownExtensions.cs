using Markdig;

namespace Dkd.Infra.Text;

public static class MarkdownExtensions
{
    public static string Markdown2Text(this string markdown)
    {
        return Markdown.ToPlainText(markdown).Trim(' ', '\n', '\r');
    }
}
