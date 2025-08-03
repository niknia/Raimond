namespace Dkd.App.Admin.Application.Contracts.Services;

/// <summary>
/// Dictionary Management
/// </summary>
public interface IDictService : IAppService
{
    /// <summary>
    /// Add new dictionary
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Add new dictionary")]
    Task<ServiceResult<IdDto>> CreateAsync(DictCreationDto input);

    /// <summary>
    /// Update dictionary
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Update dictionary")]
    [CachingEvict(CacheKey = CachingConsts.DictOptionsListKey)]
    [UnitOfWork]
    Task<ServiceResult> UpdateAsync(long id, DictUpdationDto input);

    /// <summary>
    /// Delete dictionary
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Delete dictionary")]
    [CachingEvict(CacheKey = CachingConsts.DictOptionsListKey)]
    Task<ServiceResult> DeleteAsync(long[] ids);

    /// <summary>
    /// Get single dictionary
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<DictDto?> GetAsync(long id);

    /// <summary>
    /// Get dictionary list
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PageModelDto<DictDto>> GetPagedAsync(SearchPagedDto input);

    /// <summary>
    /// Get dictionary options
    /// </summary>
    /// <returns></returns>
    Task<List<DictOptionDto>> GetOptionsAsync(string codes);
}
