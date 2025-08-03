    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curcoursecontentsDto
    /// </summary>
    [Serializable()]
    public class CurCourseContentsDto : OutputFullAuditInfoDto
     {
                 public string? ContentDescription { get; set; }
        public int? CourseId { get; set; }
     }
