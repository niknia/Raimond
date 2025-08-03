    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curanswersDto
    /// </summary>
    [Serializable()]
    public class CurAnswersCreationDto : InputDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public bool? IsCorrect { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public long QuestionId { get; set; }
        public string? Text { get; set; }
     }
    