namespace Dkd.App.Admin.Application.Contracts.Dtos;
/// <summary>
/// curcoursestandardsDto
/// </summary>
[Serializable()]
    public class CurCourseStandardsDto : OutputFullAuditInfoDto
     {
                 public int? CourseId { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string? StandardDescription { get; set; }
     }
