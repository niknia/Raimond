    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// currelatedjobsDto
    /// </summary>
    [Serializable()]
    public class CurRelatedJobsSearchPagedDto : SearchPagedDto
     {
                 public int? CourseId { get; set; }
        public long JobId { get; set; }
        public string? JobTitle { get; set; }
     }
