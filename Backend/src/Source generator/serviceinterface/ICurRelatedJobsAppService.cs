    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurRelatedJobsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurRelatedJobs")]
        Task<ServiceResult<IDto>> CreateAsync(CurRelatedJobsCreationDto input);
        /// <summary>
        /// Modify the CurRelatedJobs
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurRelatedJobs")]
        Task<ServiceResult> UpdateAsync(long id, CurRelatedJobsUpdationDto input);

        /// <summary>
        /// delete CurRelatedJobs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurRelatedJobs")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurRelatedJobs
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurRelatedJobsDto>> GetPagedAsync(CurRelatedJobsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurRelatedJobs")]
        Task<CurRelatedJobsDto> GetAsync(long id);
    }


