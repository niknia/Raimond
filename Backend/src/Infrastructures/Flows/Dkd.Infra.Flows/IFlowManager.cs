namespace Dkd.Infra.Flows;

public interface IFlowManager<TContext> where TContext : FlowContext
{
    Task EnqueueAsync(CreateFlowInstanceRequest<TContext>[] requests,
        CancellationToken ct);

    Task<FlowExecutionState<TContext>> SimulateAsync(CreateFlowInstanceRequest<TContext> state,
        CancellationToken ct);

    Task ValidateAsync(FlowDefinition definition, AddError addError,
        CancellationToken ct);

    Task ValidateAsync(FlowStep step, AddError addError,
        CancellationToken ct);

    Task<bool> ForceAsync(Guid instanceId,
        CancellationToken ct = default);

    Task<bool> CancelByInstanceIdAsync(Guid instanceId,
        CancellationToken ct = default);

    Task CancelByDefinitionIdAsync(string definitionId,
        CancellationToken ct = default);

    Task CancelByOwnerIdAsync(string ownerId,
        CancellationToken ct = default);

    Task DeleteByOwnerIdAsync(string ownerId,
        CancellationToken ct = default);

    Task<FlowExecutionState<TContext>?> FindInstanceAsync(Guid id,
        CancellationToken ct = default);

    Task<(List<FlowExecutionState<TContext>> Items, long Total)> QueryInstancesByOwnerAsync(string ownerId,
        string? definitionId = null, int skip = 0, int take = 20,
        CancellationToken ct = default);
}
