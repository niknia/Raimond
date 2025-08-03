    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curcoursestandardsDto
    /// </summary>
    [Serializable()]
    public class CurCourseStandardsSearchPagedDto : SearchPagedDto
     {
                 public int? CourseId { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string? StandardDescription { get; set; }
     }
    