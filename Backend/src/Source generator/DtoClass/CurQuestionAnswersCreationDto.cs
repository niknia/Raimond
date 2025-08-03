    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curquestionanswersDto
    /// </summary>
    [Serializable()]
    public class CurQuestionAnswersCreationDto : InputDto
     {
                 public string? AnswerText { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public long QuestionId { get; set; }
        public decimal? Score { get; set; }
        public string? SelectedOptionIds { get; set; }
        public long SubmissionId { get; set; }
     }
    