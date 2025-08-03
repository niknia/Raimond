namespace Dkd.Infra.Flows;

public sealed class FlowStepDescriptor
{
    public Type Type { get; set; }

    public string Title { get; set; }

    public string ReadMore { get; set; }

    public string IconImage { get; set; }

    public string IconColor { get; set; }

    public string Display { get; set; }

    public string Description { get; set; }

    public bool IsObsolete { get; set; }

    public string? ObsoleteReason { get; set; }

    public List<FlowStepPropertyDescriptor> Properties { get; } = [];
}
