using DotNetCore.CAP;

namespace Dkd.Infra.EventBus.Cap;

/// <summary>
/// Empty Cap publisher for unit testing
/// </summary>
public class NullCapPublisher : ICapPublisher
{
    public AsyncLocal<ICapTransaction> Transaction { get; } = default!;
    public IServiceProvider ServiceProvider { get; } = default!;
    ICapTransaction? ICapPublisher.Transaction { get; set; }

    public void Publish<T>(string name, T? contentObj, string? callbackName = null)
    {
        // Method intentionally left empty.
    }

    public void Publish<T>(string name, T? contentObj, IDictionary<string, string?> headers)
    {
        // Method intentionally left empty.
    }

    public Task PublishAsync<T>(string name, T? contentObj, string? callbackName = null, CancellationToken cancellationToken = default)
        => Task.CompletedTask;

    public Task PublishAsync<T>(string name, T? contentObj, IDictionary<string, string?> headers, CancellationToken cancellationToken = default)
        => Task.CompletedTask;

    public void PublishDelay<T>(TimeSpan delayTime, string name, T? contentObj, IDictionary<string, string?> headers)
    {
    }

    public void PublishDelay<T>(TimeSpan delayTime, string name, T? contentObj, string? callbackName = null)
    {
    }

    public Task PublishDelayAsync<T>(TimeSpan delayTime, string name, T? contentObj, IDictionary<string, string?> headers, CancellationToken cancellationToken = default)
        => Task.CompletedTask;

    public Task PublishDelayAsync<T>(TimeSpan delayTime, string name, T? contentObj, string? callbackName = null, CancellationToken cancellationToken = default)
        => Task.CompletedTask;
}
