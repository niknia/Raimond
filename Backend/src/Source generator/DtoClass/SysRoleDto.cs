    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysroleDto
    /// </summary>
    [Serializable()]
    public class SysRoleDto : OutputFullAuditInfoDto
     {
             /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Creator
        /// </summary>
        public long Createby { get; set; }
        /// <summary>
        /// Creation Time/Registration Time
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// Data Scope
        /// </summary>
        public int Datascope { get; set; }
        public string? FkMenu { get; set; }
        /// <summary>
        /// Last Updated By
        /// </summary>
        public long Modifyby { get; set; }
        /// <summary>
        /// Last Update Time
        /// </summary>
        public DateTime Modifytime { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Order Number
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public bool Status { get; set; }
     }
    