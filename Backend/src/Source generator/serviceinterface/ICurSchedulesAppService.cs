    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurSchedulesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurSchedules")]
        Task<ServiceResult<IDto>> CreateAsync(CurSchedulesCreationDto input);
        /// <summary>
        /// Modify the CurSchedules
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurSchedules")]
        Task<ServiceResult> UpdateAsync(long id, CurSchedulesUpdationDto input);

        /// <summary>
        /// delete CurSchedules
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurSchedules")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurSchedules
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurSchedulesDto>> GetPagedAsync(CurSchedulesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurSchedules")]
        Task<CurSchedulesDto> GetAsync(long id);
    }


