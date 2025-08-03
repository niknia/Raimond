    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curreligionsDto
    /// </summary>
    [Serializable()]
    public class CurReligionsCreationDto : InputDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string Name { get; set; }
     }
    