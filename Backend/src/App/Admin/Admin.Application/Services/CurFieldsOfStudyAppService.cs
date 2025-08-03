
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurFieldsOfStudyAppService : AbstractAppService,ICurFieldsOfStudyAppService
    {
          private readonly IEfRepository<CurFieldsOfStudy> _curfieldsofstudyRepository;
          private readonly CacheService _cacheService;
          
          public CurFieldsOfStudyAppService(IEfRepository<CurFieldsOfStudy> curfieldsofstudyRepository, CacheService cacheService)
            {
             _curfieldsofstudyRepository = curfieldsofstudyRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurFieldsOfStudyCreationDto input)
            {
                input.TrimStringFields();
                var curfieldsofstudy = Mapper.Map<CurFieldsOfStudy>(input);
                curfieldsofstudy.Id = IdGenerater.GetNextId();
                await _curfieldsofstudyRepository.InsertAsync(curfieldsofstudy);
        
                return new IdDto(curfieldsofstudy.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurFieldsOfStudyUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurFieldsOfStudy>(
                                   
               
        x=>x.Name
                     );
                  
                  var curfieldsofstudy = Mapper.Map<CurFieldsOfStudy>(input);
                  curfieldsofstudy.Id = id;
                  await _curfieldsofstudyRepository.UpdateAsync(curfieldsofstudy,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curfieldsofstudyRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurFieldsOfStudyDto>> GetPagedAsync(CurFieldsOfStudySearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurFieldsOfStudy>();



        var total = await _curfieldsofstudyRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurFieldsOfStudyDto>(search);

        var entities = await _curfieldsofstudyRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curfieldsofstudyDtos = Mapper.Map<List<CurFieldsOfStudyDto>>(entities);

        return new PageModelDto<CurFieldsOfStudyDto>(search, curfieldsofstudyDtos, total);
      }
       public async Task<CurFieldsOfStudyDto> GetAsync(long id)
        {
        var curfieldsofstudyEntity = await _curfieldsofstudyRepository.FindAsync(id);
        if (curfieldsofstudyEntity is null)
            return default;

        var curfieldsofstudyDto = Mapper.Map<CurFieldsOfStudyDto>(curfieldsofstudyEntity);
        return curfieldsofstudyDto;
        }
    }

