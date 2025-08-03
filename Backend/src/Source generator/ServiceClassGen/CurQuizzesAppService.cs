
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurQuizzesAppService : AbstractAppService,ICurQuizzesAppService
    {
          private readonly IEfRepository<CurQuizzes> _curquizzesRepository;
          private readonly CacheService _cacheService;
          
          public CurQuizzesAppService(IEfRepository<CurQuizzes> curquizzesRepository, CacheService cacheService)
            {
             _curquizzesRepository = curquizzesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurQuizzesCreationDto input)
            {
                input.TrimStringFields();
                var curquizzes = Mapper.Map<CurQuizzes>(input);
                curquizzes.Id = IdGenerater.GetNextId();
                await _curquizzesRepository.InsertAsync(curquizzes);
        
                return new IdDto(curquizzes.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurQuizzesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurQuizzes>(
                                   ,
               
        x=>x.ClassId
                    ,
               
        x=>x.CreatedBy
                    ,
               
        x=>x.Description
                    ,
               
        x=>x.DurationMinutes
                    ,
               
        x=>x.EndTime
                    ,
               
        x=>x.StartTime
                    ,
               
        x=>x.Title
                    ,
               
        x=>x.TotalScore
                     );
                  
                  var curquizzes = Mapper.Map<CurQuizzes>(input);
                  curquizzes.Id = id;
                  await _curquizzesRepository.UpdateAsync(curquizzes,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curquizzesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurQuizzesDto>> GetPagedAsync(CurQuizzesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurQuizzes>();



        var total = await _curquizzesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurQuizzesDto>(search);

        var entities = await _curquizzesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curquizzesDtos = Mapper.Map<List<CurQuizzesDto>>(entities);

        return new PageModelDto<CurQuizzesDto>(search, curquizzesDtos, total);
      }
       public async Task<CurQuizzesDto> GetAsync(long id)
        {
        var curquizzesEntity = await _curquizzesRepository.FindAsync(id);
        if (curquizzesEntity is null)
            return default;

        var curquizzesDto = Mapper.Map<CurQuizzesDto>(curquizzesEntity);
        return curquizzesDto;
        }
    }

