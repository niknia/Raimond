    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curusersDto
    /// </summary>
    [Serializable()]
    public class CurUsersDto : OutputFullAuditInfoDto
     {
        public DateTime? CreatedAt { get; set; }
        public string? Email { get; set; }
        public string? EmployeeNumber { get; set; }
        public string FullName { get; set; }
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
