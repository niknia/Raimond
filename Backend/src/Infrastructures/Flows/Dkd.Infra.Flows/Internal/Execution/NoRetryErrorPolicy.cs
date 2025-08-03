namespace Dkd.Infra.Flows.Internal.Execution;

public sealed class NoRetryErrorPolicy<TContext> : IFlowErrorPolicy<TContext> where TContext : FlowContext
{
    public Instant? ShouldRetry(FlowExecutionState<TContext> state, FlowExecutionStepState stepState, FlowStep step,
        Instant now)
    {
        return null;
    }
}
