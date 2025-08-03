    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curteachertypesDto
    /// </summary>
    [Serializable()]
    public class CurTeacherTypesDto : OutputFullAuditInfoDto
     {
        public string Name { get; set; }

        public virtual IList<CurTeachersDto> CurTeachers { get; set; }
     }
