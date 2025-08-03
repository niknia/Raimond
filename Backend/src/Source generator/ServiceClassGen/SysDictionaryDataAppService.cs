
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysDictionaryDataAppService : AbstractAppService,ISysDictionaryDataAppService
    {
          private readonly IEfRepository<SysDictionaryData> _sysdictionarydataRepository;
          private readonly CacheService _cacheService;
          
          public SysDictionaryDataAppService(IEfRepository<SysDictionaryData> sysdictionarydataRepository, CacheService cacheService)
            {
             _sysdictionarydataRepository = sysdictionarydataRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysDictionaryDataCreationDto input)
            {
                input.TrimStringFields();
                var sysdictionarydata = Mapper.Map<SysDictionaryData>(input);
                sysdictionarydata.Id = IdGenerater.GetNextId();
                await _sysdictionarydataRepository.InsertAsync(sysdictionarydata);
        
                return new IdDto(sysdictionarydata.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysDictionaryDataUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysDictionaryData>(
                                   ,
               
        x=>x.Dictcode
                    ,
               
        x=>x.Label
                    ,
               
        x=>x.Ordinal
                    ,
               
        x=>x.Status
                    ,
               
        x=>x.Tagtype
                    ,
               
        x=>x.Value
                     );
                  
                  var sysdictionarydata = Mapper.Map<SysDictionaryData>(input);
                  sysdictionarydata.Id = id;
                  await _sysdictionarydataRepository.UpdateAsync(sysdictionarydata,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysdictionarydataRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysDictionaryDataDto>> GetPagedAsync(SysDictionaryDataSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysDictionaryData>();



        var total = await _sysdictionarydataRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysDictionaryDataDto>(search);

        var entities = await _sysdictionarydataRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysdictionarydataDtos = Mapper.Map<List<SysDictionaryDataDto>>(entities);

        return new PageModelDto<SysDictionaryDataDto>(search, sysdictionarydataDtos, total);
      }
       public async Task<SysDictionaryDataDto> GetAsync(long id)
        {
        var sysdictionarydataEntity = await _sysdictionarydataRepository.FindAsync(id);
        if (sysdictionarydataEntity is null)
            return default;

        var sysdictionarydataDto = Mapper.Map<SysDictionaryDataDto>(sysdictionarydataEntity);
        return sysdictionarydataDto;
        }
    }

