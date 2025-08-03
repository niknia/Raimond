namespace Dkd.Infra.Flows.Internal.Execution;

public interface IFlowExecutionCallback<TContext> where TContext : FlowContext
{
    Task OnUpdateAsync(FlowExecutionState<TContext> state,
        CancellationToken ct);
}
