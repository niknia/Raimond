using Dkd.Infra.Text.RichText.Model;

namespace Dkd.Infra.Text.RichText;

public sealed class TextVisitor(StringBuilder stringBuilder, int maxLength) : Visitor
{
    private readonly int maxLength = maxLength;
    private readonly StringBuilder stringBuilder = stringBuilder;
    private NodeType previousNodeType;

    public static void Render(INode node, StringBuilder stringBuilder, int maxLength = int.MaxValue)
    {
        new TextVisitor(stringBuilder, maxLength).VisitRoot(node);
    }

    protected override void Visit(INode node)
    {
        base.Visit(node);
        previousNodeType = node.Type;
    }

    protected override void VisitText(INode node)
    {
        if (string.IsNullOrWhiteSpace(node.Text))
        {
            return;
        }

        if (stringBuilder.Length > 0 && previousNodeType != NodeType.Text)
        {
            stringBuilder.Append(' ');
        }

        var span = node.Text.AsSpan();

        var spaceLeft = maxLength - stringBuilder.Length;
        if (spaceLeft > 0 && span.Length > spaceLeft)
        {
            span = span[..spaceLeft];
        }

        stringBuilder.Append(span);
    }

    protected override void VisitChildren(INode node)
    {
        IterateChildren(node, this, static (child, self) =>
        {
            if (self.stringBuilder.Length < self.maxLength)
            {
                self.Visit(child);
            }
        });
    }
}
