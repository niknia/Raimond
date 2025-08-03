    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curteachersDto
    /// </summary>
    [Serializable()]
    public class CurTeachersDto : OutputFullAuditInfoDto
     {
                 public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public long Createby { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime Createtime { get; set; }
        public int DegreeId { get; set; }
        public int? DenominationId { get; set; }
        public string? FatherName { get; set; }
        public int? FieldOfStudyId { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string? IdIssuePlace { get; set; }
        public string? IdNumber { get; set; }
        public bool? IsAcademicMember { get; set; }
        public string LastName { get; set; }
        public int? MaritalStatusId { get; set; }
        public string? MilitaryStatus { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string NationalCode { get; set; }
        public string? PhoneLandline { get; set; }
        public string PhoneMobile { get; set; }
        public string? PostalCode { get; set; }
        public int? ReligionId { get; set; }
        public int TeacherTypeId { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual CurReligionsDto CurReligions { get; set; }

        public virtual CurDenominationsDto CurDenominations { get; set; }

        public virtual CurMaritalStatusesDto CurMaritalStatuses { get; set; }

        public virtual CurTeacherTypesDto CurTeacherTypes { get; set; }

        public virtual CurDegreesDto CurDegrees { get; set; }

        public virtual CurFieldsOfStudyDto CurFieldsOfStudy { get; set; }
     }
    