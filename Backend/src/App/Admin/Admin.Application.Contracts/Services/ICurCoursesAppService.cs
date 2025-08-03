    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurCoursesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurCourses")]
        Task<ServiceResult<IDto>> CreateAsync(CurCoursesCreationDto input);
        /// <summary>
        /// Modify the CurCourses
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurCourses")]
        Task<ServiceResult> UpdateAsync(long id, CurCoursesUpdationDto input);

        /// <summary>
        /// delete CurCourses
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurCourses")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurCourses
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurCoursesDto>> GetPagedAsync(CurCoursesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurCourses")]
        Task<CurCoursesDto> GetAsync(long id);
    }


