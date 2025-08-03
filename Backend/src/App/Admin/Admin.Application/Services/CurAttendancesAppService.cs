
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurAttendancesAppService : AbstractAppService,ICurAttendancesAppService
    {
          private readonly IEfRepository<CurAttendances> _curattendancesRepository;
          private readonly CacheService _cacheService;
          
          public CurAttendancesAppService(IEfRepository<CurAttendances> curattendancesRepository, CacheService cacheService)
            {
             _curattendancesRepository = curattendancesRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurAttendancesCreationDto input)
            {
                input.TrimStringFields();
                var curattendances = Mapper.Map<CurAttendances>(input);
                curattendances.Id = IdGenerater.GetNextId();
                await _curattendancesRepository.InsertAsync(curattendances);
        
                return new IdDto(curattendances.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurAttendancesUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurAttendances>(
                                   
               
        x=>x.ClassId
                    ,
               
        x=>x.CreatedAt
                    ,
               
        x=>x.SessionDate
                    ,
               
        x=>x.Status
                    ,
               
        x=>x.StudentId
                    ,
               
        x=>x.UpdatedAt
                     );
                  
                  var curattendances = Mapper.Map<CurAttendances>(input);
                  curattendances.Id = id;
                  await _curattendancesRepository.UpdateAsync(curattendances,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curattendancesRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurAttendancesDto>> GetPagedAsync(CurAttendancesSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurAttendances>();



        var total = await _curattendancesRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurAttendancesDto>(search);

        var entities = await _curattendancesRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curattendancesDtos = Mapper.Map<List<CurAttendancesDto>>(entities);

        return new PageModelDto<CurAttendancesDto>(search, curattendancesDtos, total);
      }
       public async Task<CurAttendancesDto> GetAsync(long id)
        {
        var curattendancesEntity = await _curattendancesRepository.FindAsync(id);
        if (curattendancesEntity is null)
            return default;

        var curattendancesDto = Mapper.Map<CurAttendancesDto>(curattendancesEntity);
        return curattendancesDto;
        }
    }

