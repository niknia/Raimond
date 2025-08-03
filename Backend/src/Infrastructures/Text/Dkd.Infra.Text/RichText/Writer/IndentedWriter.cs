namespace Dkd.Infra.Text.RichText.Writer;

internal sealed class IndentedWriter(StringBuilder stringBuilder) : IWriter
{
    private readonly Stack<string> indents = new(10);
    private bool previousWasLine = true;

    public IWriter WriteLine(string text)
    {
        AppendIndentsCore();

        stringBuilder.AppendLine(text);
        previousWasLine = true;
        return this;
    }

    public IWriter WriteLine()
    {
        AppendIndentsCore();

        stringBuilder.AppendLine();
        previousWasLine = true;
        return this;
    }

    public IWriter Write(string text)
    {
        AppendIndentsCore();

        stringBuilder.Append(text);
        previousWasLine = false;
        return this;
    }

    public IWriter EnsureLine()
    {
        if (!previousWasLine)
        {
            WriteLine();
        }

        return this;
    }

    public IWriter PushIndent(string indent)
    {
        indents.Push(indent);
        return this;
    }

    public IWriter PopIndent()
    {
        indents.TryPop(out _);
        return this;
    }

    private void AppendIndentsCore()
    {
        if (!previousWasLine)
        {
            return;
        }

        foreach (var indent in indents)
        {
            stringBuilder.Append(indent);
        }
    }
}
