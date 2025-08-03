
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurUsersAppService : AbstractAppService,ICurUsersAppService
    {
          private readonly IEfRepository<CurUsers> _curusersRepository;
          private readonly CacheService _cacheService;
          
          public CurUsersAppService(IEfRepository<CurUsers> curusersRepository, CacheService cacheService)
            {
             _curusersRepository = curusersRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurUsersCreationDto input)
            {
                input.TrimStringFields();
                var curusers = Mapper.Map<CurUsers>(input);
                curusers.Id = IdGenerater.GetNextId();
                await _curusersRepository.InsertAsync(curusers);
        
                return new IdDto(curusers.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurUsersUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurUsers>(
                  
        x=>x.CreatedAt
                    ,
               
        x=>x.Email
                    ,
               
        x=>x.EmployeeNumber
                    ,
               
        x=>x.FullName
                    ,
               
        x=>x.NationalCode
                    ,
               
        x=>x.OrganizationId
                    ,
               
        x=>x.Phone
                    ,
               
        x=>x.Role
                    ,
               
        x=>x.Status
                    ,
               
        x=>x.UpdatedAt
                     );
                  
                  var curusers = Mapper.Map<CurUsers>(input);
                  curusers.Id = id;
                  await _curusersRepository.UpdateAsync(curusers,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curusersRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurUsersDto>> GetPagedAsync(CurUsersSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurUsers>();



        var total = await _curusersRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurUsersDto>(search);

        var entities = await _curusersRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curusersDtos = Mapper.Map<List<CurUsersDto>>(entities);

        return new PageModelDto<CurUsersDto>(search, curusersDtos, total);
      }
       public async Task<CurUsersDto> GetAsync(long id)
        {
        var curusersEntity = await _curusersRepository.FindAsync(id);
        if (curusersEntity is null)
            return default;

        var curusersDto = Mapper.Map<CurUsersDto>(curusersEntity);
        return curusersDto;
        }
    }

