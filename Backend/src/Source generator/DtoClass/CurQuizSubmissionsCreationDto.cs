    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curquizsubmissionsDto
    /// </summary>
    [Serializable()]
    public class CurQuizSubmissionsCreationDto : InputDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public long QuizId { get; set; }
        public long StudentId { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public decimal? TotalScore { get; set; }
     }
    