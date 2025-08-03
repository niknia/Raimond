namespace Dkd.App.Admin.Application.Services;

public class DictService(IEfRepository<SysDictionary> dictRepo, IEfRepository<SysDictionaryData> dictDataRepo/*, BloomFilterFactory bloomFilterFactory*/, CacheService cacheService)
    : AbstractAppService, IDictService
{
    public async Task<ServiceResult<IdDto>> CreateAsync(DictCreationDto input)
    {
        input.TrimStringFields();

        var codeExists = await dictRepo.AnyAsync(x => x.Code == input.Code);
        if (codeExists)
        {
            return Problem(HttpStatusCode.BadRequest, "Dictionary code already exists");
        }

        var nameExists = await dictRepo.AnyAsync(x => x.Name == input.Name);
        if (nameExists)
        {
            return Problem(HttpStatusCode.BadRequest, "Dictionary name already exists");
        }

        var entity = Mapper.Map<SysDictionary>(input, IdGenerater.GetNextId());

        //var cacheKey = cacheService.ConcatCacheKey(CachingConsts.DictOptionSingleKeyPrefix, id);
        //var cahceBf = bloomFilterFactory.Create(CachingConsts.BloomfilterOfCacheKey);
        //var addedStatus = await cahceBf.AddAsync(cacheKey);
        //if (!addedStatus)
        //    return Problem(HttpStatusCode.BadRequest, "Adding to bloom filter failed!");
        //else
        //    await dictRepo.InsertRangeAsync(dists);

        await dictRepo.InsertAsync(entity);
        return new IdDto(entity.Id);
    }

    public async Task<ServiceResult> UpdateAsync(long id, DictUpdationDto input)
    {
        var entity = await dictRepo.FetchAsync(x => x.Id == id, noTracking: false);
        if (entity is null)
        {
            return Problem(HttpStatusCode.NotFound, "Dictionary does not exist");
        }

        input.TrimStringFields();
        var codeExists = await dictRepo.AnyAsync(x => x.Code == input.Code && x.Id != id);
        if (codeExists)
        {
            return Problem(HttpStatusCode.BadRequest, "Dictionary code already exists");
        }

        var nameExists = await dictRepo.AnyAsync(x => x.Name == input.Name && x.Id != id);
        if (nameExists)
        {
            return Problem(HttpStatusCode.BadRequest, "Dictionary name already exists");
        }

        if (input.Code != entity.Code)
        {
            await dictDataRepo.ExecuteUpdateAsync(x => x.Dictcode == input.Code, setters => setters.SetProperty(x => x.Dictcode, input.Code));
        }

        var newEntity = Mapper.Map(input, entity);
        await dictRepo.UpdateAsync(newEntity);

        return ServiceResult();
    }

    public async Task<ServiceResult> DeleteAsync(long[] ids)
    {
        await dictRepo.ExecuteDeleteAsync(x => ids.Contains(x.Id));

        var dictCodes = await dictRepo.Where(x => ids.Contains(x.Id)).Select(x => x.Code).ToListAsync();
        if (dictCodes.IsNotNullOrEmpty())
        {
            await dictDataRepo.ExecuteDeleteAsync(x => dictCodes.Contains(x.Dictcode));
        }

        return ServiceResult();
    }

    public async Task<DictDto?> GetAsync(long id)
    {
        var entity = await dictRepo.FetchAsync(x => x.Id == id);
        if (entity is null)
        {
            return null;
        }

        var dictDto = Mapper.Map<DictDto>(entity);
        return dictDto;
    }

    public async Task<PageModelDto<DictDto>> GetPagedAsync(SearchPagedDto input)
    {
        input.TrimStringFields();
        var whereExpr = ExpressionCreator
            .New<SysDictionary>()
            .AndIf(input.Keywords.IsNotNullOrWhiteSpace(), x => EF.Functions.Like(x.Name, $"{input.Keywords}%") || EF.Functions.Like(x.Code, $"{input.Keywords}%"));

        var total = await dictRepo.CountAsync(whereExpr);
        if (total == 0)
        {
            return new PageModelDto<DictDto>(input);
        }

        var entities = await dictRepo
                                        .Where(whereExpr)
                                        .OrderByDescending(x => x.Id)
                                        .Skip(input.SkipRows())
                                        .Take(input.PageSize)
                                        .ToListAsync();
        var cfgDtos = Mapper.Map<List<DictDto>>(entities);

        return new PageModelDto<DictDto>(input, cfgDtos, total);
    }

    public async Task<List<DictOptionDto>> GetOptionsAsync(string codes)
    {
        if (codes.IsNullOrWhiteSpace())
        {
            return [];
        }

        var whereExpr = ExpressionCreator
            .New<DictOptionDto>()
            .AndIf(codes != "all", x => codes.Split(",", StringSplitOptions.RemoveEmptyEntries).Contains(x.Code));

        var allDictOptions = await cacheService.GetAllDictOptionsFromCacheAsync();
        var result = allDictOptions.Where(whereExpr.Compile()).ToList();
        return result ?? [];
    }
}
