    /// <summary>
    /// Certification Services
    /// </summary>

namespace Dkd.App.Admin.Application.Contracts.Services;

    public interface ISysRoleUserRelationAppService : IAppService
    {
        /// <summary>
        /// New menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "New SysRoleUserRelation")]
        Task<ServiceResult<IDto>> CreateAsync(SysRoleUserRelationCreationDto input);
        /// <summary>
        /// Modify the SysRoleUserRelation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Modify SysRoleUserRelation")]
        Task<ServiceResult> UpdateAsync(long id, SysRoleUserRelationUpdationDto input);

        /// <summary>
        /// delete SysRoleUserRelation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Delete SysRoleUserRelation")]
        Task<ServiceResult> DeleteAsync(long id);

        /// <summary>
        /// Array SysRoleUserRelation
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Task<PageModelDto<SysRoleUserRelationDto>> GetPagedAsync(SysRoleUserRelationSearchPagedDto input);

        /// <summary>
        /// Get a single word
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperateLog(LogName = "Get oneItem SysRoleUserRelation")]
        Task<SysRoleUserRelationDto> GetAsync(long id);
    }


