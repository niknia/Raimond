    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curassignmentsDto
    /// </summary>
    [Serializable()]
    public class CurAssignmentsSearchPagedDto : SearchPagedDto
     {
                 public long ClassId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int? MaxScore { get; set; }
        public string? Title { get; set; }
     }
