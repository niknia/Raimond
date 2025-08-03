    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curfieldsofstudyDto
    /// </summary>
    [Serializable()]
    public class CurFieldsOfStudyDto : OutputFullAuditInfoDto
     {
        public string Name { get; set; }

        public virtual IList<CurTeachersDto> CurTeachers { get; set; }
     }
