namespace Dkd.App.Admin.Application.Contracts.Dtos;
/// <summary>
/// sysusertypeDto
/// </summary>
[Serializable()]
    public class SysUserTypeCreationDto : InputDto
     {
                 public bool IsDeleted { get; set; }
        public string? Name { get; set; }
     }
