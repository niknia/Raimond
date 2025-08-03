#pragma warning disable CA1822 // Mark members as static

namespace Dkd.Infra.Flows;

public abstract record FlowStep
{
    public virtual ValueTask ValidateAsync(FlowValidationContext validationContext, AddStepError addError,
        CancellationToken ct)
    {
        return default;
    }

    public virtual ValueTask PrepareAsync(FlowExecutionContext executionContext,
        CancellationToken ct)
    {
        return default;
    }

    public abstract ValueTask<FlowStepResult> ExecuteAsync(FlowExecutionContext executionContext,
        CancellationToken ct);

    public FlowStepResult Next()
    {
        return FlowStepResult.Next();
    }

    public FlowStepResult Next(Guid stepId)
    {
        return FlowStepResult.Next(stepId);
    }

    public FlowStepResult NextDelayed(Instant scheduled)
    {
        return FlowStepResult.Next(scheduled: scheduled);
    }

    public FlowStepResult Complete()
    {
        return FlowStepResult.Complete();
    }
}
