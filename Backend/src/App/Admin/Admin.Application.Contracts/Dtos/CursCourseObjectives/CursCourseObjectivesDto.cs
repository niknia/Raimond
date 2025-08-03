    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curscourseobjectivesDto
    /// </summary>
    [Serializable()]
    public class CursCourseObjectivesDto : OutputFullAuditInfoDto
     {
                 public int? CourseId { get; set; }
        public string? ObjectiveDescription { get; set; }
     }
