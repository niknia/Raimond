    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curquestionanswersDto
    /// </summary>
    [Serializable()]
    public class CurQuestionAnswersCreationDto : InputDto
     {
                 public string? AnswerText { get; set; }
        public long QuestionId { get; set; }
        public decimal? Score { get; set; }
        public string? SelectedOptionIds { get; set; }
        public long SubmissionId { get; set; }
     }
