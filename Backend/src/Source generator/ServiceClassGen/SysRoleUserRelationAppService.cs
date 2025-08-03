
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysRoleUserRelationAppService : AbstractAppService,ISysRoleUserRelationAppService
    {
          private readonly IEfRepository<SysRoleUserRelation> _sysroleuserrelationRepository;
          private readonly CacheService _cacheService;
          
          public SysRoleUserRelationAppService(IEfRepository<SysRoleUserRelation> sysroleuserrelationRepository, CacheService cacheService)
            {
             _sysroleuserrelationRepository = sysroleuserrelationRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysRoleUserRelationCreationDto input)
            {
                input.TrimStringFields();
                var sysroleuserrelation = Mapper.Map<SysRoleUserRelation>(input);
                sysroleuserrelation.Id = IdGenerater.GetNextId();
                await _sysroleuserrelationRepository.InsertAsync(sysroleuserrelation);
        
                return new IdDto(sysroleuserrelation.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysRoleUserRelationUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysRoleUserRelation>(
                  
        x=>x.Roleid
                    ,
               
        x=>x.Userid
                     );
                  
                  var sysroleuserrelation = Mapper.Map<SysRoleUserRelation>(input);
                  sysroleuserrelation.Id = id;
                  await _sysroleuserrelationRepository.UpdateAsync(sysroleuserrelation,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysroleuserrelationRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysRoleUserRelationDto>> GetPagedAsync(SysRoleUserRelationSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysRoleUserRelation>();



        var total = await _sysroleuserrelationRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysRoleUserRelationDto>(search);

        var entities = await _sysroleuserrelationRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysroleuserrelationDtos = Mapper.Map<List<SysRoleUserRelationDto>>(entities);

        return new PageModelDto<SysRoleUserRelationDto>(search, sysroleuserrelationDtos, total);
      }
       public async Task<SysRoleUserRelationDto> GetAsync(long id)
        {
        var sysroleuserrelationEntity = await _sysroleuserrelationRepository.FindAsync(id);
        if (sysroleuserrelationEntity is null)
            return default;

        var sysroleuserrelationDto = Mapper.Map<SysRoleUserRelationDto>(sysroleuserrelationEntity);
        return sysroleuserrelationDto;
        }
    }

