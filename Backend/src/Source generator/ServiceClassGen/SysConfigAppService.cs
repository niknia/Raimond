
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysConfigAppService : AbstractAppService,ISysConfigAppService
    {
          private readonly IEfRepository<SysConfig> _sysconfigRepository;
          private readonly CacheService _cacheService;
          
          public SysConfigAppService(IEfRepository<SysConfig> sysconfigRepository, CacheService cacheService)
            {
             _sysconfigRepository = sysconfigRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysConfigCreationDto input)
            {
                input.TrimStringFields();
                var sysconfig = Mapper.Map<SysConfig>(input);
                sysconfig.Id = IdGenerater.GetNextId();
                await _sysconfigRepository.InsertAsync(sysconfig);
        
                return new IdDto(sysconfig.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysConfigUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysConfig>(
                                   ,
               
        x=>x.Key
                    ,
               
        x=>x.Name
                    ,
               
        x=>x.Remark
                    ,
               
        x=>x.Value
                     );
                  
                  var sysconfig = Mapper.Map<SysConfig>(input);
                  sysconfig.Id = id;
                  await _sysconfigRepository.UpdateAsync(sysconfig,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysconfigRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysConfigDto>> GetPagedAsync(SysConfigSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysConfig>();



        var total = await _sysconfigRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysConfigDto>(search);

        var entities = await _sysconfigRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysconfigDtos = Mapper.Map<List<SysConfigDto>>(entities);

        return new PageModelDto<SysConfigDto>(search, sysconfigDtos, total);
      }
       public async Task<SysConfigDto> GetAsync(long id)
        {
        var sysconfigEntity = await _sysconfigRepository.FindAsync(id);
        if (sysconfigEntity is null)
            return default;

        var sysconfigDto = Mapper.Map<SysConfigDto>(sysconfigEntity);
        return sysconfigDto;
        }
    }

