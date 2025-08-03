    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// syseventtrackerDto
    /// </summary>
    [Serializable()]
    public class SysEventtrackerSearchPagedDto : SearchPagedDto
     {
             /// <summary>
        /// Creator
        /// </summary>
        public long Createby { get; set; }
        /// <summary>
        /// Creation Time/Registration Time
        /// </summary>
        public DateTime Createtime { get; set; }
        public long Eventid { get; set; }
        public string Trackername { get; set; }
     }
    