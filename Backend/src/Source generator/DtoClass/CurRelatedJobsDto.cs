    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// currelatedjobsDto
    /// </summary>
    [Serializable()]
    public class CurRelatedJobsDto : OutputFullAuditInfoDto
     {
                 public int? CourseId { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long JobId { get; set; }
        public string? JobTitle { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
     }
    