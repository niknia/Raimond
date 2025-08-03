
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysMenuAppService : AbstractAppService,ISysMenuAppService
    {
          private readonly IEfRepository<SysMenu> _sysmenuRepository;
          private readonly CacheService _cacheService;
          
          public SysMenuAppService(IEfRepository<SysMenu> sysmenuRepository, CacheService cacheService)
            {
             _sysmenuRepository = sysmenuRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysMenuCreationDto input)
            {
                input.TrimStringFields();
                var sysmenu = Mapper.Map<SysMenu>(input);
                sysmenu.Id = IdGenerater.GetNextId();
                await _sysmenuRepository.InsertAsync(sysmenu);
        
                return new IdDto(sysmenu.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysMenuUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysMenu>(
                                   ,
               
        x=>x.Alwaysshow
   
        x=>x.Component
                    ,
               
        x=>x.Icon
                    ,
               
        x=>x.Keepalive
                    ,
               
        x=>x.Name
                    ,
               
        x=>x.Ordinal
                    ,
               
        x=>x.Params
                    ,
               
        x=>x.Parentid
                    ,
               
        x=>x.Parentids
                    ,
               
        x=>x.Perm
                    ,
               
        x=>x.Redirect
                    ,
               
        x=>x.Routename
                    ,
               
        x=>x.Routepath
                    ,
               
        x=>x.Type
                    ,
               
        x=>x.Visible
                     );
                  
                  var sysmenu = Mapper.Map<SysMenu>(input);
                  sysmenu.Id = id;
                  await _sysmenuRepository.UpdateAsync(sysmenu,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _sysmenuRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysMenuDto>> GetPagedAsync(SysMenuSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysMenu>();



        var total = await _sysmenuRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysMenuDto>(search);

        var entities = await _sysmenuRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var sysmenuDtos = Mapper.Map<List<SysMenuDto>>(entities);

        return new PageModelDto<SysMenuDto>(search, sysmenuDtos, total);
      }
       public async Task<SysMenuDto> GetAsync(long id)
        {
        var sysmenuEntity = await _sysmenuRepository.FindAsync(id);
        if (sysmenuEntity is null)
            return default;

        var sysmenuDto = Mapper.Map<SysMenuDto>(sysmenuEntity);
        return sysmenuDto;
        }
    }

