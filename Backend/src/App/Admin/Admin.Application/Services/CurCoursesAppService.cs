
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurCoursesAppService : AbstractAppService,ICurCoursesAppService
    {
          private readonly IEfRepository<CurCourses> _curcoursesRepository;
          private readonly CacheService _cacheService;
          
          public CurCoursesAppService(IEfRepository<CurCourses> curcoursesRepository, CacheService cacheService)
            {
             _curcoursesRepository = curcoursesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurCoursesCreationDto input)
            {
                input.TrimStringFields();
                var curcourses = Mapper.Map<CurCourses>(input);
                curcourses.Id = IdGenerater.GetNextId();
                await _curcoursesRepository.InsertAsync(curcourses);
        
                return new IdDto(curcourses.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurCoursesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurCourses>(
               
        x=>x.Code,
   
        x=>x.CourseTypeId
                    ,
               
        x=>x.CreatedAt
                    ,
               
        x=>x.CreatedBy
                    ,
               
        x=>x.Description
                    ,
               
        x=>x.PracticalHours
                    ,
               
        x=>x.Proposal
                    ,
               
        x=>x.QualificationId
                    ,
               
        x=>x.SpecializationId
                    ,
               
        x=>x.TeachingMethodId
                    ,
               
        x=>x.TheoreticalHours
                    ,
               
        x=>x.Title
                     );
                  
                  var curcourses = Mapper.Map<CurCourses>(input);
                  curcourses.Id = id;
                  await _curcoursesRepository.UpdateAsync(curcourses,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curcoursesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurCoursesDto>> GetPagedAsync(CurCoursesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurCourses>();



        var total = await _curcoursesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurCoursesDto>(search);

        var entities = await _curcoursesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curcoursesDtos = Mapper.Map<List<CurCoursesDto>>(entities);

        return new PageModelDto<CurCoursesDto>(search, curcoursesDtos, total);
      }
       public async Task<CurCoursesDto> GetAsync(long id)
        {
        var curcoursesEntity = await _curcoursesRepository.FindAsync(id);
        if (curcoursesEntity is null)
            return default;

        var curcoursesDto = Mapper.Map<CurCoursesDto>(curcoursesEntity);
        return curcoursesDto;
        }
    }

