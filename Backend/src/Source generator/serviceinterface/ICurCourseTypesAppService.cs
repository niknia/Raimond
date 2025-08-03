    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurCourseTypesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurCourseTypes")]
        Task<ServiceResult<IDto>> CreateAsync(CurCourseTypesCreationDto input);
        /// <summary>
        /// Modify the CurCourseTypes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurCourseTypes")]
        Task<ServiceResult> UpdateAsync(long id, CurCourseTypesUpdationDto input);

        /// <summary>
        /// delete CurCourseTypes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurCourseTypes")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurCourseTypes
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurCourseTypesDto>> GetPagedAsync(CurCourseTypesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurCourseTypes")]
        Task<CurCourseTypesDto> GetAsync(long id);
    }


