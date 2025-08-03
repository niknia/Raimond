    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysConfigAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysConfig")]
        Task<ServiceResult<IDto>> CreateAsync(SysConfigCreationDto input);
        /// <summary>
        /// Modify the SysConfig
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysConfig")]
        Task<ServiceResult> UpdateAsync(long id, SysConfigUpdationDto input);

        /// <summary>
        /// delete SysConfig
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysConfig")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysConfig
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysConfigDto>> GetPagedAsync(SysConfigSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysConfig")]
        Task<SysConfigDto> GetAsync(long id);
    }


