    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurAnswersAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurAnswers")]
        Task<ServiceResult<IDto>> CreateAsync(CurAnswersCreationDto input);
        /// <summary>
        /// Modify the CurAnswers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurAnswers")]
        Task<ServiceResult> UpdateAsync(long id, CurAnswersUpdationDto input);

        /// <summary>
        /// delete CurAnswers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurAnswers")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurAnswers
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurAnswersDto>> GetPagedAsync(CurAnswersSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurAnswers")]
        Task<CurAnswersDto> GetAsync(long id);
    }


