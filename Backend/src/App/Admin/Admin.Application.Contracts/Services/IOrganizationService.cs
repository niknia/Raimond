namespace Dkd.App.Admin.Application.Contracts.Services;

/// <summary>
/// Organization Service
/// </summary>
public interface IOrganizationService : IAppService
{
    /// <summary>
    /// Add new organization
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Add new organization")]
    [CachingEvict(CacheKeys = new string[] { CachingConsts.DetpListCacheKey })]
    Task<ServiceResult<IdDto>> CreateAsync(OrganizationCreationDto input);

    /// <summary>
    /// Update organization
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Update organization")]
    [CachingEvict(CacheKeys = new string[] { CachingConsts.DetpListCacheKey })]
    [UnitOfWork]
    Task<ServiceResult> UpdateAsync(long id, OrganizationUpdationDto input);

    /// <summary>
    /// Delete organization
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Delete organization")]
    [CachingEvict(CacheKeys = new string[] { CachingConsts.DetpListCacheKey })]
    Task<ServiceResult> DeleteAsync(long[] ids);

    /// <summary>
    /// Get organization information
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    Task<OrganizationDto?> GetAsync(long Id);

    /// <summary>
    /// Organization tree structure
    /// </summary>
    /// <returns></returns>
    //[CachingAble(CacheKey = CachingConsts.DetpTreeListCacheKey, Expiration = CachingConsts.OneYear)]
    Task<List<OrganizationTreeDto>> GetTreeListAsync(string? name = null, bool? status = null);

    Task<List<OptionTreeDto>> GetOrgOptionsAsync(bool? status = null);
}
