    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurOrganizationsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurOrganizations")]
        Task<ServiceResult<IDto>> CreateAsync(CurOrganizationsCreationDto input);
        /// <summary>
        /// Modify the CurOrganizations
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurOrganizations")]
        Task<ServiceResult> UpdateAsync(long id, CurOrganizationsUpdationDto input);

        /// <summary>
        /// delete CurOrganizations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurOrganizations")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurOrganizations
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurOrganizationsDto>> GetPagedAsync(CurOrganizationsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurOrganizations")]
        Task<CurOrganizationsDto> GetAsync(long id);
    }


