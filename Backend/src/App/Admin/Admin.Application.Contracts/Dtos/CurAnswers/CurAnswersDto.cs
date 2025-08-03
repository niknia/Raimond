    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curanswersDto
    /// </summary>
    [Serializable()]
    public class CurAnswersDto : OutputFullAuditInfoDto
     {
        public bool? IsCorrect { get; set; }
        public long QuestionId { get; set; }
        public string? Text { get; set; }

        public virtual CurQuestionsDto CurQuestions { get; set; }
     }
