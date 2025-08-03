    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curdegreesDto
    /// </summary>
    [Serializable()]
    public class CurDegreesDto : OutputFullAuditInfoDto
     {
        public string Name { get; set; }

        public virtual IList<CurTeachersDto> CurTeachers { get; set; }
     }
