    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curquizsubmissionsDto
    /// </summary>
    [Serializable()]
    public class CurQuizSubmissionsCreationDto : InputDto
     {
        public long QuizId { get; set; }
        public long StudentId { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public decimal? TotalScore { get; set; }
     }
