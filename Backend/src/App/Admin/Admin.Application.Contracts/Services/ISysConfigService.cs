namespace Dkd.App.Admin.Application.Contracts.Services;

/// <summary>
/// Configuration Management
/// </summary>
public interface ISysConfigService : IAppService
{
    /// <summary>
    /// Add new configuration
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Add new configuration")]
    [CachingEvict(CacheKey = CachingConsts.SysConfigListCacheKey)]
    Task<ServiceResult<IdDto>> CreateAsync(SysConfigCreationDto input);

    /// <summary>
    /// Update configuration
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Update configuration")]
    [CachingEvict(CacheKey = CachingConsts.SysConfigListCacheKey)]
    Task<ServiceResult> UpdateAsync([CachingParam] long id, SysConfigUpdationDto input);

    /// <summary>
    /// Delete configuration
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Delete configuration")]
    [CachingEvict(CacheKey = CachingConsts.SysConfigListCacheKey)]
    Task<ServiceResult> DeleteAsync([CachingParam] long[] ids);

    /// <summary>
    /// Delete configuration
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Delete configuration by key")]
    [CachingEvict(CacheKey = CachingConsts.SysConfigListCacheKey)]
    Task<ServiceResult> DeleteByKeyAsync([CachingParam] string ids);

    /// <summary>
    /// Get configuration
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<SysConfigDto?> GetAsync(long id);

    /// <summary>
    /// Configuration list
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PageModelDto<SysConfigDto>> GetPagedAsync(SearchPagedDto input);

    /// <summary>
    /// Get configuration by key
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    Task<List<SysConfigSimpleDto>> GetListAsync(string keys);

    Task<List<SysConfigDto>> GetListbykeyAsync(string keys);
}
