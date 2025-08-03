namespace Dkd.Infra.Flows.Internal.Execution;

public interface IFlowErrorPolicy<TContext> where TContext : FlowContext
{
    Instant? ShouldRetry(FlowExecutionState<TContext> state, FlowExecutionStepState stepState, FlowStep step,
        Instant now);
}
