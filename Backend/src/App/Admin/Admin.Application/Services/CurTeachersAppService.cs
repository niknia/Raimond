
namespace Dkd.App.Admin.Application.Contracts.Services;

    public class CurTeachersAppService : AbstractAppService,ICurTeachersAppService
    {
          private readonly IEfRepository<CurTeachers> _curteachersRepository;
          private readonly CacheService _cacheService;
          
          public CurTeachersAppService(IEfRepository<CurTeachers> curteachersRepository, CacheService cacheService)
            {
             _curteachersRepository = curteachersRepository;
             _cacheService = cacheService;
            }
          public async Task<ServiceResult<IDto>> CreateAsync(CurTeachersCreationDto input)
            {
                input.TrimStringFields();
                var curteachers = Mapper.Map<CurTeachers>(input);
                curteachers.Id = IdGenerater.GetNextId();
                await _curteachersRepository.InsertAsync(curteachers);
        
                return new IdDto(curteachers.Id);
            }
          public async Task<ServiceResult> UpdateAsync(long id, CurTeachersUpdationDto input)
              {
                 input.TrimStringFields();
                 var updatingProps = UpdatingProps<CurTeachers>(
                                   
               
        x=>x.Address,
   
        x=>x.BirthDate
                    ,
               
        x=>x.BirthPlace
                    ,
               
        x=>x.CreatedAt
                    ,
               
        x=>x.DegreeId
                    ,
               
        x=>x.DenominationId
                    ,
               
        x=>x.FatherName
                    ,
               
        x=>x.FieldOfStudyId
                    ,
               
        x=>x.FirstName
                    ,
               
        x=>x.Gender
                    ,
               
        x=>x.IdIssuePlace
                    ,
               
        x=>x.IdNumber
                    ,
               
        x=>x.IsAcademicMember
                    ,
               
        x=>x.LastName
                    ,
               
        x=>x.MaritalStatusId
                    ,
               
        x=>x.MilitaryStatus
                    ,
               
        x=>x.NationalCode
                    ,
               
        x=>x.PhoneLandline
                    ,
               
        x=>x.PhoneMobile
                    ,
               
        x=>x.PostalCode
                    ,
               
        x=>x.ReligionId
                    ,
               
        x=>x.TeacherTypeId
                    ,
               
        x=>x.UpdatedAt
                     );
                  
                  var curteachers = Mapper.Map<CurTeachers>(input);
                  curteachers.Id = id;
                  await _curteachersRepository.UpdateAsync(curteachers,updatingProps);
          
                  return ServiceResult();
              }
          public async Task<ServiceResult> DeleteAsync(long id)
          {
              await _curteachersRepository.DeleteAsync(id);
              return ServiceResult();
          }
         public async Task<PageModelDto<CurTeachersDto>> GetPagedAsync(CurTeachersSearchPagedDto search)
         {
          search.TrimStringFields();
          var whereExpression = ExpressionCreator
            .New<CurTeachers>();



        var total = await _curteachersRepository.CountAsync(whereExpression);
        if (total == 0)
            return new PageModelDto<CurTeachersDto>(search);

        var entities = await _curteachersRepository
                                        .Where(whereExpression)
                                        .OrderByDescending(x => x.ModifyTime)
                                        .Skip(search.SkipRows())
                                        .Take(search.PageSize)
                                        .ToListAsync();
        var curteachersDtos = Mapper.Map<List<CurTeachersDto>>(entities);

        return new PageModelDto<CurTeachersDto>(search, curteachersDtos, total);
      }
       public async Task<CurTeachersDto> GetAsync(long id)
        {
        var curteachersEntity = await _curteachersRepository.FindAsync(id);
        if (curteachersEntity is null)
            return default;

        var curteachersDto = Mapper.Map<CurTeachersDto>(curteachersEntity);
        return curteachersDto;
        }
    }

