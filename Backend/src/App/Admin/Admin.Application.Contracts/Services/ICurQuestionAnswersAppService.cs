    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurQuestionAnswersAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurQuestionAnswers")]
        Task<ServiceResult<IDto>> CreateAsync(CurQuestionAnswersCreationDto input);
        /// <summary>
        /// Modify the CurQuestionAnswers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurQuestionAnswers")]
        Task<ServiceResult> UpdateAsync(long id, CurQuestionAnswersUpdationDto input);

        /// <summary>
        /// delete CurQuestionAnswers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurQuestionAnswers")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurQuestionAnswers
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurQuestionAnswersDto>> GetPagedAsync(CurQuestionAnswersSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurQuestionAnswers")]
        Task<CurQuestionAnswersDto> GetAsync(long id);
    }


