
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysRoleAppService : AbstractAppService,ISysRoleAppService
    {
          private readonly IEfRepository<SysRole> _sysroleRepository;
          private readonly CacheService _cacheService;
          
          public SysRoleAppService(IEfRepository<SysRole> sysroleRepository, CacheService cacheService)
            {
             _sysroleRepository = sysroleRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysRoleCreationDto input)
            {
                input.TrimStringFields();
                var sysrole = Mapper.Map<SysRole>(input);
                sysrole.Id = IdGenerater.GetNextId();
                await _sysroleRepository.InsertAsync(sysrole);
        
                return new IdDto(sysrole.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysRoleUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysRole>(
                                   ,
               
        x=>x.Code
                    ,
               
        x=>x.Datascope
                    ,
               
        x=>x.FkMenu
                    ,
               
        x=>x.Name
                    ,
               
        x=>x.Ordinal
                    ,
               
        x=>x.Status
                     );
                  
                  var sysrole = Mapper.Map<SysRole>(input);
                  sysrole.Id = id;
                  await _sysroleRepository.UpdateAsync(sysrole,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysroleRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysRoleDto>> GetPagedAsync(SysRoleSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysRole>();



        var total = await _sysroleRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysRoleDto>(search);

        var entities = await _sysroleRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysroleDtos = Mapper.Map<List<SysRoleDto>>(entities);

        return new PageModelDto<SysRoleDto>(search, sysroleDtos, total);
      }
       public async Task<SysRoleDto> GetAsync(long id)
        {
        var sysroleEntity = await _sysroleRepository.FindAsync(id);
        if (sysroleEntity is null)
            return default;

        var sysroleDto = Mapper.Map<SysRoleDto>(sysroleEntity);
        return sysroleDto;
        }
    }

