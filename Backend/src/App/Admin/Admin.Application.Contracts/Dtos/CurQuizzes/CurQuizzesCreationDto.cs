    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curquizzesDto
    /// </summary>
    [Serializable()]
    public class CurQuizzesCreationDto : InputDto
     {
                 public long ClassId { get; set; }
        public string? Description { get; set; }
        public int? DurationMinutes { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Title { get; set; }
        public int? TotalScore { get; set; }
     }
