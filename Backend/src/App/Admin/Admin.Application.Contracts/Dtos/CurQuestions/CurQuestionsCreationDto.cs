    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curquestionsDto
    /// </summary>
    [Serializable()]
    public class CurQuestionsCreationDto : InputDto
     {
        public long QuizId { get; set; }
        public int? Score { get; set; }
        public string? Text { get; set; }
        public string Type { get; set; }
     }
