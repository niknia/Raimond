namespace Dkd.Infra.Flows.Internal;

internal class FlowConsoleMiddleware : IFlowMiddleware
{
    public async ValueTask<FlowStepResult> InvokeAsync(FlowExecutionContext executionContext, NextStepDelegate next,
        CancellationToken ct)
    {
        FlowConsole.Output = executionContext.Log;
        try
        {
            return await next();
        }
        finally
        {
            FlowConsole.Output = null;
        }
    }
}
