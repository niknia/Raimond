    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurUsersAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurUsers")]
        Task<ServiceResult<IDto>> CreateAsync(CurUsersCreationDto input);
        /// <summary>
        /// Modify the CurUsers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurUsers")]
        Task<ServiceResult> UpdateAsync(long id, CurUsersUpdationDto input);

        /// <summary>
        /// delete CurUsers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurUsers")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurUsers
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurUsersDto>> GetPagedAsync(CurUsersSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurUsers")]
        Task<CurUsersDto> GetAsync(long id);
    }


