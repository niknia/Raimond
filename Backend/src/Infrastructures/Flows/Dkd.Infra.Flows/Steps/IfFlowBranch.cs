namespace Dkd.Infra.Flows.Steps;

public sealed record IfFlowBranch
{
    public string? Condition { get; set; }

    public Guid? NextStepId { get; set; }
}
