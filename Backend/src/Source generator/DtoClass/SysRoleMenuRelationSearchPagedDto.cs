    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysrolemenurelationDto
    /// </summary>
    [Serializable()]
    public class SysRoleMenuRelationSearchPagedDto : SearchPagedDto
     {
             /// <summary>
        /// Menu ID
        /// </summary>
        public long Menuid { get; set; }
        /// <summary>
        /// Role ID
        /// </summary>
        public long Roleid { get; set; }
     }
    