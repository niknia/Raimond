
namespace Dkd.Infra.Core;
public interface IBackgroundProcess : ISystem
{
    Task StartAsync(
        CancellationToken ct);

    Task StopAsync(
        CancellationToken ct)
    {
        return Task.CompletedTask;
    }
}
