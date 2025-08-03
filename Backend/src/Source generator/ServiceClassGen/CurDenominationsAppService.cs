
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurDenominationsAppService : AbstractAppService,ICurDenominationsAppService
    {
          private readonly IEfRepository<CurDenominations> _curdenominationsRepository;
          private readonly CacheService _cacheService;
          
          public CurDenominationsAppService(IEfRepository<CurDenominations> curdenominationsRepository, CacheService cacheService)
            {
             _curdenominationsRepository = curdenominationsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurDenominationsCreationDto input)
            {
                input.TrimStringFields();
                var curdenominations = Mapper.Map<CurDenominations>(input);
                curdenominations.Id = IdGenerater.GetNextId();
                await _curdenominationsRepository.InsertAsync(curdenominations);
        
                return new IdDto(curdenominations.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurDenominationsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurDenominations>(
                                   ,
               
        x=>x.Name
                     );
                  
                  var curdenominations = Mapper.Map<CurDenominations>(input);
                  curdenominations.Id = id;
                  await _curdenominationsRepository.UpdateAsync(curdenominations,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curdenominationsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurDenominationsDto>> GetPagedAsync(CurDenominationsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurDenominations>();



        var total = await _curdenominationsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurDenominationsDto>(search);

        var entities = await _curdenominationsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curdenominationsDtos = Mapper.Map<List<CurDenominationsDto>>(entities);

        return new PageModelDto<CurDenominationsDto>(search, curdenominationsDtos, total);
      }
       public async Task<CurDenominationsDto> GetAsync(long id)
        {
        var curdenominationsEntity = await _curdenominationsRepository.FindAsync(id);
        if (curdenominationsEntity is null)
            return default;

        var curdenominationsDto = Mapper.Map<CurDenominationsDto>(curdenominationsEntity);
        return curdenominationsDto;
        }
    }

