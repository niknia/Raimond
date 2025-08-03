namespace Dkd.Infra.Flows;

[AttributeUsage(AttributeTargets.Class)]
public sealed class FlowStepAttribute : Attribute
{
    public string Title { get; set; }

    public string ReadMore { get; set; }

    public string IconImage { get; set; }

    public string IconColor { get; set; }

    public string Display { get; set; }

    public string Description { get; set; }
}
