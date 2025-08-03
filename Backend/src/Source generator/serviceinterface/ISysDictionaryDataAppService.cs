    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysDictionaryDataAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysDictionaryData")]
        Task<ServiceResult<IDto>> CreateAsync(SysDictionaryDataCreationDto input);
        /// <summary>
        /// Modify the SysDictionaryData
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysDictionaryData")]
        Task<ServiceResult> UpdateAsync(long id, SysDictionaryDataUpdationDto input);

        /// <summary>
        /// delete SysDictionaryData
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysDictionaryData")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysDictionaryData
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysDictionaryDataDto>> GetPagedAsync(SysDictionaryDataSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysDictionaryData")]
        Task<SysDictionaryDataDto> GetAsync(long id);
    }


