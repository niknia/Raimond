namespace Dkd.App.Admin.Application.Contracts.Services;

/// <summary>
/// Menu/Permission Service
/// </summary>
public interface IMenuService : IAppService
{
    /// <summary>
    /// Add new menu
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Add new menu")]
    [CachingEvict(CacheKeys = new[] { CachingConsts.MenuListCacheKey })]
    Task<ServiceResult<IdDto>> CreateAsync(MenuCreationDto input);

    /// <summary>
    /// Update menu
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Update menu")]
    [CachingEvict(CacheKeys = new[] { CachingConsts.MenuListCacheKey, CachingConsts.RoleMenuCodesCacheKey })]
    Task<ServiceResult> UpdateAsync(long id, MenuUpdationDto input);

    /// <summary>
    /// Delete menu
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Delete menu")]
    [CachingEvict(CacheKeys = new[] { CachingConsts.MenuListCacheKey, CachingConsts.RoleMenuCodesCacheKey })]
    Task<ServiceResult> DeleteAsync(long id);

    /// <summary>
    /// Get menu list
    /// </summary>
    /// <returns></returns>
    //[CachingAble(CacheKey = CachingConsts.MenuTreeListCacheKey, Expiration = CachingConsts.OneYear)]
    Task<List<MenuTreeDto>> GetTreelistAsync(string? keywords = null);

    /// <summary>
    /// Get menu information
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<MenuDto?> GetAsync(long id);

    /// <summary>
    /// Get left-side router menu
    /// </summary>
    /// <param name="roleIds"></param>
    /// <returns></returns>
    Task<List<RouterTreeDto>> GetMenusForRouterAsync(IEnumerable<long> roleIds);

    /// <summary>
    /// Get menu options
    /// </summary>
    /// <param name="onlyParent"></param>
    /// <returns></returns>
    Task<List<OptionTreeDto>> GetMenuOptionsAsync(bool? onlyParent);
}
