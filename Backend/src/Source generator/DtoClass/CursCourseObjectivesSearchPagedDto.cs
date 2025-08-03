    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curscourseobjectivesDto
    /// </summary>
    [Serializable()]
    public class CursCourseObjectivesSearchPagedDto : SearchPagedDto
     {
                 public int? CourseId { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string? ObjectiveDescription { get; set; }
     }
    