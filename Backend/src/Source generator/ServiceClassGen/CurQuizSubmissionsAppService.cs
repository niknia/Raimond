
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurQuizSubmissionsAppService : AbstractAppService,ICurQuizSubmissionsAppService
    {
          private readonly IEfRepository<CurQuizSubmissions> _curquizsubmissionsRepository;
          private readonly CacheService _cacheService;
          
          public CurQuizSubmissionsAppService(IEfRepository<CurQuizSubmissions> curquizsubmissionsRepository, CacheService cacheService)
            {
             _curquizsubmissionsRepository = curquizsubmissionsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurQuizSubmissionsCreationDto input)
            {
                input.TrimStringFields();
                var curquizsubmissions = Mapper.Map<CurQuizSubmissions>(input);
                curquizsubmissions.Id = IdGenerater.GetNextId();
                await _curquizsubmissionsRepository.InsertAsync(curquizsubmissions);
        
                return new IdDto(curquizsubmissions.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurQuizSubmissionsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurQuizSubmissions>(
                                   ,
               
        x=>x.QuizId
                    ,
               
        x=>x.StudentId
                    ,
               
        x=>x.SubmittedAt
                    ,
               
        x=>x.TotalScore
                     );
                  
                  var curquizsubmissions = Mapper.Map<CurQuizSubmissions>(input);
                  curquizsubmissions.Id = id;
                  await _curquizsubmissionsRepository.UpdateAsync(curquizsubmissions,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curquizsubmissionsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurQuizSubmissionsDto>> GetPagedAsync(CurQuizSubmissionsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurQuizSubmissions>();



        var total = await _curquizsubmissionsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurQuizSubmissionsDto>(search);

        var entities = await _curquizsubmissionsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curquizsubmissionsDtos = Mapper.Map<List<CurQuizSubmissionsDto>>(entities);

        return new PageModelDto<CurQuizSubmissionsDto>(search, curquizsubmissionsDtos, total);
      }
       public async Task<CurQuizSubmissionsDto> GetAsync(long id)
        {
        var curquizsubmissionsEntity = await _curquizsubmissionsRepository.FindAsync(id);
        if (curquizsubmissionsEntity is null)
            return default;

        var curquizsubmissionsDto = Mapper.Map<CurQuizSubmissionsDto>(curquizsubmissionsEntity);
        return curquizsubmissionsDto;
        }
    }

