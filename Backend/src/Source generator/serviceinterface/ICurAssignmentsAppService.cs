    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurAssignmentsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurAssignments")]
        Task<ServiceResult<IDto>> CreateAsync(CurAssignmentsCreationDto input);
        /// <summary>
        /// Modify the CurAssignments
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurAssignments")]
        Task<ServiceResult> UpdateAsync(long id, CurAssignmentsUpdationDto input);

        /// <summary>
        /// delete CurAssignments
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurAssignments")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurAssignments
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurAssignmentsDto>> GetPagedAsync(CurAssignmentsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurAssignments")]
        Task<CurAssignmentsDto> GetAsync(long id);
    }


