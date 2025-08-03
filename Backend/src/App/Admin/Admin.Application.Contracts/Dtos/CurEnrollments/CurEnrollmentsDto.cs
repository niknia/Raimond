    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curenrollmentsDto
    /// </summary>
    [Serializable()]
    public class CurEnrollmentsDto : OutputFullAuditInfoDto
     {
                 public long ClassId { get; set; }
        public string? Status { get; set; }
        public long StudentId { get; set; }

        public virtual CurClassesDto CurClasses { get; set; }

        public virtual CurUsersDto CurUsers { get; set; }
     }
