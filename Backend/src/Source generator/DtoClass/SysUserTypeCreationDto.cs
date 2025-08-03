    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysusertypeDto
    /// </summary>
    [Serializable()]
    public class SysUserTypeCreationDto : InputDto
     {
             /// <summary>
        /// Creator
        /// </summary>
        public long Createby { get; set; }
        /// <summary>
        /// Creation Time/Registration Time
        /// </summary>
        public DateTime Createtime { get; set; }
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Last Updated By
        /// </summary>
        public long? Modifyby { get; set; }
        /// <summary>
        /// Last Update Time
        /// </summary>
        public DateTime? Modifytime { get; set; }
        public string? Name { get; set; }
     }
    