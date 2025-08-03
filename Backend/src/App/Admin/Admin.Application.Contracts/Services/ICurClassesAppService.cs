    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurClassesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurClasses")]
        Task<ServiceResult<IDto>> CreateAsync(CurClassesCreationDto input);
        /// <summary>
        /// Modify the CurClasses
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurClasses")]
        Task<ServiceResult> UpdateAsync(long id, CurClassesUpdationDto input);

        /// <summary>
        /// delete CurClasses
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurClasses")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurClasses
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurClassesDto>> GetPagedAsync(CurClassesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurClasses")]
        Task<CurClassesDto> GetAsync(long id);
    }


