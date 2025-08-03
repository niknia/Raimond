    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurReligionsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurReligions")]
        Task<ServiceResult<IDto>> CreateAsync(CurReligionsCreationDto input);
        /// <summary>
        /// Modify the CurReligions
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurReligions")]
        Task<ServiceResult> UpdateAsync(long id, CurReligionsUpdationDto input);

        /// <summary>
        /// delete CurReligions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurReligions")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurReligions
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurReligionsDto>> GetPagedAsync(CurReligionsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurReligions")]
        Task<CurReligionsDto> GetAsync(long id);
    }


