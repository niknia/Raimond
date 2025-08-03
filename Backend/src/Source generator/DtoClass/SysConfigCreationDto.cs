    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysconfigDto
    /// </summary>
    [Serializable()]
    public class SysConfigCreationDto : InputDto
     {
             /// <summary>
        /// Creator
        /// </summary>
        public long Createby { get; set; }
        /// <summary>
        /// Creation Time/Registration Time
        /// </summary>
        public DateTime Createtime { get; set; }
        /// <summary>
        /// Parameter Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Last Updated By
        /// </summary>
        public long? Modifyby { get; set; }
        /// <summary>
        /// Last Update Time
        /// </summary>
        public DateTime? Modifytime { get; set; }
        /// <summary>
        /// Parameter Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Remarks
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// Parameter Value
        /// </summary>
        public string Value { get; set; }
     }
    