    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// sysdictionarydataDto
    /// </summary>
    [Serializable()]
    public class SysDictionaryDataCreationDto : InputDto
     {
             /// <summary>
        /// Creator
        /// </summary>
        public long Createby { get; set; }
        /// <summary>
        /// Creation Time/Registration Time
        /// </summary>
        public DateTime Createtime { get; set; }
        public string Dictcode { get; set; }
        public string Label { get; set; }
        /// <summary>
        /// Last Updated By
        /// </summary>
        public long Modifyby { get; set; }
        /// <summary>
        /// Last Update Time
        /// </summary>
        public DateTime Modifytime { get; set; }
        public int Ordinal { get; set; }
        public bool Status { get; set; }
        public string Tagtype { get; set; }
        public string Value { get; set; }
     }
    