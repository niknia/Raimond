    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysRoleAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysRole")]
        Task<ServiceResult<IDto>> CreateAsync(SysRoleCreationDto input);
        /// <summary>
        /// Modify the SysRole
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysRole")]
        Task<ServiceResult> UpdateAsync(long id, SysRoleUpdationDto input);

        /// <summary>
        /// delete SysRole
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysRole")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysRole
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysRoleDto>> GetPagedAsync(SysRoleSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysRole")]
        Task<SysRoleDto> GetAsync(long id);
    }


