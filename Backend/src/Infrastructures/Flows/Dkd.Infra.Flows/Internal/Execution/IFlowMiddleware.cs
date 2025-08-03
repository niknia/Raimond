#pragma warning disable MA0048 // File name must match type name

namespace Dkd.Infra.Flows.Internal.Execution;

public delegate ValueTask<FlowStepResult> NextStepDelegate();

public delegate ValueTask<FlowStepResult> PipelineDelegate(FlowExecutionContext executionContext, CancellationToken ct);

public interface IFlowMiddleware
{
    ValueTask<FlowStepResult> InvokeAsync(FlowExecutionContext executionContext, NextStepDelegate next,
        CancellationToken ct);
}
