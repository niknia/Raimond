
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurMaritalStatusesAppService : AbstractAppService,ICurMaritalStatusesAppService
    {
          private readonly IEfRepository<CurMaritalStatuses> _curmaritalstatusesRepository;
          private readonly CacheService _cacheService;
          
          public CurMaritalStatusesAppService(IEfRepository<CurMaritalStatuses> curmaritalstatusesRepository, CacheService cacheService)
            {
             _curmaritalstatusesRepository = curmaritalstatusesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurMaritalStatusesCreationDto input)
            {
                input.TrimStringFields();
                var curmaritalstatuses = Mapper.Map<CurMaritalStatuses>(input);
                curmaritalstatuses.Id = IdGenerater.GetNextId();
                await _curmaritalstatusesRepository.InsertAsync(curmaritalstatuses);
        
                return new IdDto(curmaritalstatuses.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurMaritalStatusesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurMaritalStatuses>(
                                   ,
               
        x=>x.Name
                     );
                  
                  var curmaritalstatuses = Mapper.Map<CurMaritalStatuses>(input);
                  curmaritalstatuses.Id = id;
                  await _curmaritalstatusesRepository.UpdateAsync(curmaritalstatuses,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curmaritalstatusesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurMaritalStatusesDto>> GetPagedAsync(CurMaritalStatusesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurMaritalStatuses>();



        var total = await _curmaritalstatusesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurMaritalStatusesDto>(search);

        var entities = await _curmaritalstatusesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curmaritalstatusesDtos = Mapper.Map<List<CurMaritalStatusesDto>>(entities);

        return new PageModelDto<CurMaritalStatusesDto>(search, curmaritalstatusesDtos, total);
      }
       public async Task<CurMaritalStatusesDto> GetAsync(long id)
        {
        var curmaritalstatusesEntity = await _curmaritalstatusesRepository.FindAsync(id);
        if (curmaritalstatusesEntity is null)
            return default;

        var curmaritalstatusesDto = Mapper.Map<CurMaritalStatusesDto>(curmaritalstatusesEntity);
        return curmaritalstatusesDto;
        }
    }

