    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurMaritalStatusesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurMaritalStatuses")]
        Task<ServiceResult<IDto>> CreateAsync(CurMaritalStatusesCreationDto input);
        /// <summary>
        /// Modify the CurMaritalStatuses
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurMaritalStatuses")]
        Task<ServiceResult> UpdateAsync(long id, CurMaritalStatusesUpdationDto input);

        /// <summary>
        /// delete CurMaritalStatuses
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurMaritalStatuses")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurMaritalStatuses
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurMaritalStatusesDto>> GetPagedAsync(CurMaritalStatusesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurMaritalStatuses")]
        Task<CurMaritalStatusesDto> GetAsync(long id);
    }


