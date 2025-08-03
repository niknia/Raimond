    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curquestionsDto
    /// </summary>
    [Serializable()]
    public class CurQuestionsDto : OutputFullAuditInfoDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public long QuizId { get; set; }
        public int? Score { get; set; }
        public string? Text { get; set; }
        public string Type { get; set; }

        public virtual IList<CurAnswersDto> CurAnswers { get; set; }

        public virtual IList<CurQuestionAnswersDto> CurQuestionAnswers { get; set; }

        public virtual CurQuizzesDto CurQuizzes { get; set; }
     }
    