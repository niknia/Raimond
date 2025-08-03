    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curquizsubmissionsDto
    /// </summary>
    [Serializable()]
    public class CurQuizSubmissionsDto : OutputFullAuditInfoDto
     {
        public long QuizId { get; set; }
        public long StudentId { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public decimal? TotalScore { get; set; }

        public virtual IList<CurQuestionAnswersDto> CurQuestionAnswers { get; set; }

        public virtual CurQuizzesDto CurQuizzes { get; set; }

        public virtual CurUsersDto CurUsers { get; set; }
     }
