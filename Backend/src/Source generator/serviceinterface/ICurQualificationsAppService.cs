    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurQualificationsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurQualifications")]
        Task<ServiceResult<IDto>> CreateAsync(CurQualificationsCreationDto input);
        /// <summary>
        /// Modify the CurQualifications
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurQualifications")]
        Task<ServiceResult> UpdateAsync(long id, CurQualificationsUpdationDto input);

        /// <summary>
        /// delete CurQualifications
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurQualifications")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurQualifications
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurQualificationsDto>> GetPagedAsync(CurQualificationsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurQualifications")]
        Task<CurQualificationsDto> GetAsync(long id);
    }


