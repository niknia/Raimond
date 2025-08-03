
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurCourseTypesAppService : AbstractAppService,ICurCourseTypesAppService
    {
          private readonly IEfRepository<CurCourseTypes> _curcoursetypesRepository;
          private readonly CacheService _cacheService;
          
          public CurCourseTypesAppService(IEfRepository<CurCourseTypes> curcoursetypesRepository, CacheService cacheService)
            {
             _curcoursetypesRepository = curcoursetypesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurCourseTypesCreationDto input)
            {
                input.TrimStringFields();
                var curcoursetypes = Mapper.Map<CurCourseTypes>(input);
                curcoursetypes.Id = IdGenerater.GetNextId();
                await _curcoursetypesRepository.InsertAsync(curcoursetypes);
        
                return new IdDto(curcoursetypes.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurCourseTypesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurCourseTypes>(
                                   ,
               
        x=>x.Name
                     );
                  
                  var curcoursetypes = Mapper.Map<CurCourseTypes>(input);
                  curcoursetypes.Id = id;
                  await _curcoursetypesRepository.UpdateAsync(curcoursetypes,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curcoursetypesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurCourseTypesDto>> GetPagedAsync(CurCourseTypesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurCourseTypes>();



        var total = await _curcoursetypesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurCourseTypesDto>(search);

        var entities = await _curcoursetypesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curcoursetypesDtos = Mapper.Map<List<CurCourseTypesDto>>(entities);

        return new PageModelDto<CurCourseTypesDto>(search, curcoursetypesDtos, total);
      }
       public async Task<CurCourseTypesDto> GetAsync(long id)
        {
        var curcoursetypesEntity = await _curcoursetypesRepository.FindAsync(id);
        if (curcoursetypesEntity is null)
            return default;

        var curcoursetypesDto = Mapper.Map<CurCourseTypesDto>(curcoursetypesEntity);
        return curcoursetypesDto;
        }
    }

