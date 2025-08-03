namespace Dkd.App.Admin.Application.Contracts.Dtos;
/// <summary>
/// sysusertypeDto
/// </summary>
[Serializable()]
    public class SysUserTypeDto : OutputFullAuditInfoDto
     {
                 public bool IsDeleted { get; set; }
        public string? Name { get; set; }
         public virtual IList<UserDto> SysUsers { get; set; }
     }
