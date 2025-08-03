    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curquizzesDto
    /// </summary>
    [Serializable()]
    public class CurQuizzesDto : OutputFullAuditInfoDto
     {
                 public long ClassId { get; set; }
        public string? Description { get; set; }
        public int? DurationMinutes { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Title { get; set; }
        public int? TotalScore { get; set; }

        public virtual IList<CurQuestionsDto> CurQuestions { get; set; }

        public virtual CurQuizSubmissionsDto CurQuizSubmissions { get; set; }

        public virtual CurClassesDto CurClasses { get; set; }

        public virtual CurUsersDto CurUsers { get; set; }
     }
