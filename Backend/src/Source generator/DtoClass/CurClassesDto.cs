    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curclassesDto
    /// </summary>
    [Serializable()]
    public class CurClassesDto : OutputFullAuditInfoDto
     {
                 public long CourseId { get; set; }
        public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxStudents { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public DateTime? StartDate { get; set; }
        public string? Status { get; set; }
        public long TeacherId { get; set; }

        public virtual IList<CurAssignmentsDto> CurAssignments { get; set; }

        public virtual CurAttendancesDto CurAttendances { get; set; }

        public virtual CurCoursesDto CurCourses { get; set; }

        public virtual CurUsersDto CurUsers { get; set; }

        public virtual CurEnrollmentsDto CurEnrollments { get; set; }

        public virtual IList<CurQuizzesDto> CurQuizzes { get; set; }

        public virtual IList<CurSchedulesDto> CurSchedules { get; set; }
     }
    