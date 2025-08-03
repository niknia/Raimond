    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curcoursestandardsDto
    /// </summary>
    [Serializable()]
    public class CurCourseStandardsCreationDto : InputDto
     {
                 public int? CourseId { get; set; }
        public string? StandardDescription { get; set; }
     }
