
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurCourseStandardsAppService : AbstractAppService,ICurCourseStandardsAppService
    {
          private readonly IEfRepository<CurCourseStandards> _curcoursestandardsRepository;
          private readonly CacheService _cacheService;
          
          public CurCourseStandardsAppService(IEfRepository<CurCourseStandards> curcoursestandardsRepository, CacheService cacheService)
            {
             _curcoursestandardsRepository = curcoursestandardsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurCourseStandardsCreationDto input)
            {
                input.TrimStringFields();
                var curcoursestandards = Mapper.Map<CurCourseStandards>(input);
                curcoursestandards.Id = IdGenerater.GetNextId();
                await _curcoursestandardsRepository.InsertAsync(curcoursestandards);
        
                return new IdDto(curcoursestandards.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurCourseStandardsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurCourseStandards>(
                                   ,
               
        x=>x.CourseId
                    ,
               
        x=>x.StandardDescription
                     );
                  
                  var curcoursestandards = Mapper.Map<CurCourseStandards>(input);
                  curcoursestandards.Id = id;
                  await _curcoursestandardsRepository.UpdateAsync(curcoursestandards,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curcoursestandardsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurCourseStandardsDto>> GetPagedAsync(CurCourseStandardsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurCourseStandards>();



        var total = await _curcoursestandardsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurCourseStandardsDto>(search);

        var entities = await _curcoursestandardsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curcoursestandardsDtos = Mapper.Map<List<CurCourseStandardsDto>>(entities);

        return new PageModelDto<CurCourseStandardsDto>(search, curcoursestandardsDtos, total);
      }
       public async Task<CurCourseStandardsDto> GetAsync(long id)
        {
        var curcoursestandardsEntity = await _curcoursestandardsRepository.FindAsync(id);
        if (curcoursestandardsEntity is null)
            return default;

        var curcoursestandardsDto = Mapper.Map<CurCourseStandardsDto>(curcoursestandardsEntity);
        return curcoursestandardsDto;
        }
    }

