    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurQuestionsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurQuestions")]
        Task<ServiceResult<IDto>> CreateAsync(CurQuestionsCreationDto input);
        /// <summary>
        /// Modify the CurQuestions
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurQuestions")]
        Task<ServiceResult> UpdateAsync(long id, CurQuestionsUpdationDto input);

        /// <summary>
        /// delete CurQuestions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurQuestions")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurQuestions
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurQuestionsDto>> GetPagedAsync(CurQuestionsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurQuestions")]
        Task<CurQuestionsDto> GetAsync(long id);
    }


