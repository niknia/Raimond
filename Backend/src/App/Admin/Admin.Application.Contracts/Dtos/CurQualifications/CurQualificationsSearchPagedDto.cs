    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curqualificationsDto
    /// </summary>
    [Serializable()]
    public class CurQualificationsSearchPagedDto : SearchPagedDto
     {
        public string QualificationLevel { get; set; }
     }
