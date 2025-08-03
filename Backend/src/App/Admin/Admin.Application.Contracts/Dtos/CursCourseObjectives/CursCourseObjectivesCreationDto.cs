    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curscourseobjectivesDto
    /// </summary>
    [Serializable()]
    public class CursCourseObjectivesCreationDto : InputDto
     {
                 public int? CourseId { get; set; }
        public string? ObjectiveDescription { get; set; }
     }
