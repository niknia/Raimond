
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class SysEventtrackerAppService : AbstractAppService,ISysEventtrackerAppService
    {
          private readonly IEfRepository<SysEventtracker> _syseventtrackerRepository;
          private readonly CacheService _cacheService;
          
          public SysEventtrackerAppService(IEfRepository<SysEventtracker> syseventtrackerRepository, CacheService cacheService)
            {
             _syseventtrackerRepository = syseventtrackerRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(SysEventtrackerCreationDto input)
            {
                input.TrimStringFields();
                var syseventtracker = Mapper.Map<SysEventtracker>(input);
                syseventtracker.Id = IdGenerater.GetNextId();
                await _syseventtrackerRepository.InsertAsync(syseventtracker);
        
                return new IdDto(syseventtracker.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, SysEventtrackerUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<SysEventtracker>(
                                   ,
               
        x=>x.Eventid
                    ,
               
        x=>x.Trackername
                     );
                  
                  var syseventtracker = Mapper.Map<SysEventtracker>(input);
                  syseventtracker.Id = id;
                  await _syseventtrackerRepository.UpdateAsync(syseventtracker,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _syseventtrackerRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<SysEventtrackerDto>> GetPagedAsync(SysEventtrackerSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<SysEventtracker>();



        var total = await _syseventtrackerRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<SysEventtrackerDto>(search);

        var entities = await _syseventtrackerRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var syseventtrackerDtos = Mapper.Map<List<SysEventtrackerDto>>(entities);

        return new PageModelDto<SysEventtrackerDto>(search, syseventtrackerDtos, total);
      }
       public async Task<SysEventtrackerDto> GetAsync(long id)
        {
        var syseventtrackerEntity = await _syseventtrackerRepository.FindAsync(id);
        if (syseventtrackerEntity is null)
            return default;

        var syseventtrackerDto = Mapper.Map<SysEventtrackerDto>(syseventtrackerEntity);
        return syseventtrackerDto;
        }
    }

