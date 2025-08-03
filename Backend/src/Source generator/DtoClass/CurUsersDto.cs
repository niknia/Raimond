    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curusersDto
    /// </summary>
    [Serializable()]
    public class CurUsersDto : OutputFullAuditInfoDto
     {
                 public long Createby { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime Createtime { get; set; }
        public string? Email { get; set; }
        public string? EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string? NationalCode { get; set; }
        public long? OrganizationId { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; }
        public string? Status { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual IList<CurAssignmentSubmissionsDto> CurAssignmentSubmissions_StudentId { get; set; }

        public virtual IList<CurAssignmentSubmissionsDto> CurAssignmentSubmissions_ReviewedBy { get; set; }

        public virtual IList<CurAssignmentsDto> CurAssignments { get; set; }

        public virtual CurAttendancesDto CurAttendances { get; set; }

        public virtual IList<CurClassesDto> CurClasses { get; set; }

        public virtual IList<CurCoursesDto> CurCourses { get; set; }

        public virtual CurEnrollmentsDto CurEnrollments { get; set; }

        public virtual IList<CurLrsLogsDto> CurLrsLogs { get; set; }

        public virtual CurQuizSubmissionsDto CurQuizSubmissions { get; set; }

        public virtual IList<CurQuizzesDto> CurQuizzes { get; set; }

        public virtual CurOrganizationsDto CurOrganizations { get; set; }
     }
    