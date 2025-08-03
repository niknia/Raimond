using Dkd.Infra.Flows.Internal.Execution.Utils;
using Microsoft.Extensions.Hosting;

namespace Dkd.Infra.Flows.Internal.Execution;

public sealed class FlowExecutionWorker<TContext> : BackgroundService, IBackgroundProcess where TContext : FlowContext
{
    private readonly ConcurrentDictionary<Guid, bool> executing = new();
    private readonly IFlowExecutor<TContext> executor;
    private readonly ILogger<FlowExecutionWorker<TContext>> log;
    private readonly FlowOptions options;
    private readonly int[] partitions;
    private readonly PartitionedScheduler<FlowExecutionState<TContext>> scheduler;
    private readonly IFlowStateStore<TContext> store;

    public FlowExecutionWorker(
        IFlowExecutor<TContext> executor,
        IFlowStateStore<TContext> store,
        IOptions<FlowOptions> options,
        ILogger<FlowExecutionWorker<TContext>> log)
    {
        this.executor = executor;
        this.options = options.Value;
        partitions = options.Value.GetPartitions();
        this.store = store;
        this.log = log;

        scheduler = new PartitionedScheduler<FlowExecutionState<TContext>>(
            HandleAsync,
            options.Value.NumWorker,
            options.Value.BufferSizePerWorker);
    }

    public IClock Clock { get; set; } = SystemClock.Instance;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var timer = new PeriodicTimer(options.JobQueryInterval);
        try
        {
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                await QueryAsync(stoppingToken);
            }
        }
        catch (OperationCanceledException)
        {
        }
    }

    public async Task QueryAsync(
        CancellationToken ct)
    {
        try
        {
            var now = Clock.GetCurrentInstant();
            await foreach (var next in store.QueryPendingAsync(partitions, now, ct))
            {
                await scheduler.ScheduleAsync(next.ScheduleKey, next, ct);
            }
        }
        catch (Exception ex)
        {
            log.LogError(ex, "Failed to query rule events.");
        }
    }

    public async Task HandleAsync(FlowExecutionState<TContext> state,
        CancellationToken ct)
    {
        if (!executing.TryAdd(state.InstanceId, false))
        {
            return;
        }

        try
        {
            await executor.ExecuteAsync(state, ct);
        }
        catch (Exception ex)
        {
            log.LogError(ex, "Failed to execute flow.");
        }
        finally
        {
            try
            {
                await store.StoreAsync([state]);
            }
            finally
            {
                executing.Remove(state.InstanceId, out _);
            }
        }
    }
}
