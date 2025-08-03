    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysDictionaryAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysDictionary")]
        Task<ServiceResult<IDto>> CreateAsync(SysDictionaryCreationDto input);
        /// <summary>
        /// Modify the SysDictionary
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysDictionary")]
        Task<ServiceResult> UpdateAsync(long id, SysDictionaryUpdationDto input);

        /// <summary>
        /// delete SysDictionary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysDictionary")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysDictionary
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysDictionaryDto>> GetPagedAsync(SysDictionarySearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysDictionary")]
        Task<SysDictionaryDto> GetAsync(long id);
    }


