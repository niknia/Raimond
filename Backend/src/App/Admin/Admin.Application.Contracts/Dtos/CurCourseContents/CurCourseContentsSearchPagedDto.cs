    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curcoursecontentsDto
    /// </summary>
    [Serializable()]
    public class CurCourseContentsSearchPagedDto : SearchPagedDto
     {
                 public string? ContentDescription { get; set; }
        public int? CourseId { get; set; }
     }
