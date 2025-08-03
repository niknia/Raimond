namespace Dkd.App.Admin.Application.Contracts.Services;

/// <summary>
/// User Management
/// </summary>
public interface IUserService : IAppService
{
    /// <summary>
    /// Add new user
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Add new user")]
    [UnitOfWork]
    Task<ServiceResult<IdDto>> CreateAsync(UserCreationDto input);

    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Update user")]
    [CachingEvict(CacheKeyPrefix = CachingConsts.UserValidatedInfoKeyPrefix)]
    [UnitOfWork]
    Task<ServiceResult> UpdateAsync([CachingParam] long id, UserUpdationDto input);

    /// <summary>
    /// Delete user
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Delete user")]
    [CachingEvict(CacheKeyPrefix = CachingConsts.UserValidatedInfoKeyPrefix)]
    [UnitOfWork]
    Task<ServiceResult> DeleteAsync([CachingParam] long[] ids);

    /// <summary>
    /// Check if user has specified permissions
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="requestPermissions"></param>
    /// <param name="userBelongsRoleIds"></param>
    /// <returns></returns>
    //[OperateLog(LogName = "Check if current user has specified permissions")]
    Task<List<string>> GetPermissionsAsync(long userId, IEnumerable<string> requestPermissions, string userBelongsRoleIds);

    /// <summary>
    /// Get user information
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserDto?> GetAsync(long id);

    /// <summary>
    /// Get user list
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PageModelDto<UserDto>> GetPagedAsync(UserSearchPagedDto input);

    /// <summary>
    /// Get current user information
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserProfileDto?> GetProfileAsync(long id);

    /// <summary>
    /// Update current user information
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Update current user information")]
    Task<ServiceResult> ChangeProfileAsync(long id, UserProfileUpdationDto input);

    /// <summary>
    /// Login
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    //[OperateLog(LogName = "Login")]
    Task<ServiceResult<UserValidatedInfoDto>> LoginAsync(UserLoginDto input);

    /// <summary>
    /// Change password
    /// </summary>
    /// <param name="id"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Change password")]
    [CachingEvict(CacheKeyPrefix = CachingConsts.UserValidatedInfoKeyPrefix)]
    Task<ServiceResult> UpdatePasswordAsync([CachingParam] long id, UserProfileChangePwdDto input);

    /// <summary>
    /// Reset password
    /// </summary>
    /// <param name="id"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Reset password")]
    [CachingEvict(CacheKeyPrefix = CachingConsts.UserValidatedInfoKeyPrefix)]
    Task<ServiceResult> ResetPasswordAsync([CachingParam] long id, string password);

    /// <summary>
    /// Get authentication information
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    //[OperateLog(LogName = "Get authentication information")]
    [CachingAble(CacheKeyPrefix = CachingConsts.UserValidatedInfoKeyPrefix)]
    Task<UserValidatedInfoDto?> GetUserValidatedInfoAsync([CachingParam] long id) => Task.FromResult<UserValidatedInfoDto?>(null);

    /// <summary>
    /// Remove authentication information
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Remove authentication information")]
    [CachingEvict(CacheKeyPrefix = CachingConsts.UserValidatedInfoKeyPrefix)]
    Task<ServiceResult> DeleteUserValidateInfoAsync([CachingParam] long id) => Task.FromResult(new ServiceResult());

    /// <summary>
    /// Adjust authentication information expiration time
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [OperateLog(LogName = "Adjust authentication information expiration time")]
    Task<ServiceResult> ChangeUserValidateInfoExpiresDtAsync(long id);

    /// <summary>
    /// Get user and permission information
    /// </summary>
    /// <returns></returns>
    Task<UserInfoDto?> GetUserInfoAsync(UserContext userContext);

}
