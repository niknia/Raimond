    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curreligionsDto
    /// </summary>
    [Serializable()]
    public class CurReligionsDto : OutputFullAuditInfoDto
     {
        public string Name { get; set; }

        public virtual IList<CurTeachersDto> CurTeachers { get; set; }
     }
