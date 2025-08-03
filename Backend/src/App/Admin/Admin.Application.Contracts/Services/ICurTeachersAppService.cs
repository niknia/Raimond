    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ICurTeachersAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New CurTeachers")]
        Task<ServiceResult<IDto>> CreateAsync(CurTeachersCreationDto input);
        /// <summary>
        /// Modify the CurTeachers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify CurTeachers")]
        Task<ServiceResult> UpdateAsync(long id, CurTeachersUpdationDto input);

        /// <summary>
        /// delete CurTeachers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete CurTeachers")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array CurTeachers
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<CurTeachersDto>> GetPagedAsync(CurTeachersSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem CurTeachers")]
        Task<CurTeachersDto> GetAsync(long id);
    }


