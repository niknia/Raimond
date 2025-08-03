    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurDegreesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurDegrees")]
        Task<ServiceResult<IDto>> CreateAsync(CurDegreesCreationDto input);
        /// <summary>
        /// Modify the CurDegrees
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurDegrees")]
        Task<ServiceResult> UpdateAsync(long id, CurDegreesUpdationDto input);

        /// <summary>
        /// delete CurDegrees
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurDegrees")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurDegrees
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurDegreesDto>> GetPagedAsync(CurDegreesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurDegrees")]
        Task<CurDegreesDto> GetAsync(long id);
    }


