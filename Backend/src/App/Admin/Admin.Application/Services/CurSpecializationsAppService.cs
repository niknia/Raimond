
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurSpecializationsAppService : AbstractAppService,ICurSpecializationsAppService
    {
          private readonly IEfRepository<CurSpecializations> _curspecializationsRepository;
          private readonly CacheService _cacheService;
          
          public CurSpecializationsAppService(IEfRepository<CurSpecializations> curspecializationsRepository, CacheService cacheService)
            {
             _curspecializationsRepository = curspecializationsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurSpecializationsCreationDto input)
            {
                input.TrimStringFields();
                var curspecializations = Mapper.Map<CurSpecializations>(input);
                curspecializations.Id = IdGenerater.GetNextId();
                await _curspecializationsRepository.InsertAsync(curspecializations);
        
                return new IdDto(curspecializations.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurSpecializationsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurSpecializations>(
                                   
               
        x=>x.Name
                     );
                  
                  var curspecializations = Mapper.Map<CurSpecializations>(input);
                  curspecializations.Id = id;
                  await _curspecializationsRepository.UpdateAsync(curspecializations,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curspecializationsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurSpecializationsDto>> GetPagedAsync(CurSpecializationsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurSpecializations>();



        var total = await _curspecializationsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurSpecializationsDto>(search);

        var entities = await _curspecializationsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curspecializationsDtos = Mapper.Map<List<CurSpecializationsDto>>(entities);

        return new PageModelDto<CurSpecializationsDto>(search, curspecializationsDtos, total);
      }
       public async Task<CurSpecializationsDto> GetAsync(long id)
        {
        var curspecializationsEntity = await _curspecializationsRepository.FindAsync(id);
        if (curspecializationsEntity is null)
            return default;

        var curspecializationsDto = Mapper.Map<CurSpecializationsDto>(curspecializationsEntity);
        return curspecializationsDto;
        }
    }

