    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysEventtrackerAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysEventtracker")]
        Task<ServiceResult<IDto>> CreateAsync(SysEventtrackerCreationDto input);
        /// <summary>
        /// Modify the SysEventtracker
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysEventtracker")]
        Task<ServiceResult> UpdateAsync(long id, SysEventtrackerUpdationDto input);

        /// <summary>
        /// delete SysEventtracker
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysEventtracker")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysEventtracker
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysEventtrackerDto>> GetPagedAsync(SysEventtrackerSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysEventtracker")]
        Task<SysEventtrackerDto> GetAsync(long id);
    }


