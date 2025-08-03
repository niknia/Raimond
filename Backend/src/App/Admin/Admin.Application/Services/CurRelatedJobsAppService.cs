
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurRelatedJobsAppService : AbstractAppService,ICurRelatedJobsAppService
    {
          private readonly IEfRepository<CurRelatedJobs> _currelatedjobsRepository;
          private readonly CacheService _cacheService;
          
          public CurRelatedJobsAppService(IEfRepository<CurRelatedJobs> currelatedjobsRepository, CacheService cacheService)
            {
             _currelatedjobsRepository = currelatedjobsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurRelatedJobsCreationDto input)
            {
                input.TrimStringFields();
                var currelatedjobs = Mapper.Map<CurRelatedJobs>(input);
                currelatedjobs.Id = IdGenerater.GetNextId();
                await _currelatedjobsRepository.InsertAsync(currelatedjobs);
        
                return new IdDto(currelatedjobs.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurRelatedJobsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurRelatedJobs>(
                                   
               
        x=>x.CourseId
                    ,
               
        x=>x.JobId
                    ,
               
        x=>x.JobTitle
                     );
                  
                  var currelatedjobs = Mapper.Map<CurRelatedJobs>(input);
                  currelatedjobs.Id = id;
                  await _currelatedjobsRepository.UpdateAsync(currelatedjobs,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _currelatedjobsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurRelatedJobsDto>> GetPagedAsync(CurRelatedJobsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurRelatedJobs>();



        var total = await _currelatedjobsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurRelatedJobsDto>(search);

        var entities = await _currelatedjobsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var currelatedjobsDtos = Mapper.Map<List<CurRelatedJobsDto>>(entities);

        return new PageModelDto<CurRelatedJobsDto>(search, currelatedjobsDtos, total);
      }
       public async Task<CurRelatedJobsDto> GetAsync(long id)
        {
        var currelatedjobsEntity = await _currelatedjobsRepository.FindAsync(id);
        if (currelatedjobsEntity is null)
            return default;

        var currelatedjobsDto = Mapper.Map<CurRelatedJobsDto>(currelatedjobsEntity);
        return currelatedjobsDto;
        }
    }

