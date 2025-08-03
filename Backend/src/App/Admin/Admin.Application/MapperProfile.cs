using System.Xml.Linq;

namespace Dkd.App.Admin.Application;

public sealed class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap(typeof(PagedModel<>), typeof(PageModelDto<>)).ForMember("XData", opt => opt.Ignore());
        CreateMap<MenuCreationDto, SysMenu>().ForMember(dest => dest.Params, opt => opt.MapFrom<KeyValuesToStringResolver>());
        CreateMap<MenuUpdationDto, SysMenu>().ForMember(dest => dest.Params, opt => opt.MapFrom<KeyValuesToStringResolver>());
        CreateMap<SysMenu, MenuDto>().ForMember(dest => dest.Params, opt => opt.MapFrom<StringToKeyValuesResolver>());
        CreateMap<MenuDto, MenuTreeDto>();
        CreateMap<RoleCreationDto, SysRole>();
        CreateMap<RoleUpdationDto, SysRole>();
        CreateMap<SysRole, RoleDto>().ReverseMap();

        CreateMap<SysUser, UserProfileDto>();
        CreateMap<UserCreationDto, SysUser>();
        CreateMap<UserUpdationDto, SysUser>();
        CreateMap<UserRegisterDto, SysUser>();

        CreateMap<SysUser, UserDto>();
        CreateMap<OrganizationCreationDto, SysOrganization>();
        CreateMap<OrganizationUpdationDto, SysOrganization>();
        CreateMap<SysOrganization, OrganizationDto>();
        CreateMap<OrganizationDto, OrganizationTreeDto>();
        CreateMap<OrganizationTreeDto, OptionTreeDto>()
            .ForMember(dest => dest.Label, opt => opt.MapFrom(x => x.Name))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(x => x.Id));
        CreateMap<DictCreationDto, SysDictionary>();
        CreateMap<DictUpdationDto, SysDictionary>();
        CreateMap<SysDictionary, DictDto>();
        CreateMap<DictDataCreationDto, SysDictionaryData>();
        CreateMap<DictDataUpdationDto, SysDictionaryData>();
        CreateMap<SysDictionaryData, DictDataDto>();
        CreateMap<SysConfigCreationDto, SysConfig>();
        CreateMap<SysConfigUpdationDto, SysConfig>();
        CreateMap<SysConfig, SysConfigDto>();

        CreateMap<SysConfigSimpleDto, SysConfigSimpleReply>();
        CreateMap<DictOptionDto, DictOptionReply>();

       
    }
}

public class KeyValuesToStringResolver : IValueResolver<MenuCreationDto, SysMenu, string>
{
    public string Resolve(MenuCreationDto source, SysMenu destination, string member, ResolutionContext context)
    {
        return source.Params.Select(x => $"{x.Key}={x.Value}").ToString("&");
    }
}

public class StringToKeyValuesResolver : IValueResolver<SysMenu, MenuDto, List<KeyValuePair<string, string>>>
{
    public List<KeyValuePair<string, string>> Resolve(SysMenu source, MenuDto destination, List<KeyValuePair<string, string>> member, ResolutionContext context)
    {
        if (source.Params.IsNullOrEmpty())
        {
            return [];
        }

        var keyValues = new List<KeyValuePair<string, string>>();
        foreach (var item in source.Params.Split("&"))
        {
            var array = item.Split("=");
            keyValues.Add(new KeyValuePair<string, string>(array[0], array[1]));
        }
        return keyValues;
    }
}
