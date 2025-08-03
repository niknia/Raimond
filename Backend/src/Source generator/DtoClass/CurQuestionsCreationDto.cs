    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curquestionsDto
    /// </summary>
    [Serializable()]
    public class CurQuestionsCreationDto : InputDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public long QuizId { get; set; }
        public int? Score { get; set; }
        public string? Text { get; set; }
        public string Type { get; set; }
     }
    