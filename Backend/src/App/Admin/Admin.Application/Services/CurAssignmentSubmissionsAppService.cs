
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurAssignmentSubmissionsAppService : AbstractAppService,ICurAssignmentSubmissionsAppService
    {
          private readonly IEfRepository<CurAssignmentSubmissions> _curassignmentsubmissionsRepository;
          private readonly CacheService _cacheService;
          
          public CurAssignmentSubmissionsAppService(IEfRepository<CurAssignmentSubmissions> curassignmentsubmissionsRepository, CacheService cacheService)
            {
             _curassignmentsubmissionsRepository = curassignmentsubmissionsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurAssignmentSubmissionsCreationDto input)
            {
                input.TrimStringFields();
                var curassignmentsubmissions = Mapper.Map<CurAssignmentSubmissions>(input);
                curassignmentsubmissions.Id = IdGenerater.GetNextId();
                await _curassignmentsubmissionsRepository.InsertAsync(curassignmentsubmissions);
        
                return new IdDto(curassignmentsubmissions.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurAssignmentSubmissionsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurAssignmentSubmissions>(
                                   
               
        x=>x.AssignmentId,
   
        x=>x.Comment
                    ,
               
        x=>x.FileUrl
                    ,
               
        x=>x.ReviewedAt
                    ,
               
        x=>x.ReviewedBy
                    ,
               
        x=>x.Score
                    ,
               
        x=>x.StudentId
                    ,
               
        x=>x.SubmittedAt
                     );
                  
                  var curassignmentsubmissions = Mapper.Map<CurAssignmentSubmissions>(input);
                  curassignmentsubmissions.Id = id;
                  await _curassignmentsubmissionsRepository.UpdateAsync(curassignmentsubmissions,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curassignmentsubmissionsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurAssignmentSubmissionsDto>> GetPagedAsync(CurAssignmentSubmissionsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurAssignmentSubmissions>();



        var total = await _curassignmentsubmissionsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurAssignmentSubmissionsDto>(search);

        var entities = await _curassignmentsubmissionsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curassignmentsubmissionsDtos = Mapper.Map<List<CurAssignmentSubmissionsDto>>(entities);

        return new PageModelDto<CurAssignmentSubmissionsDto>(search, curassignmentsubmissionsDtos, total);
      }
       public async Task<CurAssignmentSubmissionsDto> GetAsync(long id)
        {
        var curassignmentsubmissionsEntity = await _curassignmentsubmissionsRepository.FindAsync(id);
        if (curassignmentsubmissionsEntity is null)
            return default;

        var curassignmentsubmissionsDto = Mapper.Map<CurAssignmentSubmissionsDto>(curassignmentsubmissionsEntity);
        return curassignmentsubmissionsDto;
        }
    }

