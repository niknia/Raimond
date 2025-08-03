    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysrolemenurelationDto
    /// </summary>
    [Serializable()]
    public class SysRoleMenuRelationCreationDto : InputDto
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
    