
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CursCourseObjectivesAppService : AbstractAppService,ICursCourseObjectivesAppService
    {
          private readonly IEfRepository<CursCourseObjectives> _curscourseobjectivesRepository;
          private readonly CacheService _cacheService;
          
          public CursCourseObjectivesAppService(IEfRepository<CursCourseObjectives> curscourseobjectivesRepository, CacheService cacheService)
            {
             _curscourseobjectivesRepository = curscourseobjectivesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CursCourseObjectivesCreationDto input)
            {
                input.TrimStringFields();
                var curscourseobjectives = Mapper.Map<CursCourseObjectives>(input);
                curscourseobjectives.Id = IdGenerater.GetNextId();
                await _curscourseobjectivesRepository.InsertAsync(curscourseobjectives);
        
                return new IdDto(curscourseobjectives.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CursCourseObjectivesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CursCourseObjectives>(
                                   
               
        x=>x.CourseId
                    ,
               
        x=>x.ObjectiveDescription
                     );
                  
                  var curscourseobjectives = Mapper.Map<CursCourseObjectives>(input);
                  curscourseobjectives.Id = id;
                  await _curscourseobjectivesRepository.UpdateAsync(curscourseobjectives,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curscourseobjectivesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CursCourseObjectivesDto>> GetPagedAsync(CursCourseObjectivesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CursCourseObjectives>();



        var total = await _curscourseobjectivesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CursCourseObjectivesDto>(search);

        var entities = await _curscourseobjectivesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curscourseobjectivesDtos = Mapper.Map<List<CursCourseObjectivesDto>>(entities);

        return new PageModelDto<CursCourseObjectivesDto>(search, curscourseobjectivesDtos, total);
      }
       public async Task<CursCourseObjectivesDto> GetAsync(long id)
        {
        var curscourseobjectivesEntity = await _curscourseobjectivesRepository.FindAsync(id);
        if (curscourseobjectivesEntity is null)
            return default;

        var curscourseobjectivesDto = Mapper.Map<CursCourseObjectivesDto>(curscourseobjectivesEntity);
        return curscourseobjectivesDto;
        }
    }

