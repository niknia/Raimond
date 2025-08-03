
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurClassesAppService : AbstractAppService,ICurClassesAppService
    {
          private readonly IEfRepository<CurClasses> _curclassesRepository;
          private readonly CacheService _cacheService;
          
          public CurClassesAppService(IEfRepository<CurClasses> curclassesRepository, CacheService cacheService)
            {
             _curclassesRepository = curclassesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurClassesCreationDto input)
            {
                input.TrimStringFields();
                var curclasses = Mapper.Map<CurClasses>(input);
                curclasses.Id = IdGenerater.GetNextId();
                await _curclassesRepository.InsertAsync(curclasses);
        
                return new IdDto(curclasses.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurClassesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurClasses>(
                                   
               
        x=>x.CourseId
                    ,
               
        x=>x.EndDate
                    ,
               
        x=>x.MaxStudents
                    ,
               
        x=>x.StartDate
                    ,
               
        x=>x.Status
                    ,
               
        x=>x.TeacherId
                     );
                  
                  var curclasses = Mapper.Map<CurClasses>(input);
                  curclasses.Id = id;
                  await _curclassesRepository.UpdateAsync(curclasses,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curclassesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurClassesDto>> GetPagedAsync(CurClassesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurClasses>();



        var total = await _curclassesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurClassesDto>(search);

        var entities = await _curclassesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curclassesDtos = Mapper.Map<List<CurClassesDto>>(entities);

        return new PageModelDto<CurClassesDto>(search, curclassesDtos, total);
      }
       public async Task<CurClassesDto> GetAsync(long id)
        {
        var curclassesEntity = await _curclassesRepository.FindAsync(id);
        if (curclassesEntity is null)
            return default;

        var curclassesDto = Mapper.Map<CurClassesDto>(curclassesEntity);
        return curclassesDto;
        }
    }

