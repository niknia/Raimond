    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurCourseStandardsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurCourseStandards")]
        Task<ServiceResult<IDto>> CreateAsync(CurCourseStandardsCreationDto input);
        /// <summary>
        /// Modify the CurCourseStandards
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurCourseStandards")]
        Task<ServiceResult> UpdateAsync(long id, CurCourseStandardsUpdationDto input);

        /// <summary>
        /// delete CurCourseStandards
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurCourseStandards")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurCourseStandards
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurCourseStandardsDto>> GetPagedAsync(CurCourseStandardsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurCourseStandards")]
        Task<CurCourseStandardsDto> GetAsync(long id);
    }


