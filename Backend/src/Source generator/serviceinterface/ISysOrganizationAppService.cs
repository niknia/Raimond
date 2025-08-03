    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysOrganizationAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysOrganization")]
        Task<ServiceResult<IDto>> CreateAsync(SysOrganizationCreationDto input);
        /// <summary>
        /// Modify the SysOrganization
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysOrganization")]
        Task<ServiceResult> UpdateAsync(long id, SysOrganizationUpdationDto input);

        /// <summary>
        /// delete SysOrganization
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysOrganization")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysOrganization
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysOrganizationDto>> GetPagedAsync(SysOrganizationSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysOrganization")]
        Task<SysOrganizationDto> GetAsync(long id);
    }


