
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysUserAppService : AbstractAppService,ISysUserAppService
    {
          private readonly IEfRepository<SysUser> _sysuserRepository;
          private readonly CacheService _cacheService;
          
          public SysUserAppService(IEfRepository<SysUser> sysuserRepository, CacheService cacheService)
            {
             _sysuserRepository = sysuserRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysUserCreationDto input)
            {
                input.TrimStringFields();
                var sysuser = Mapper.Map<SysUser>(input);
                sysuser.Id = IdGenerater.GetNextId();
                await _sysuserRepository.InsertAsync(sysuser);
        
                return new IdDto(sysuser.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysUserUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysUser>(
                                   ,
               
        x=>x.Account
   
        x=>x.Avatar
                    ,
               
        x=>x.Birthday
                    ,
               
        x=>x.Email
                    ,
               
        x=>x.FkMenu
                    ,
               
        x=>x.FkOrganization
                    ,
               
        x=>x.FkRole
                    ,
               
        x=>x.FkUserType
                    ,
               
        x=>x.Gender
                    ,
               
        x=>x.IsConfirmed
                    ,
               
        x=>x.Mobile
                    ,
               
        x=>x.Name
                    ,
               
        x=>x.NationalCode
                    ,
               
        x=>x.OtpToken
                    ,
               
        x=>x.Otpvalidto
                    ,
               
        x=>x.Password
                    ,
               
        x=>x.Salt
                    ,
               
        x=>x.Status
                     );
                  
                  var sysuser = Mapper.Map<SysUser>(input);
                  sysuser.Id = id;
                  await _sysuserRepository.UpdateAsync(sysuser,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysuserRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysUserDto>> GetPagedAsync(SysUserSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysUser>();



        var total = await _sysuserRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysUserDto>(search);

        var entities = await _sysuserRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysuserDtos = Mapper.Map<List<SysUserDto>>(entities);

        return new PageModelDto<SysUserDto>(search, sysuserDtos, total);
      }
       public async Task<SysUserDto> GetAsync(long id)
        {
        var sysuserEntity = await _sysuserRepository.FindAsync(id);
        if (sysuserEntity is null)
            return default;

        var sysuserDto = Mapper.Map<SysUserDto>(sysuserEntity);
        return sysuserDto;
        }
    }

