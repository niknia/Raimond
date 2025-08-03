namespace Dkd.Infra.Text.RichText.Writer;

internal sealed class PlainWriter(StringBuilder stringBuilder) : IWriter
{
    public IWriter WriteLine(string text)
    {
        stringBuilder.Append(text);
        return this;
    }

    public IWriter Write(string text)
    {
        stringBuilder.Append(text);
        return this;
    }

    public IWriter WriteLine()
    {
        return this;
    }

    public IWriter EnsureLine()
    {
        return this;
    }

    public IWriter PushIndent(string indent)
    {
        return this;
    }

    public IWriter PopIndent()
    {
        return this;
    }
}
