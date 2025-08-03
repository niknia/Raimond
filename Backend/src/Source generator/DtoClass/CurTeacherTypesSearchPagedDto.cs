    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curteachertypesDto
    /// </summary>
    [Serializable()]
    public class CurTeacherTypesSearchPagedDto : SearchPagedDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string Name { get; set; }
     }
    