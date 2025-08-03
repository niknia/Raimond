    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curschedulesDto
    /// </summary>
    [Serializable()]
    public class CurSchedulesCreationDto : InputDto
     {
                 public long ClassId { get; set; }
        public long Createby { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime Createtime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Location { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Weekday { get; set; }
     }
    