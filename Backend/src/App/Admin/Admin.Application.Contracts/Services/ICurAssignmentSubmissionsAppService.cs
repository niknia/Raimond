    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurAssignmentSubmissionsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurAssignmentSubmissions")]
        Task<ServiceResult<IDto>> CreateAsync(CurAssignmentSubmissionsCreationDto input);
        /// <summary>
        /// Modify the CurAssignmentSubmissions
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurAssignmentSubmissions")]
        Task<ServiceResult> UpdateAsync(long id, CurAssignmentSubmissionsUpdationDto input);

        /// <summary>
        /// delete CurAssignmentSubmissions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurAssignmentSubmissions")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurAssignmentSubmissions
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurAssignmentSubmissionsDto>> GetPagedAsync(CurAssignmentSubmissionsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurAssignmentSubmissions")]
        Task<CurAssignmentSubmissionsDto> GetAsync(long id);
    }


