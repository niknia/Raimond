    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curdegreesDto
    /// </summary>
    [Serializable()]
    public class CurDegreesDto : OutputFullAuditInfoDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string Name { get; set; }

        public virtual IList<CurTeachersDto> CurTeachers { get; set; }
     }
    