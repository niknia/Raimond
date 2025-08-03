    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysdictionaryDto
    /// </summary>
    [Serializable()]
    public class SysDictionaryCreationDto : InputDto
     {
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
        public string Name { get; set; }
        public string Remark { get; set; }
        public bool Status { get; set; }
     }
    