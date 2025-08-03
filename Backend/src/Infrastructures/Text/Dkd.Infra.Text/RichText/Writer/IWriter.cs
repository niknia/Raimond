namespace Dkd.Infra.Text.RichText.Writer;

internal interface IWriter
{
    IWriter PopIndent();

    IWriter PushIndent(string indent);

    IWriter Write(string text);

    IWriter WriteLine();

    IWriter WriteLine(string text);

    IWriter EnsureLine();
}
