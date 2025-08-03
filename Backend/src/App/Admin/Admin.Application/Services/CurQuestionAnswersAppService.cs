
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurQuestionAnswersAppService : AbstractAppService,ICurQuestionAnswersAppService
    {
          private readonly IEfRepository<CurQuestionAnswers> _curquestionanswersRepository;
          private readonly CacheService _cacheService;
          
          public CurQuestionAnswersAppService(IEfRepository<CurQuestionAnswers> curquestionanswersRepository, CacheService cacheService)
            {
             _curquestionanswersRepository = curquestionanswersRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurQuestionAnswersCreationDto input)
            {
                input.TrimStringFields();
                var curquestionanswers = Mapper.Map<CurQuestionAnswers>(input);
                curquestionanswers.Id = IdGenerater.GetNextId();
                await _curquestionanswersRepository.InsertAsync(curquestionanswers);
        
                return new IdDto(curquestionanswers.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurQuestionAnswersUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurQuestionAnswers>(
                                   
               
        x=>x.AnswerText
                    ,
               
        x=>x.QuestionId
                    ,
               
        x=>x.Score
                    ,
               
        x=>x.SelectedOptionIds
                    ,
               
        x=>x.SubmissionId
                     );
                  
                  var curquestionanswers = Mapper.Map<CurQuestionAnswers>(input);
                  curquestionanswers.Id = id;
                  await _curquestionanswersRepository.UpdateAsync(curquestionanswers,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curquestionanswersRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurQuestionAnswersDto>> GetPagedAsync(CurQuestionAnswersSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurQuestionAnswers>();



        var total = await _curquestionanswersRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurQuestionAnswersDto>(search);

        var entities = await _curquestionanswersRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curquestionanswersDtos = Mapper.Map<List<CurQuestionAnswersDto>>(entities);

        return new PageModelDto<CurQuestionAnswersDto>(search, curquestionanswersDtos, total);
      }
       public async Task<CurQuestionAnswersDto> GetAsync(long id)
        {
        var curquestionanswersEntity = await _curquestionanswersRepository.FindAsync(id);
        if (curquestionanswersEntity is null)
            return default;

        var curquestionanswersDto = Mapper.Map<CurQuestionAnswersDto>(curquestionanswersEntity);
        return curquestionanswersDto;
        }
    }

