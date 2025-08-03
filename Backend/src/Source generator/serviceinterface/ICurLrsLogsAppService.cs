    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurLrsLogsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurLrsLogs")]
        Task<ServiceResult<IDto>> CreateAsync(CurLrsLogsCreationDto input);
        /// <summary>
        /// Modify the CurLrsLogs
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurLrsLogs")]
        Task<ServiceResult> UpdateAsync(long id, CurLrsLogsUpdationDto input);

        /// <summary>
        /// delete CurLrsLogs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurLrsLogs")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurLrsLogs
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurLrsLogsDto>> GetPagedAsync(CurLrsLogsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurLrsLogs")]
        Task<CurLrsLogsDto> GetAsync(long id);
    }


