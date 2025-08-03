    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curlrslogsDto
    /// </summary>
    [Serializable()]
    public class CurLrsLogsDto : OutputFullAuditInfoDto
     {
                 public string? Context { get; set; }
        public long? CourseId { get; set; }
        public string? Object { get; set; }
        public string? Result { get; set; }
        public string? StatementId { get; set; }
        public DateTime? Timestamp { get; set; }
        public long UserId { get; set; }
        public string? Verb { get; set; }

        public virtual CurUsersDto CurUsers { get; set; }

        public virtual CurCoursesDto CurCourses { get; set; }
     }
