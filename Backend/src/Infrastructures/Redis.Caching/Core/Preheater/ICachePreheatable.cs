namespace Dkd.Infra.Redis.Caching.Core.Preheater;

public interface ICachePreheatable
{
    /// <summary>
    /// Preheating cache
    /// </summary>
    /// <returns></returns>
    Task PreheatAsync();
}
