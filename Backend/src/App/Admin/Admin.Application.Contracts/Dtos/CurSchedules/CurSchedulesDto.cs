    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curschedulesDto
    /// </summary>
    [Serializable()]
    public class CurSchedulesDto : OutputFullAuditInfoDto
     {
                 public long ClassId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Location { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Weekday { get; set; }

        public virtual CurClassesDto CurClasses { get; set; }
     }
