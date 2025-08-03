    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curmaritalstatusesDto
    /// </summary>
    [Serializable()]
    public class CurMaritalStatusesDto : OutputFullAuditInfoDto
     {
        public string Name { get; set; }

        public virtual IList<CurTeachersDto> CurTeachers { get; set; }
     }
