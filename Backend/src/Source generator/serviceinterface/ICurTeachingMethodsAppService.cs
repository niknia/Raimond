    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurTeachingMethodsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurTeachingMethods")]
        Task<ServiceResult<IDto>> CreateAsync(CurTeachingMethodsCreationDto input);
        /// <summary>
        /// Modify the CurTeachingMethods
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurTeachingMethods")]
        Task<ServiceResult> UpdateAsync(long id, CurTeachingMethodsUpdationDto input);

        /// <summary>
        /// delete CurTeachingMethods
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurTeachingMethods")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurTeachingMethods
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurTeachingMethodsDto>> GetPagedAsync(CurTeachingMethodsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurTeachingMethods")]
        Task<CurTeachingMethodsDto> GetAsync(long id);
    }


