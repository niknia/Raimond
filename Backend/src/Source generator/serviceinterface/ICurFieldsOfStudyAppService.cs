    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurFieldsOfStudyAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurFieldsOfStudy")]
        Task<ServiceResult<IDto>> CreateAsync(CurFieldsOfStudyCreationDto input);
        /// <summary>
        /// Modify the CurFieldsOfStudy
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurFieldsOfStudy")]
        Task<ServiceResult> UpdateAsync(long id, CurFieldsOfStudyUpdationDto input);

        /// <summary>
        /// delete CurFieldsOfStudy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurFieldsOfStudy")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurFieldsOfStudy
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurFieldsOfStudyDto>> GetPagedAsync(CurFieldsOfStudySearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurFieldsOfStudy")]
        Task<CurFieldsOfStudyDto> GetAsync(long id);
    }


