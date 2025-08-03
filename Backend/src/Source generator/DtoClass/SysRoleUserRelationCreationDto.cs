    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysroleuserrelationDto
    /// </summary>
    [Serializable()]
    public class SysRoleUserRelationCreationDto : InputDto
     {
             /// <summary>
        /// Role ID
        /// </summary>
        public long Roleid { get; set; }
        /// <summary>
        /// User ID
        /// </summary>
        public long Userid { get; set; }
     }
    