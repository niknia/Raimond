namespace Dkd.Infra.Flows.Internal.Execution;

public interface IFlowExecutor<TContext> where TContext : FlowContext
{
    FlowExecutionState<TContext> CreateState(CreateFlowInstanceRequest<TContext> request);

    Task ValidateAsync(FlowDefinition definition, AddError addError,
        CancellationToken ct);

    Task ValidateAsync(FlowStep step, AddError addError,
        CancellationToken ct);

    Task SimulateAsync(FlowExecutionState<TContext> state,
        CancellationToken ct);

    Task ExecuteAsync(FlowExecutionState<TContext> state,
        CancellationToken ct);
}
