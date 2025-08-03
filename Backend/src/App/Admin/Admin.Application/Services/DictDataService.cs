namespace Dkd.App.Admin.Application.Services;

public class DictDataService(IEfRepository<SysDictionaryData> dictDataRepo) : AbstractAppService, IDictDataService
{
    public async Task<ServiceResult<IdDto>> CreateAsync(DictDataCreationDto input)
    {
        input.TrimStringFields();
        var lableExists = await dictDataRepo.AnyAsync(x => x.Dictcode == input.DictCode && x.Label == input.Label);
        if (lableExists)
        {
            return Problem(HttpStatusCode.BadRequest, "Dictionary data label already exists");
        }

        var valueExists = await dictDataRepo.AnyAsync(x => x.Dictcode == input.DictCode && x.Value == input.Value);
        if (valueExists)
        {
            return Problem(HttpStatusCode.BadRequest, "Dictionary data value already exists");
        }

        var entity = Mapper.Map<SysDictionaryData>(input, IdGenerater.GetNextId());

        await dictDataRepo.InsertAsync(entity);
        return new IdDto(entity.Id);
    }

    public async Task<ServiceResult> UpdateAsync(long id, DictDataUpdationDto input)
    {
        var entity = await dictDataRepo.FetchAsync(x => x.Id == id, noTracking: false);
        if (entity is null)
        {
            return Problem(HttpStatusCode.NotFound, "Dictionary data does not exist");
        }

        var lableExists = await dictDataRepo.AnyAsync(x => x.Dictcode == input.DictCode && x.Label == input.Label && x.Id != id);
        if (lableExists)
        {
            return Problem(HttpStatusCode.BadRequest, "Dictionary data label already exists");
        }

        var valueExists = await dictDataRepo.AnyAsync(x => x.Dictcode == input.DictCode && x.Value == input.Value && x.Id != id);
        if (valueExists)
        {
            return Problem(HttpStatusCode.BadRequest, "Dictionary data value already exists");
        }

        var newEntity = Mapper.Map(input, entity);
        await dictDataRepo.UpdateAsync(newEntity);

        return ServiceResult();
    }

    public async Task<ServiceResult> DeleteAsync(long[] ids)
    {
        await dictDataRepo.ExecuteDeleteAsync(x => ids.Contains(x.Id));
        return ServiceResult();
    }

    public async Task<DictDataDto?> GetAsync(long id)
    {
        var entity = await dictDataRepo.FetchAsync(x => x.Id == id);
        if (entity is null)
        {
            return null;
        }

        var dictDataDto = Mapper.Map<DictDataDto>(entity);
        return dictDataDto;
    }

    public async Task<PageModelDto<DictDataDto>> GetPagedAsync(DictDataSearchPagedDto input)
    {
        input.TrimStringFields();
        var whereExpr = ExpressionCreator
            .New<SysDictionaryData>()
            .AndIf(input.DictCode.IsNotNullOrWhiteSpace(), x => x.Dictcode == input.DictCode)
            .AndIf(input.Keywords.IsNotNullOrWhiteSpace(), x => x.Label == input.Keywords || x.Value == input.Keywords);

        var total = await dictDataRepo.CountAsync(whereExpr);
        if (total == 0)
        {
            return new PageModelDto<DictDataDto>(input);
        }

        var entities = await dictDataRepo
                                        .Where(whereExpr)
                                        .OrderBy(x => x.Ordinal)
                                        .Skip(input.SkipRows())
                                        .Take(input.PageSize)
                                        .ToListAsync();
        var dictDataDtos = Mapper.Map<List<DictDataDto>>(entities);

        return new PageModelDto<DictDataDto>(input, dictDataDtos, total);
    }
}
