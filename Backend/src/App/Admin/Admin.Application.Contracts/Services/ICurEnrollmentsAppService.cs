    /// <summary>
    /// Certification Services
    /// </summary>

    using Dkd.App.Admin.Application.Contracts.Dtos;

    namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurEnrollmentsAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurEnrollments")]
        Task<ServiceResult<IDto>> CreateAsync(CurEnrollmentsCreationDto input);
        /// <summary>
        /// Modify the CurEnrollments
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurEnrollments")]
        Task<ServiceResult> UpdateAsync(long id, CurEnrollmentsUpdationDto input);

        /// <summary>
        /// delete CurEnrollments
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurEnrollments")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurEnrollments
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurEnrollmentsDto>> GetPagedAsync(CurEnrollmentsSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurEnrollments")]
        Task<CurEnrollmentsDto> GetAsync(long id);
    }


