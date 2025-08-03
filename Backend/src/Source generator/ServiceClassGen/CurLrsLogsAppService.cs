
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurLrsLogsAppService : AbstractAppService,ICurLrsLogsAppService
    {
          private readonly IEfRepository<CurLrsLogs> _curlrslogsRepository;
          private readonly CacheService _cacheService;
          
          public CurLrsLogsAppService(IEfRepository<CurLrsLogs> curlrslogsRepository, CacheService cacheService)
            {
             _curlrslogsRepository = curlrslogsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurLrsLogsCreationDto input)
            {
                input.TrimStringFields();
                var curlrslogs = Mapper.Map<CurLrsLogs>(input);
                curlrslogs.Id = IdGenerater.GetNextId();
                await _curlrslogsRepository.InsertAsync(curlrslogs);
        
                return new IdDto(curlrslogs.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurLrsLogsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurLrsLogs>(
                                   ,
               
        x=>x.Context
   
        x=>x.CourseId
                    ,
               
        x=>x.Object
                    ,
               
        x=>x.Result
                    ,
               
        x=>x.StatementId
                    ,
               
        x=>x.Timestamp
                    ,
               
        x=>x.UserId
                    ,
               
        x=>x.Verb
                     );
                  
                  var curlrslogs = Mapper.Map<CurLrsLogs>(input);
                  curlrslogs.Id = id;
                  await _curlrslogsRepository.UpdateAsync(curlrslogs,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curlrslogsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurLrsLogsDto>> GetPagedAsync(CurLrsLogsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurLrsLogs>();



        var total = await _curlrslogsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurLrsLogsDto>(search);

        var entities = await _curlrslogsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curlrslogsDtos = Mapper.Map<List<CurLrsLogsDto>>(entities);

        return new PageModelDto<CurLrsLogsDto>(search, curlrslogsDtos, total);
      }
       public async Task<CurLrsLogsDto> GetAsync(long id)
        {
        var curlrslogsEntity = await _curlrslogsRepository.FindAsync(id);
        if (curlrslogsEntity is null)
            return default;

        var curlrslogsDto = Mapper.Map<CurLrsLogsDto>(curlrslogsEntity);
        return curlrslogsDto;
        }
    }

