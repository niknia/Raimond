    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurCourseContentsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurCourseContents")]
        Task<ServiceResult<IDto>> CreateAsync(CurCourseContentsCreationDto input);
        /// <summary>
        /// Modify the CurCourseContents
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurCourseContents")]
        Task<ServiceResult> UpdateAsync(long id, CurCourseContentsUpdationDto input);

        /// <summary>
        /// delete CurCourseContents
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurCourseContents")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurCourseContents
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurCourseContentsDto>> GetPagedAsync(CurCourseContentsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurCourseContents")]
        Task<CurCourseContentsDto> GetAsync(long id);
    }


