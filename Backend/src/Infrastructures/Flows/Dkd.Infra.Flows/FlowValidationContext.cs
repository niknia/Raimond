namespace Dkd.Infra.Flows;

public sealed class FlowValidationContext(IServiceProvider serviceProvider, FlowDefinition? definition)
{
    public IServiceProvider ServiceProvider => serviceProvider;

    public FlowDefinition? Definition => definition;
}
