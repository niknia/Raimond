    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurQuizSubmissionsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurQuizSubmissions")]
        Task<ServiceResult<IDto>> CreateAsync(CurQuizSubmissionsCreationDto input);
        /// <summary>
        /// Modify the CurQuizSubmissions
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurQuizSubmissions")]
        Task<ServiceResult> UpdateAsync(long id, CurQuizSubmissionsUpdationDto input);

        /// <summary>
        /// delete CurQuizSubmissions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurQuizSubmissions")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurQuizSubmissions
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurQuizSubmissionsDto>> GetPagedAsync(CurQuizSubmissionsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurQuizSubmissions")]
        Task<CurQuizSubmissionsDto> GetAsync(long id);
    }


