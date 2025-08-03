    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curfieldsofstudyDto
    /// </summary>
    [Serializable()]
    public class CurFieldsOfStudyCreationDto : InputDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string Name { get; set; }
     }
    