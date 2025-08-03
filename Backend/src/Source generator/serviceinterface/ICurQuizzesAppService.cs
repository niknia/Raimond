    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurQuizzesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurQuizzes")]
        Task<ServiceResult<IDto>> CreateAsync(CurQuizzesCreationDto input);
        /// <summary>
        /// Modify the CurQuizzes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurQuizzes")]
        Task<ServiceResult> UpdateAsync(long id, CurQuizzesUpdationDto input);

        /// <summary>
        /// delete CurQuizzes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurQuizzes")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurQuizzes
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurQuizzesDto>> GetPagedAsync(CurQuizzesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurQuizzes")]
        Task<CurQuizzesDto> GetAsync(long id);
    }


