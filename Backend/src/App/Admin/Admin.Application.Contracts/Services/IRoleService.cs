namespace Dkd.App.Admin.Application.Contracts.Services;

/// <summary>
/// Role Service
/// </summary>
public interface IRoleService : IAppService
{
    /// <summary>
    /// Add new role
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Add new role")]
    Task<ServiceResult<IdDto>> CreateAsync(RoleCreationDto input);

    /// <summary>
    /// Update role
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Update role")]
    Task<ServiceResult> UpdateAsync(long id, RoleUpdationDto input);

    /// <summary>
    /// Delete role
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Delete role")]
    [UnitOfWork]
    Task<ServiceResult> DeleteAsync(long[] ids);

    /// <summary>
    /// Get role information
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RoleDto?> GetAsync(long id);

    /// <summary>
    /// Get role list
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PageModelDto<RoleDto>> GetPagedAsync(SearchPagedDto input);

    /// <summary>
    /// Set role permissions
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Set role permissions")]
    [UnitOfWork]
    Task<ServiceResult> SetPermissonsAsync(RoleSetPermissonsDto input);

    /// <summary>
    /// Get roles owned by user
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<long[]> GetMenuIdsAsync(long id);

    /// <summary>
    /// Get roles
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    Task<List<OptionTreeDto>> GetOptionsAsync(bool? status = null);
}
