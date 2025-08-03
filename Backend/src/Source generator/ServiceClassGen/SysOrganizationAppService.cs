
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysOrganizationAppService : AbstractAppService,ISysOrganizationAppService
    {
          private readonly IEfRepository<SysOrganization> _sysorganizationRepository;
          private readonly CacheService _cacheService;
          
          public SysOrganizationAppService(IEfRepository<SysOrganization> sysorganizationRepository, CacheService cacheService)
            {
             _sysorganizationRepository = sysorganizationRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysOrganizationCreationDto input)
            {
                input.TrimStringFields();
                var sysorganization = Mapper.Map<SysOrganization>(input);
                sysorganization.Id = IdGenerater.GetNextId();
                await _sysorganizationRepository.InsertAsync(sysorganization);
        
                return new IdDto(sysorganization.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysOrganizationUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysOrganization>(
                                   ,
               
        x=>x.Code
                    ,
               
        x=>x.Name
                    ,
               
        x=>x.Ordinal
                    ,
               
        x=>x.Parentid
                    ,
               
        x=>x.Parentids
                    ,
               
        x=>x.Status
                     );
                  
                  var sysorganization = Mapper.Map<SysOrganization>(input);
                  sysorganization.Id = id;
                  await _sysorganizationRepository.UpdateAsync(sysorganization,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysorganizationRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysOrganizationDto>> GetPagedAsync(SysOrganizationSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysOrganization>();



        var total = await _sysorganizationRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysOrganizationDto>(search);

        var entities = await _sysorganizationRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysorganizationDtos = Mapper.Map<List<SysOrganizationDto>>(entities);

        return new PageModelDto<SysOrganizationDto>(search, sysorganizationDtos, total);
      }
       public async Task<SysOrganizationDto> GetAsync(long id)
        {
        var sysorganizationEntity = await _sysorganizationRepository.FindAsync(id);
        if (sysorganizationEntity is null)
            return default;

        var sysorganizationDto = Mapper.Map<SysOrganizationDto>(sysorganizationEntity);
        return sysorganizationDto;
        }
    }

