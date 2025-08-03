    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurTeacherTypesAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurTeacherTypes")]
        Task<ServiceResult<IDto>> CreateAsync(CurTeacherTypesCreationDto input);
        /// <summary>
        /// Modify the CurTeacherTypes
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurTeacherTypes")]
        Task<ServiceResult> UpdateAsync(long id, CurTeacherTypesUpdationDto input);

        /// <summary>
        /// delete CurTeacherTypes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurTeacherTypes")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurTeacherTypes
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurTeacherTypesDto>> GetPagedAsync(CurTeacherTypesSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurTeacherTypes")]
        Task<CurTeacherTypesDto> GetAsync(long id);
    }


