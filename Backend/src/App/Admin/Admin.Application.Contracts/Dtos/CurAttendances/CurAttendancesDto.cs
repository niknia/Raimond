    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curattendancesDto
    /// </summary>
    [Serializable()]
    public class CurAttendancesDto : OutputFullAuditInfoDto
     {
                 public long ClassId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime SessionDate { get; set; }
        public string? Status { get; set; }
        public long StudentId { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual CurClassesDto CurClasses { get; set; }

        public virtual CurUsersDto CurUsers { get; set; }
     }
