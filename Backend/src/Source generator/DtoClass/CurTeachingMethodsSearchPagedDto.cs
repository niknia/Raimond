    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curteachingmethodsDto
    /// </summary>
    [Serializable()]
    public class CurTeachingMethodsSearchPagedDto : SearchPagedDto
     {
                 public long Createby { get; set; }
        public DateTime Createtime { get; set; }
        public string MethodName { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
     }
    