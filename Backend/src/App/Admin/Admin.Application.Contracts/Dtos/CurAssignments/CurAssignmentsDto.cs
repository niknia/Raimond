    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curassignmentsDto
    /// </summary>
    [Serializable()]
    public class CurAssignmentsDto : OutputFullAuditInfoDto
     {
                 public long ClassId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int? MaxScore { get; set; }
        public string? Title { get; set; }

        public virtual IList<CurAssignmentSubmissionsDto> CurAssignmentSubmissions { get; set; }

        public virtual CurClassesDto CurClasses { get; set; }

        public virtual CurUsersDto CurUsers { get; set; }
     }
