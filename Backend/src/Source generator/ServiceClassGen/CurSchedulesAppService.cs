
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurSchedulesAppService : AbstractAppService,ICurSchedulesAppService
    {
          private readonly IEfRepository<CurSchedules> _curschedulesRepository;
          private readonly CacheService _cacheService;
          
          public CurSchedulesAppService(IEfRepository<CurSchedules> curschedulesRepository, CacheService cacheService)
            {
             _curschedulesRepository = curschedulesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurSchedulesCreationDto input)
            {
                input.TrimStringFields();
                var curschedules = Mapper.Map<CurSchedules>(input);
                curschedules.Id = IdGenerater.GetNextId();
                await _curschedulesRepository.InsertAsync(curschedules);
        
                return new IdDto(curschedules.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurSchedulesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurSchedules>(
                                   ,
               
        x=>x.ClassId
                    ,
               
        x=>x.CreatedAt
                    ,
               
        x=>x.EndTime
                    ,
               
        x=>x.Location
                    ,
               
        x=>x.StartTime
                    ,
               
        x=>x.UpdatedAt
                    ,
               
        x=>x.Weekday
                     );
                  
                  var curschedules = Mapper.Map<CurSchedules>(input);
                  curschedules.Id = id;
                  await _curschedulesRepository.UpdateAsync(curschedules,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curschedulesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurSchedulesDto>> GetPagedAsync(CurSchedulesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurSchedules>();



        var total = await _curschedulesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurSchedulesDto>(search);

        var entities = await _curschedulesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curschedulesDtos = Mapper.Map<List<CurSchedulesDto>>(entities);

        return new PageModelDto<CurSchedulesDto>(search, curschedulesDtos, total);
      }
       public async Task<CurSchedulesDto> GetAsync(long id)
        {
        var curschedulesEntity = await _curschedulesRepository.FindAsync(id);
        if (curschedulesEntity is null)
            return default;

        var curschedulesDto = Mapper.Map<CurSchedulesDto>(curschedulesEntity);
        return curschedulesDto;
        }
    }

