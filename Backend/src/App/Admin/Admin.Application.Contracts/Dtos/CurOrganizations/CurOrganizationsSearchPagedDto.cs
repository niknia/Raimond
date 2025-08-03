    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curorganizationsDto
    /// </summary>
    [Serializable()]
    public class CurOrganizationsSearchPagedDto : SearchPagedDto
     {
                 public string? Code { get; set; }
        public int? Level { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string? Path { get; set; }
        public string? Type { get; set; }
     }
