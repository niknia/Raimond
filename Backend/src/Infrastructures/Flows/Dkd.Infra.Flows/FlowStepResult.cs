namespace Dkd.Infra.Flows;

#pragma warning disable SA1313 // Parameter names should begin with lower-case letter

public sealed record FlowStepResult(FlowStepResultType Type, Guid? StepId = null, Instant Scheduled = default)
{
    public static FlowStepResult Complete()
    {
        return new FlowStepResult(FlowStepResultType.Complete);
    }

    public static FlowStepResult Next(Guid? stepId = null, Instant scheduled = default)
    {
        return new FlowStepResult(FlowStepResultType.Next, stepId, scheduled);
    }
}
