namespace Dkd.Infra.Redis;

public interface IDistributedLocker
{
    /// <summary>
    /// Acquire a distributed lock
    /// </summary>
    /// <param name="cacheKey">cacheKey.</param>
    /// <param name="timeoutSeconds">Lock timeout in seconds</param>
    /// <param name="autoDelay">Whether to auto-renew the lock</param>
    /// <returns>Success indicates lock acquisition status, LockValue is the lock version number</returns>
    Task<(bool Success, string LockValue)> LockAsync(string cacheKey, int timeoutSeconds = 5, bool autoDelay = false);

    /// <summary>
    /// Safely release the lock
    /// </summary>
    /// <param name="cacheKey">cacheKey.</param>
    /// <param name="cacheValue">Version number</param>
    /// <returns></returns>
    Task<bool> SafedUnLockAsync(string cacheKey, string cacheValue);

    /// <summary>
    /// Acquire a distributed lock
    /// </summary>
    /// <param name="cacheKey">cacheKey.</param>
    /// <param name="timeoutSeconds">Lock timeout in seconds</param>
    /// <param name="autoDelay">Whether to auto-renew the lock</param>
    /// <returns>Success indicates lock acquisition status, LockValue is the lock version number</returns>
    (bool Success, string LockValue) Lock(string cacheKey, int timeoutSeconds = 5, bool autoDelay = false);

    /// <summary>
    /// Safely release the lock
    /// </summary>
    /// <param name="cacheKey">cacheKey.</param>
    /// <param name="cacheValue">Version number</param>
    /// <returns></returns>
    bool SafedUnLock(string cacheKey, string cacheValue);
}
