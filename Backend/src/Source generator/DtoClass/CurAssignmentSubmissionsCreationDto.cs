    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curassignmentsubmissionsDto
    /// </summary>
    [Serializable()]
    public class CurAssignmentSubmissionsCreationDto : InputDto
     {
                 public long AssignmentId { get; set; }
        public string? Comment { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public string? FileUrl { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public long? ReviewedBy { get; set; }
        public decimal? Score { get; set; }
        public long StudentId { get; set; }
        public DateTime? SubmittedAt { get; set; }
     }
    