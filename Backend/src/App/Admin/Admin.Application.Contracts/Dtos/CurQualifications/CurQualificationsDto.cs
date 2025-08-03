    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curqualificationsDto
    /// </summary>
    [Serializable()]
    public class CurQualificationsDto : OutputFullAuditInfoDto
     {
        public string QualificationLevel { get; set; }
     }
