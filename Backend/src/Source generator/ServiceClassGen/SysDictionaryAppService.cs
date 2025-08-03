
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysDictionaryAppService : AbstractAppService,ISysDictionaryAppService
    {
          private readonly IEfRepository<SysDictionary> _sysdictionaryRepository;
          private readonly CacheService _cacheService;
          
          public SysDictionaryAppService(IEfRepository<SysDictionary> sysdictionaryRepository, CacheService cacheService)
            {
             _sysdictionaryRepository = sysdictionaryRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysDictionaryCreationDto input)
            {
                input.TrimStringFields();
                var sysdictionary = Mapper.Map<SysDictionary>(input);
                sysdictionary.Id = IdGenerater.GetNextId();
                await _sysdictionaryRepository.InsertAsync(sysdictionary);
        
                return new IdDto(sysdictionary.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysDictionaryUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysDictionary>(
                                   ,
               
        x=>x.Code
                    ,
               
        x=>x.Name
                    ,
               
        x=>x.Remark
                    ,
               
        x=>x.Status
                     );
                  
                  var sysdictionary = Mapper.Map<SysDictionary>(input);
                  sysdictionary.Id = id;
                  await _sysdictionaryRepository.UpdateAsync(sysdictionary,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysdictionaryRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysDictionaryDto>> GetPagedAsync(SysDictionarySearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysDictionary>();



        var total = await _sysdictionaryRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysDictionaryDto>(search);

        var entities = await _sysdictionaryRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysdictionaryDtos = Mapper.Map<List<SysDictionaryDto>>(entities);

        return new PageModelDto<SysDictionaryDto>(search, sysdictionaryDtos, total);
      }
       public async Task<SysDictionaryDto> GetAsync(long id)
        {
        var sysdictionaryEntity = await _sysdictionaryRepository.FindAsync(id);
        if (sysdictionaryEntity is null)
            return default;

        var sysdictionaryDto = Mapper.Map<SysDictionaryDto>(sysdictionaryEntity);
        return sysdictionaryDto;
        }
    }

