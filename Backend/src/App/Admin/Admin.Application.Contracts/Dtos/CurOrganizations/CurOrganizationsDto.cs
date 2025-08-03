    namespace Dkd.App.Admin.Application.Contracts.Dtos;
    /// <summary>
    /// curorganizationsDto
    /// </summary>
    [Serializable()]
    public class CurOrganizationsDto : OutputFullAuditInfoDto
     {
                 public string? Code { get; set; }
        public int? Level { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string? Path { get; set; }
        public string? Type { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual IList<CurOrganizationsDto> CurOrganizations_ParentId1 { get; set; }

        public virtual CurOrganizationsDto CurOrganizations_ParentId { get; set; }

        public virtual IList<CurUsersDto> CurUsers { get; set; }
     }
