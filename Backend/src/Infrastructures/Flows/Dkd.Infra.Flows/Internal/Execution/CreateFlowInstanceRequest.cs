namespace Dkd.Infra.Flows.Internal.Execution;

public readonly record struct CreateFlowInstanceRequest<TContext>
{
    public required string OwnerId { get; init; }

    public required string DefinitionId { get; init; }

    public string? Description { get; init; }

    public string? ScheduleKey { get; init; }

    public required FlowDefinition Definition { get; init; }

    public required TContext Context { get; init; }
}
