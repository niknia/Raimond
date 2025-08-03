    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curcoursecontentsDto
    /// </summary>
    [Serializable()]
    public class CurCourseContentsSearchPagedDto : SearchPagedDto
     {
                 public string? ContentDescription { get; set; }
        public int? CourseId { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
     }
    