    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysRoleMenuRelationAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysRoleMenuRelation")]
        Task<ServiceResult<IDto>> CreateAsync(SysRoleMenuRelationCreationDto input);
        /// <summary>
        /// Modify the SysRoleMenuRelation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysRoleMenuRelation")]
        Task<ServiceResult> UpdateAsync(long id, SysRoleMenuRelationUpdationDto input);

        /// <summary>
        /// delete SysRoleMenuRelation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysRoleMenuRelation")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysRoleMenuRelation
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysRoleMenuRelationDto>> GetPagedAsync(SysRoleMenuRelationSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysRoleMenuRelation")]
        Task<SysRoleMenuRelationDto> GetAsync(long id);
    }


