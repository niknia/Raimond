
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurTeachingMethodsAppService : AbstractAppService,ICurTeachingMethodsAppService
    {
          private readonly IEfRepository<CurTeachingMethods> _curteachingmethodsRepository;
          private readonly CacheService _cacheService;
          
          public CurTeachingMethodsAppService(IEfRepository<CurTeachingMethods> curteachingmethodsRepository, CacheService cacheService)
            {
             _curteachingmethodsRepository = curteachingmethodsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurTeachingMethodsCreationDto input)
            {
                input.TrimStringFields();
                var curteachingmethods = Mapper.Map<CurTeachingMethods>(input);
                curteachingmethods.Id = IdGenerater.GetNextId();
                await _curteachingmethodsRepository.InsertAsync(curteachingmethods);
        
                return new IdDto(curteachingmethods.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurTeachingMethodsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurTeachingMethods>(
                                   
               
        x=>x.MethodName
                     );
                  
                  var curteachingmethods = Mapper.Map<CurTeachingMethods>(input);
                  curteachingmethods.Id = id;
                  await _curteachingmethodsRepository.UpdateAsync(curteachingmethods,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curteachingmethodsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurTeachingMethodsDto>> GetPagedAsync(CurTeachingMethodsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurTeachingMethods>();



        var total = await _curteachingmethodsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurTeachingMethodsDto>(search);

        var entities = await _curteachingmethodsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curteachingmethodsDtos = Mapper.Map<List<CurTeachingMethodsDto>>(entities);

        return new PageModelDto<CurTeachingMethodsDto>(search, curteachingmethodsDtos, total);
      }
       public async Task<CurTeachingMethodsDto> GetAsync(long id)
        {
        var curteachingmethodsEntity = await _curteachingmethodsRepository.FindAsync(id);
        if (curteachingmethodsEntity is null)
            return default;

        var curteachingmethodsDto = Mapper.Map<CurTeachingMethodsDto>(curteachingmethodsEntity);
        return curteachingmethodsDto;
        }
    }

