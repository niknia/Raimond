    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curassignmentsubmissionsDto
    /// </summary>
    [Serializable()]
    public class CurAssignmentSubmissionsDto : OutputFullAuditInfoDto
     {
                 public long AssignmentId { get; set; }
        public string? Comment { get; set; }
        public string? FileUrl { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public long? ReviewedBy { get; set; }
        public decimal? Score { get; set; }
        public long StudentId { get; set; }
        public DateTime? SubmittedAt { get; set; }

        public virtual CurAssignmentsDto CurAssignments { get; set; }

        public virtual CurUsersDto CurUsers_StudentId { get; set; }

        public virtual CurUsersDto CurUsers_ReviewedBy { get; set; }
     }
