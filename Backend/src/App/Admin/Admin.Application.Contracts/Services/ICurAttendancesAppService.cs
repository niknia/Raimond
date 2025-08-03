    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurAttendancesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurAttendances")]
        Task<ServiceResult<IDto>> CreateAsync(CurAttendancesCreationDto input);
        /// <summary>
        /// Modify the CurAttendances
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurAttendances")]
        Task<ServiceResult> UpdateAsync(long id, CurAttendancesUpdationDto input);

        /// <summary>
        /// delete CurAttendances
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurAttendances")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurAttendances
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurAttendancesDto>> GetPagedAsync(CurAttendancesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurAttendances")]
        Task<CurAttendancesDto> GetAsync(long id);
    }


