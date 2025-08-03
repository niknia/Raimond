namespace Dkd.Infra.Text;

public sealed class SvgError(string error, int lineCount = -1, int linePosition = -1)
{
    public int LineCount { get; } = lineCount;

    public int LinePosition { get; } = linePosition;

    public string Error { get; } = error;
}
