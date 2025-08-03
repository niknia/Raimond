    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysMenuAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysMenu")]
        Task<ServiceResult<IDto>> CreateAsync(SysMenuCreationDto input);
        /// <summary>
        /// Modify the SysMenu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysMenu")]
        Task<ServiceResult> UpdateAsync(long id, SysMenuUpdationDto input);

        /// <summary>
        /// delete SysMenu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysMenu")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysMenu
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysMenuDto>> GetPagedAsync(SysMenuSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysMenu")]
        Task<SysMenuDto> GetAsync(long id);
    }


