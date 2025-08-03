
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurQuestionsAppService : AbstractAppService,ICurQuestionsAppService
    {
          private readonly IEfRepository<CurQuestions> _curquestionsRepository;
          private readonly CacheService _cacheService;
          
          public CurQuestionsAppService(IEfRepository<CurQuestions> curquestionsRepository, CacheService cacheService)
            {
             _curquestionsRepository = curquestionsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurQuestionsCreationDto input)
            {
                input.TrimStringFields();
                var curquestions = Mapper.Map<CurQuestions>(input);
                curquestions.Id = IdGenerater.GetNextId();
                await _curquestionsRepository.InsertAsync(curquestions);
        
                return new IdDto(curquestions.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurQuestionsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurQuestions>(
                                   ,
               
        x=>x.QuizId
                    ,
               
        x=>x.Score
                    ,
               
        x=>x.Text
                    ,
               
        x=>x.Type
                     );
                  
                  var curquestions = Mapper.Map<CurQuestions>(input);
                  curquestions.Id = id;
                  await _curquestionsRepository.UpdateAsync(curquestions,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curquestionsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurQuestionsDto>> GetPagedAsync(CurQuestionsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurQuestions>();



        var total = await _curquestionsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurQuestionsDto>(search);

        var entities = await _curquestionsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curquestionsDtos = Mapper.Map<List<CurQuestionsDto>>(entities);

        return new PageModelDto<CurQuestionsDto>(search, curquestionsDtos, total);
      }
       public async Task<CurQuestionsDto> GetAsync(long id)
        {
        var curquestionsEntity = await _curquestionsRepository.FindAsync(id);
        if (curquestionsEntity is null)
            return default;

        var curquestionsDto = Mapper.Map<CurQuestionsDto>(curquestionsEntity);
        return curquestionsDto;
        }
    }

