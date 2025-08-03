    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curqualificationsDto
    /// </summary>
    [Serializable()]
    public class CurQualificationsDto : OutputFullAuditInfoDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string QualificationLevel { get; set; }
     }
    