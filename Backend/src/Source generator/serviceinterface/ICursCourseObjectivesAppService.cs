    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICursCourseObjectivesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CursCourseObjectives")]
        Task<ServiceResult<IDto>> CreateAsync(CursCourseObjectivesCreationDto input);
        /// <summary>
        /// Modify the CursCourseObjectives
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CursCourseObjectives")]
        Task<ServiceResult> UpdateAsync(long id, CursCourseObjectivesUpdationDto input);

        /// <summary>
        /// delete CursCourseObjectives
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CursCourseObjectives")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CursCourseObjectives
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CursCourseObjectivesDto>> GetPagedAsync(CursCourseObjectivesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CursCourseObjectives")]
        Task<CursCourseObjectivesDto> GetAsync(long id);
    }


