namespace Dkd.Infra.Flows.Internal.Execution;

public sealed class FlowExecutionState<TContext> where TContext : FlowContext
{
    public required Guid InstanceId { get; set; }

    public required string OwnerId { get; set; }

    public required string DefinitionId { get; set; }

    public required FlowDefinition Definition { get; set; }

    public required TContext Context { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ScheduleKey { get; set; } = string.Empty;

    public int SchedulePartition { get; set; }

    public Dictionary<Guid, FlowExecutionStepState> Steps { get; set; } = [];

    public Guid? NextStepId { get; set; }

    public Instant? NextRun { get; set; }

    public Instant Created { get; set; }

    public Instant Completed { get; set; }

    public Instant Expires { get; set; }

    public FlowExecutionStatus Status { get; set; }

    public FlowExecutionStepState Step(Guid id)
    {
        if (!Steps.TryGetValue(id, out var stepState))
        {
            stepState = new FlowExecutionStepState();
            Steps[id] = stepState;
        }

        return stepState;
    }

    public void Failed(Instant now)
    {
        Status = FlowExecutionStatus.Failed;
        NextRun = null;
        NextStepId = null;
        Completed = now;
    }

    public void Complete(Instant now)
    {
        Completed = now;
        NextRun = null;
        NextStepId = null;
        Status = FlowExecutionStatus.Completed;
    }

    public void Next(Guid nextId, Instant scheduleAt)
    {
        NextRun = scheduleAt;
        NextStepId = nextId;
        Step(nextId).Status = FlowExecutionStatus.Scheduled;
    }

    public Guid? GetNextStep(FlowStepDefinition currentStep, Guid? nextId)
    {
        var actualNext = nextId ?? currentStep.NextStepId ?? default;

        if (actualNext == default)
        {
            return null;
        }

        if (!Definition.Steps.ContainsKey(actualNext))
        {
            return null;
        }

        if (Step(actualNext).Status != FlowExecutionStatus.Pending)
        {
            return null;
        }

        return actualNext;
    }
}
