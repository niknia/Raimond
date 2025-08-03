namespace Dkd.App.Admin.Application.Contracts.Services;

/// <summary>
/// Dictionary Data Management
/// </summary>
public interface IDictDataService : IAppService
{
    /// <summary>
    /// Add new dictionary data
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Add new dictionary data")]
    [CachingEvict(CacheKey = CachingConsts.DictOptionsListKey)]
    Task<ServiceResult<IdDto>> CreateAsync(DictDataCreationDto input);

    /// <summary>
    /// Update dictionary data
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Update dictionary data")]
    [CachingEvict(CacheKey = CachingConsts.DictOptionsListKey)]
    Task<ServiceResult> UpdateAsync(long id, DictDataUpdationDto input);

    /// <summary>
    /// Delete dictionary data
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Delete dictionary data")]
    [CachingEvict(CacheKey = CachingConsts.DictOptionsListKey)]
    Task<ServiceResult> DeleteAsync(long[] ids);

    /// <summary>
    /// Get single dictionary data
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<DictDataDto?> GetAsync(long id);

    /// <summary>
    /// Get dictionary data list
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PageModelDto<DictDataDto>> GetPagedAsync(DictDataSearchPagedDto input);
}
