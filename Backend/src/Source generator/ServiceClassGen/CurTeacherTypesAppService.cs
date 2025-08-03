
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurTeacherTypesAppService : AbstractAppService,ICurTeacherTypesAppService
    {
          private readonly IEfRepository<CurTeacherTypes> _curteachertypesRepository;
          private readonly CacheService _cacheService;
          
          public CurTeacherTypesAppService(IEfRepository<CurTeacherTypes> curteachertypesRepository, CacheService cacheService)
            {
             _curteachertypesRepository = curteachertypesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurTeacherTypesCreationDto input)
            {
                input.TrimStringFields();
                var curteachertypes = Mapper.Map<CurTeacherTypes>(input);
                curteachertypes.Id = IdGenerater.GetNextId();
                await _curteachertypesRepository.InsertAsync(curteachertypes);
        
                return new IdDto(curteachertypes.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurTeacherTypesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurTeacherTypes>(
                                   ,
               
        x=>x.Name
                     );
                  
                  var curteachertypes = Mapper.Map<CurTeacherTypes>(input);
                  curteachertypes.Id = id;
                  await _curteachertypesRepository.UpdateAsync(curteachertypes,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curteachertypesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurTeacherTypesDto>> GetPagedAsync(CurTeacherTypesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurTeacherTypes>();



        var total = await _curteachertypesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurTeacherTypesDto>(search);

        var entities = await _curteachertypesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curteachertypesDtos = Mapper.Map<List<CurTeacherTypesDto>>(entities);

        return new PageModelDto<CurTeacherTypesDto>(search, curteachertypesDtos, total);
      }
       public async Task<CurTeacherTypesDto> GetAsync(long id)
        {
        var curteachertypesEntity = await _curteachertypesRepository.FindAsync(id);
        if (curteachertypesEntity is null)
            return default;

        var curteachertypesDto = Mapper.Map<CurTeacherTypesDto>(curteachertypesEntity);
        return curteachertypesDto;
        }
    }

