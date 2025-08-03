    namespace Dkd.App.Admin.Application.Dtos;
    /// <summary>
    /// curorganizationsDto
    /// </summary>
    [Serializable()]
    public class CurOrganizationsSearchPagedDto : SearchPagedDto
     {
                 public string? Code { get; set; }
        public long Createby { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime Createtime { get; set; }
        public int? Level { get; set; }
        public long? Modifyby { get; set; }
        public DateTime? Modifytime { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string? Path { get; set; }
        public string? Type { get; set; }
        public DateTime? UpdatedAt { get; set; }
     }
    