namespace Dkd.Infra.Flows;

public interface IFlowStepRegistry
{
    IReadOnlyDictionary<string, FlowStepDescriptor> Steps { get; }
}
