
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysUserTypeAppService : AbstractAppService,ISysUserTypeAppService
    {
          private readonly IEfRepository<SysUserType> _sysusertypeRepository;
          private readonly CacheService _cacheService;
          
          public SysUserTypeAppService(IEfRepository<SysUserType> sysusertypeRepository, CacheService cacheService)
            {
             _sysusertypeRepository = sysusertypeRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysUserTypeCreationDto input)
            {
                input.TrimStringFields();
                var sysusertype = Mapper.Map<SysUserType>(input);
                sysusertype.Id = IdGenerater.GetNextId();
                await _sysusertypeRepository.InsertAsync(sysusertype);
        
                return new IdDto(sysusertype.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysUserTypeUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysUserType>(
                  
        x=>x.IsDeleted
                    ,
               
        x=>x.Name
                     );
                  
                  var sysusertype = Mapper.Map<SysUserType>(input);
                  sysusertype.Id = id;
                  await _sysusertypeRepository.UpdateAsync(sysusertype,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysusertypeRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysUserTypeDto>> GetPagedAsync(SysUserTypeSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysUserType>();



        var total = await _sysusertypeRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysUserTypeDto>(search);

        var entities = await _sysusertypeRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysusertypeDtos = Mapper.Map<List<SysUserTypeDto>>(entities);

        return new PageModelDto<SysUserTypeDto>(search, sysusertypeDtos, total);
      }
       public async Task<SysUserTypeDto> GetAsync(long id)
        {
        var sysusertypeEntity = await _sysusertypeRepository.FindAsync(id);
        if (sysusertypeEntity is null)
            return default;

        var sysusertypeDto = Mapper.Map<SysUserTypeDto>(sysusertypeEntity);
        return sysusertypeDto;
        }
    }

