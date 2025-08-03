
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurEnrollmentsAppService : AbstractAppService,ICurEnrollmentsAppService
    {
          private readonly IEfRepository<CurEnrollments> _curenrollmentsRepository;
          private readonly CacheService _cacheService;
          
          public CurEnrollmentsAppService(IEfRepository<CurEnrollments> curenrollmentsRepository, CacheService cacheService)
            {
             _curenrollmentsRepository = curenrollmentsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurEnrollmentsCreationDto input)
            {
                input.TrimStringFields();
                var curenrollments = Mapper.Map<CurEnrollments>(input);
                curenrollments.Id = IdGenerater.GetNextId();
                await _curenrollmentsRepository.InsertAsync(curenrollments);
        
                return new IdDto(curenrollments.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurEnrollmentsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurEnrollments>(
                                   ,
               
        x=>x.ClassId
                    ,
               
        x=>x.EnrolledAt
                    ,
               
        x=>x.Status
                    ,
               
        x=>x.StudentId
                     );
                  
                  var curenrollments = Mapper.Map<CurEnrollments>(input);
                  curenrollments.Id = id;
                  await _curenrollmentsRepository.UpdateAsync(curenrollments,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curenrollmentsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurEnrollmentsDto>> GetPagedAsync(CurEnrollmentsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurEnrollments>();



        var total = await _curenrollmentsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurEnrollmentsDto>(search);

        var entities = await _curenrollmentsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curenrollmentsDtos = Mapper.Map<List<CurEnrollmentsDto>>(entities);

        return new PageModelDto<CurEnrollmentsDto>(search, curenrollmentsDtos, total);
      }
       public async Task<CurEnrollmentsDto> GetAsync(long id)
        {
        var curenrollmentsEntity = await _curenrollmentsRepository.FindAsync(id);
        if (curenrollmentsEntity is null)
            return default;

        var curenrollmentsDto = Mapper.Map<CurEnrollmentsDto>(curenrollmentsEntity);
        return curenrollmentsDto;
        }
    }

