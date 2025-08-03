    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curanswersDto
    /// </summary>
    [Serializable()]
    public class CurAnswersSearchPagedDto : SearchPagedDto
     {
        public bool? IsCorrect { get; set; }
        public long QuestionId { get; set; }
        public string? Text { get; set; }
     }
