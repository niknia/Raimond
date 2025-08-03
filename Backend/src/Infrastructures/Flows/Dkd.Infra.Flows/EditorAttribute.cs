namespace Dkd.Infra.Flows;

[AttributeUsage(AttributeTargets.Property)]
public sealed class EditorAttribute(string editor) : Attribute
{
    public string Editor { get; } = editor;
}
