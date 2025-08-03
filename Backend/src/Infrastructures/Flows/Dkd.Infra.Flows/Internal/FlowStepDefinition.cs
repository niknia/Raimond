namespace Dkd.Infra.Flows.Internal;

public sealed record FlowStepDefinition
{
    public Guid? NextStepId { get; set; }

    public string? Name { get; set; }

    public bool IgnoreError { get; set; }

    public FlowStep Step { get; set; }
}
