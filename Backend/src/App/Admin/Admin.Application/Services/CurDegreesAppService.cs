
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurDegreesAppService : AbstractAppService,ICurDegreesAppService
    {
          private readonly IEfRepository<CurDegrees> _curdegreesRepository;
          private readonly CacheService _cacheService;
          
          public CurDegreesAppService(IEfRepository<CurDegrees> curdegreesRepository, CacheService cacheService)
            {
             _curdegreesRepository = curdegreesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurDegreesCreationDto input)
            {
                input.TrimStringFields();
                var curdegrees = Mapper.Map<CurDegrees>(input);
                curdegrees.Id = IdGenerater.GetNextId();
                await _curdegreesRepository.InsertAsync(curdegrees);
        
                return new IdDto(curdegrees.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurDegreesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurDegrees>(
                                   
               
        x=>x.Name
                     );
                  
                  var curdegrees = Mapper.Map<CurDegrees>(input);
                  curdegrees.Id = id;
                  await _curdegreesRepository.UpdateAsync(curdegrees,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curdegreesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurDegreesDto>> GetPagedAsync(CurDegreesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurDegrees>();



        var total = await _curdegreesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurDegreesDto>(search);

        var entities = await _curdegreesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curdegreesDtos = Mapper.Map<List<CurDegreesDto>>(entities);

        return new PageModelDto<CurDegreesDto>(search, curdegreesDtos, total);
      }
       public async Task<CurDegreesDto> GetAsync(long id)
        {
        var curdegreesEntity = await _curdegreesRepository.FindAsync(id);
        if (curdegreesEntity is null)
            return default;

        var curdegreesDto = Mapper.Map<CurDegreesDto>(curdegreesEntity);
        return curdegreesDto;
        }
    }

