
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurReligionsAppService : AbstractAppService,ICurReligionsAppService
    {
          private readonly IEfRepository<CurReligions> _curreligionsRepository;
          private readonly CacheService _cacheService;
          
          public CurReligionsAppService(IEfRepository<CurReligions> curreligionsRepository, CacheService cacheService)
            {
             _curreligionsRepository = curreligionsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurReligionsCreationDto input)
            {
                input.TrimStringFields();
                var curreligions = Mapper.Map<CurReligions>(input);
                curreligions.Id = IdGenerater.GetNextId();
                await _curreligionsRepository.InsertAsync(curreligions);
        
                return new IdDto(curreligions.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurReligionsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurReligions>(
                                   ,
               
        x=>x.Name
                     );
                  
                  var curreligions = Mapper.Map<CurReligions>(input);
                  curreligions.Id = id;
                  await _curreligionsRepository.UpdateAsync(curreligions,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curreligionsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurReligionsDto>> GetPagedAsync(CurReligionsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurReligions>();



        var total = await _curreligionsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurReligionsDto>(search);

        var entities = await _curreligionsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curreligionsDtos = Mapper.Map<List<CurReligionsDto>>(entities);

        return new PageModelDto<CurReligionsDto>(search, curreligionsDtos, total);
      }
       public async Task<CurReligionsDto> GetAsync(long id)
        {
        var curreligionsEntity = await _curreligionsRepository.FindAsync(id);
        if (curreligionsEntity is null)
            return default;

        var curreligionsDto = Mapper.Map<CurReligionsDto>(curreligionsEntity);
        return curreligionsDto;
        }
    }

