    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysUserTypeAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysUserType")]
        Task<ServiceResult<IDto>> CreateAsync(SysUserTypeCreationDto input);
        /// <summary>
        /// Modify the SysUserType
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysUserType")]
        Task<ServiceResult> UpdateAsync(long id, SysUserTypeUpdationDto input);

        /// <summary>
        /// delete SysUserType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysUserType")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysUserType
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysUserTypeDto>> GetPagedAsync(SysUserTypeSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysUserType")]
        Task<SysUserTypeDto> GetAsync(long id);
    }


