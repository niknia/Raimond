
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurAnswersAppService : AbstractAppService,ICurAnswersAppService
    {
          private readonly IEfRepository<CurAnswers> _curanswersRepository;
          private readonly CacheService _cacheService;
          
          public CurAnswersAppService(IEfRepository<CurAnswers> curanswersRepository, CacheService cacheService)
            {
             _curanswersRepository = curanswersRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurAnswersCreationDto input)
            {
                input.TrimStringFields();
                var curanswers = Mapper.Map<CurAnswers>(input);
                curanswers.Id = IdGenerater.GetNextId();
                await _curanswersRepository.InsertAsync(curanswers);
        
                return new IdDto(curanswers.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurAnswersUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurAnswers>(
                                   ,
               
        x=>x.IsCorrect
                    ,
               
        x=>x.QuestionId
                    ,
               
        x=>x.Text
                     );
                  
                  var curanswers = Mapper.Map<CurAnswers>(input);
                  curanswers.Id = id;
                  await _curanswersRepository.UpdateAsync(curanswers,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curanswersRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurAnswersDto>> GetPagedAsync(CurAnswersSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurAnswers>();



        var total = await _curanswersRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurAnswersDto>(search);

        var entities = await _curanswersRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curanswersDtos = Mapper.Map<List<CurAnswersDto>>(entities);

        return new PageModelDto<CurAnswersDto>(search, curanswersDtos, total);
      }
       public async Task<CurAnswersDto> GetAsync(long id)
        {
        var curanswersEntity = await _curanswersRepository.FindAsync(id);
        if (curanswersEntity is null)
            return default;

        var curanswersDto = Mapper.Map<CurAnswersDto>(curanswersEntity);
        return curanswersDto;
        }
    }

