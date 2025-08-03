    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysorganizationDto
    /// </summary>
    [Serializable()]
    public class SysOrganizationSearchPagedDto : SearchPagedDto
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
        /// Parent ID
        /// </summary>
        public long Parentid { get; set; }
        /// <summary>
        /// Parent IDs
        /// </summary>
        public string Parentids { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        public bool Status { get; set; }
     }
    