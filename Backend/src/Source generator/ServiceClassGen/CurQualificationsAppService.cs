
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurQualificationsAppService : AbstractAppService,ICurQualificationsAppService
    {
          private readonly IEfRepository<CurQualifications> _curqualificationsRepository;
          private readonly CacheService _cacheService;
          
          public CurQualificationsAppService(IEfRepository<CurQualifications> curqualificationsRepository, CacheService cacheService)
            {
             _curqualificationsRepository = curqualificationsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurQualificationsCreationDto input)
            {
                input.TrimStringFields();
                var curqualifications = Mapper.Map<CurQualifications>(input);
                curqualifications.Id = IdGenerater.GetNextId();
                await _curqualificationsRepository.InsertAsync(curqualifications);
        
                return new IdDto(curqualifications.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurQualificationsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurQualifications>(
                                   ,
               
        x=>x.QualificationLevel
                     );
                  
                  var curqualifications = Mapper.Map<CurQualifications>(input);
                  curqualifications.Id = id;
                  await _curqualificationsRepository.UpdateAsync(curqualifications,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curqualificationsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurQualificationsDto>> GetPagedAsync(CurQualificationsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurQualifications>();



        var total = await _curqualificationsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurQualificationsDto>(search);

        var entities = await _curqualificationsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curqualificationsDtos = Mapper.Map<List<CurQualificationsDto>>(entities);

        return new PageModelDto<CurQualificationsDto>(search, curqualificationsDtos, total);
      }
       public async Task<CurQualificationsDto> GetAsync(long id)
        {
        var curqualificationsEntity = await _curqualificationsRepository.FindAsync(id);
        if (curqualificationsEntity is null)
            return default;

        var curqualificationsDto = Mapper.Map<CurQualificationsDto>(curqualificationsEntity);
        return curqualificationsDto;
        }
    }

