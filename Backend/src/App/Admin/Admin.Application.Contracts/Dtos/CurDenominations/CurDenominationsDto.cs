    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curdenominationsDto
    /// </summary>
    [Serializable()]
    public class CurDenominationsDto : OutputFullAuditInfoDto
     {
        public string Name { get; set; }

        public virtual IList<CurTeachersDto> CurTeachers { get; set; }
     }
