using Microsoft.Extensions.DependencyInjection;

namespace Dkd.Infra.Flows;

public sealed class FlowsBuilder(IServiceCollection services)
{
    public IServiceCollection Services { get; } = services;
}
