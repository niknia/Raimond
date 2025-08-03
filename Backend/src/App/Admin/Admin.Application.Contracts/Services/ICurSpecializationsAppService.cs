    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurSpecializationsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurSpecializations")]
        Task<ServiceResult<IDto>> CreateAsync(CurSpecializationsCreationDto input);
        /// <summary>
        /// Modify the CurSpecializations
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurSpecializations")]
        Task<ServiceResult> UpdateAsync(long id, CurSpecializationsUpdationDto input);

        /// <summary>
        /// delete CurSpecializations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurSpecializations")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurSpecializations
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurSpecializationsDto>> GetPagedAsync(CurSpecializationsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurSpecializations")]
        Task<CurSpecializationsDto> GetAsync(long id);
    }


