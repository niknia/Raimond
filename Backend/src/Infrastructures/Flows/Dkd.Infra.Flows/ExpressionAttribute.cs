namespace Dkd.Infra.Flows;

[AttributeUsage(AttributeTargets.Property)]
public sealed class ExpressionAttribute(ExpressionFallback fallback = default) : Attribute
{
    public ExpressionFallback Fallback => fallback;
}
