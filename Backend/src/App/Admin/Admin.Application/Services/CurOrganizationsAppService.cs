
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurOrganizationsAppService : AbstractAppService,ICurOrganizationsAppService
    {
          private readonly IEfRepository<CurOrganizations> _curorganizationsRepository;
          private readonly CacheService _cacheService;
          
          public CurOrganizationsAppService(IEfRepository<CurOrganizations> curorganizationsRepository, CacheService cacheService)
            {
             _curorganizationsRepository = curorganizationsRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurOrganizationsCreationDto input)
            {
                input.TrimStringFields();
                var curorganizations = Mapper.Map<CurOrganizations>(input);
                curorganizations.Id = IdGenerater.GetNextId();
                await _curorganizationsRepository.InsertAsync(curorganizations);
        
                return new IdDto(curorganizations.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurOrganizationsUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurOrganizations>(
                                   
               
        x=>x.Code
                    ,
               
        x=>x.CreatedAt
                    ,
               
        x=>x.Level
                    ,
               
        x=>x.Name
                    ,
               
        x=>x.ParentId
                    ,
               
        x=>x.Path
                    ,
               
        x=>x.Type
                    ,
               
        x=>x.UpdatedAt
                     );
                  
                  var curorganizations = Mapper.Map<CurOrganizations>(input);
                  curorganizations.Id = id;
                  await _curorganizationsRepository.UpdateAsync(curorganizations,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curorganizationsRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurOrganizationsDto>> GetPagedAsync(CurOrganizationsSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurOrganizations>();



        var total = await _curorganizationsRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurOrganizationsDto>(search);

        var entities = await _curorganizationsRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curorganizationsDtos = Mapper.Map<List<CurOrganizationsDto>>(entities);

        return new PageModelDto<CurOrganizationsDto>(search, curorganizationsDtos, total);
      }
       public async Task<CurOrganizationsDto> GetAsync(long id)
        {
        var curorganizationsEntity = await _curorganizationsRepository.FindAsync(id);
        if (curorganizationsEntity is null)
            return default;

        var curorganizationsDto = Mapper.Map<CurOrganizationsDto>(curorganizationsEntity);
        return curorganizationsDto;
        }
    }

