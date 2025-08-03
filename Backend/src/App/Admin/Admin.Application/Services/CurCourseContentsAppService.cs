
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurCourseContentsAppService : AbstractAppService,ICurCourseContentsAppService
    {
          private readonly IEfRepository<CurCourseContents> _curcoursecontentsRepository;
          private readonly CacheService _cacheService;
          
          public CurCourseContentsAppService(IEfRepository<CurCourseContents> curcoursecontentsRepository, CacheService cacheService)
            {
             _curcoursecontentsRepository = curcoursecontentsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurCourseContentsCreationDto input)
            {
                input.TrimStringFields();
                var curcoursecontents = Mapper.Map<CurCourseContents>(input);
                curcoursecontents.Id = IdGenerater.GetNextId();
                await _curcoursecontentsRepository.InsertAsync(curcoursecontents);
        
                return new IdDto(curcoursecontents.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurCourseContentsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurCourseContents>(
                                   
               
        x=>x.ContentDescription,
   
        x=>x.CourseId
                     );
                  
                  var curcoursecontents = Mapper.Map<CurCourseContents>(input);
                  curcoursecontents.Id = id;
                  await _curcoursecontentsRepository.UpdateAsync(curcoursecontents,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curcoursecontentsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurCourseContentsDto>> GetPagedAsync(CurCourseContentsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurCourseContents>();



        var total = await _curcoursecontentsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurCourseContentsDto>(search);

        var entities = await _curcoursecontentsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curcoursecontentsDtos = Mapper.Map<List<CurCourseContentsDto>>(entities);

        return new PageModelDto<CurCourseContentsDto>(search, curcoursecontentsDtos, total);
      }
       public async Task<CurCourseContentsDto> GetAsync(long id)
        {
        var curcoursecontentsEntity = await _curcoursecontentsRepository.FindAsync(id);
        if (curcoursecontentsEntity is null)
            return default;

        var curcoursecontentsDto = Mapper.Map<CurCourseContentsDto>(curcoursecontentsEntity);
        return curcoursecontentsDto;
        }
    }

