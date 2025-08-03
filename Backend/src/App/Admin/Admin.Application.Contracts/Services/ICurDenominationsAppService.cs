    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurDenominationsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurDenominations")]
        Task<ServiceResult<IDto>> CreateAsync(CurDenominationsCreationDto input);
        /// <summary>
        /// Modify the CurDenominations
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurDenominations")]
        Task<ServiceResult> UpdateAsync(long id, CurDenominationsUpdationDto input);

        /// <summary>
        /// delete CurDenominations
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurDenominations")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurDenominations
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurDenominationsDto>> GetPagedAsync(CurDenominationsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurDenominations")]
        Task<CurDenominationsDto> GetAsync(long id);
    }


