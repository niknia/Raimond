
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurAssignmentsAppService : AbstractAppService,ICurAssignmentsAppService
    {
          private readonly IEfRepository<CurAssignments> _curassignmentsRepository;
          private readonly CacheService _cacheService;
          
          public CurAssignmentsAppService(IEfRepository<CurAssignments> curassignmentsRepository, CacheService cacheService)
            {
             _curassignmentsRepository = curassignmentsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurAssignmentsCreationDto input)
            {
                input.TrimStringFields();
                var curassignments = Mapper.Map<CurAssignments>(input);
                curassignments.Id = IdGenerater.GetNextId();
                await _curassignmentsRepository.InsertAsync(curassignments);
        
                return new IdDto(curassignments.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurAssignmentsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurAssignments>(
                                   
               
        x=>x.ClassId
                    ,
               
        x=>x.CreatedAt
                    ,
               
        x=>x.CreatedBy
                    ,
               
        x=>x.Description
                    ,
               
        x=>x.DueDate
                    ,
               
        x=>x.MaxScore
                    ,
               
        x=>x.Title
                     );
                  
                  var curassignments = Mapper.Map<CurAssignments>(input);
                  curassignments.Id = id;
                  await _curassignmentsRepository.UpdateAsync(curassignments,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curassignmentsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurAssignmentsDto>> GetPagedAsync(CurAssignmentsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurAssignments>();



        var total = await _curassignmentsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurAssignmentsDto>(search);

        var entities = await _curassignmentsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curassignmentsDtos = Mapper.Map<List<CurAssignmentsDto>>(entities);

        return new PageModelDto<CurAssignmentsDto>(search, curassignmentsDtos, total);
      }
       public async Task<CurAssignmentsDto> GetAsync(long id)
        {
        var curassignmentsEntity = await _curassignmentsRepository.FindAsync(id);
        if (curassignmentsEntity is null)
            return default;

        var curassignmentsDto = Mapper.Map<CurAssignmentsDto>(curassignmentsEntity);
        return curassignmentsDto;
        }
    }

