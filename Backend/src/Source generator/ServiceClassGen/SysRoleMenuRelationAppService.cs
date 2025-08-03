
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysRoleMenuRelationAppService : AbstractAppService,ISysRoleMenuRelationAppService
    {
          private readonly IEfRepository<SysRoleMenuRelation> _sysrolemenurelationRepository;
          private readonly CacheService _cacheService;
          
          public SysRoleMenuRelationAppService(IEfRepository<SysRoleMenuRelation> sysrolemenurelationRepository, CacheService cacheService)
            {
             _sysrolemenurelationRepository = sysrolemenurelationRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysRoleMenuRelationCreationDto input)
            {
                input.TrimStringFields();
                var sysrolemenurelation = Mapper.Map<SysRoleMenuRelation>(input);
                sysrolemenurelation.Id = IdGenerater.GetNextId();
                await _sysrolemenurelationRepository.InsertAsync(sysrolemenurelation);
        
                return new IdDto(sysrolemenurelation.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysRoleMenuRelationUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysRoleMenuRelation>(
                  
        x=>x.Menuid
                    ,
               
        x=>x.Roleid
                     );
                  
                  var sysrolemenurelation = Mapper.Map<SysRoleMenuRelation>(input);
                  sysrolemenurelation.Id = id;
                  await _sysrolemenurelationRepository.UpdateAsync(sysrolemenurelation,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysrolemenurelationRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysRoleMenuRelationDto>> GetPagedAsync(SysRoleMenuRelationSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysRoleMenuRelation>();



        var total = await _sysrolemenurelationRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysRoleMenuRelationDto>(search);

        var entities = await _sysrolemenurelationRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysrolemenurelationDtos = Mapper.Map<List<SysRoleMenuRelationDto>>(entities);

        return new PageModelDto<SysRoleMenuRelationDto>(search, sysrolemenurelationDtos, total);
      }
       public async Task<SysRoleMenuRelationDto> GetAsync(long id)
        {
        var sysrolemenurelationEntity = await _sysrolemenurelationRepository.FindAsync(id);
        if (sysrolemenurelationEntity is null)
            return default;

        var sysrolemenurelationDto = Mapper.Map<SysRoleMenuRelationDto>(sysrolemenurelationEntity);
        return sysrolemenurelationDto;
        }
    }

