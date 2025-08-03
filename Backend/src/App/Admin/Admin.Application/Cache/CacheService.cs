namespace Dkd.App.Admin.Application.Cache;

public sealed class CacheService(Lazy<ICacheProvider> cacheProvider, Lazy<IDistributedLocker> dictributeLocker
    , Lazy<ILogger<CacheService>> logger, Lazy<IServiceProvider> serviceProvider, Lazy<IConfiguration> configuration
    , Lazy<IObjectMapper> mapper)
    : AbstractCacheService(cacheProvider, serviceProvider), ICachePreheatable
{
    public override async Task PreheatAsync()
    {
        await GetAllOrganizationsFromCacheAsync();
        await GetAllMenusFromCacheAsync();
        await GetAllRoleMenuCodesFromCacheAsync();
        await GetAllDictOptionsFromCacheAsync();
        await GetAllSysConfigsFromCacheAsync();
  // await GetAllStationFromCacheAsync();
    }

    internal int GetRefreshTokenExpires()
    {
        var refreshTokenExpire = configuration.Value.GetValue<int>($"{NodeConsts.JWT}:RefreshTokenExpire");
        var clockSkew = configuration.Value.GetValue<int>($"{NodeConsts.JWT}:ClockSkew");
        return refreshTokenExpire + clockSkew;
    }

    internal async Task SetFailLoginCountToCacheAsync(long id, int count)
    {
        var cacheKey = ConcatCacheKey(CachingConsts.UserFailCountKeyPrefix, id);
        await CacheProvider.Value.SetAsync(cacheKey, count, TimeSpan.FromSeconds(GetRefreshTokenExpires()));
    }

    internal async Task RemoveFailLoginCountToCacheAsync(long id)
    {
        var cacheKey = ConcatCacheKey(CachingConsts.UserFailCountKeyPrefix, id);
        await CacheProvider.Value.RemoveAsync(cacheKey);
    }

    internal async Task<int> GetFailLoginCountByUserIdAsync(long id)
    {
        var cacheKey = ConcatCacheKey(CachingConsts.UserFailCountKeyPrefix, id);
        var cacheValue = await CacheProvider.Value.GetAsync<int>(cacheKey);
        return cacheValue.Value;
    }

    internal async Task SetValidateInfoToCacheAsync(UserValidatedInfoDto value)
    {
        var cacheKey = ConcatCacheKey(CachingConsts.UserValidatedInfoKeyPrefix, value.Id);
        await CacheProvider.Value.SetAsync(cacheKey, value, TimeSpan.FromSeconds(GetRefreshTokenExpires()));
    }

    internal async Task<UserValidatedInfoDto?> GetUserValidateInfoFromCacheAsync(long id)
    {
        var cacheKey = ConcatCacheKey(CachingConsts.UserValidatedInfoKeyPrefix, id.ToString());
        var cacheValue = await CacheProvider.Value.GetAsync<UserValidatedInfoDto>(cacheKey);
        return cacheValue.Value;
    }

    internal async Task ChangeUserValidateInfoCacheExpiresDtAsync(long id)
    {
        var cacheKey = ConcatCacheKey(CachingConsts.UserValidatedInfoKeyPrefix, id);
        await CacheProvider.Value.KeyExpireAsync([cacheKey], GetRefreshTokenExpires());
    }

    internal async Task<List<OrganizationDto>> GetAllOrganizationsFromCacheAsync()
    {
        var cahceValue = await CacheProvider.Value.GetAsync(CachingConsts.DetpListCacheKey, async () =>
        {
            using var scope = ServiceProvider.Value.CreateScope();
            var orgRepo = scope.ServiceProvider.GetRequiredService<IEfRepository<SysOrganization>>();
            var allOrganizations = await orgRepo.GetAll(writeDb: true).OrderBy(x => x.Ordinal).ToListAsync();
            return mapper.Value.Map<List<OrganizationDto>>(allOrganizations);
        }, TimeSpan.FromSeconds(GeneralConsts.OneYear));

        return cahceValue.Value ?? [];
    }

    internal async Task<List<MenuDto>> GetAllMenusFromCacheAsync()
    {
        var cahceValue = await CacheProvider.Value.GetAsync(CachingConsts.MenuListCacheKey, async () =>
        {
            using var scope = ServiceProvider.Value.CreateScope();
            var menuRepo = scope.ServiceProvider.GetRequiredService<IEfRepository<SysMenu>>();
            var allMenus = await menuRepo.GetAll(writeDb: true).OrderBy(x => x.Ordinal).ToListAsync();
            return mapper.Value.Map<List<MenuDto>>(allMenus);
        }, TimeSpan.FromSeconds(GeneralConsts.OneYear));

        return cahceValue.Value ?? [];
    }

    internal async Task<List<RoleMenuCodeDto>> GetAllRoleMenuCodesFromCacheAsync()
    {
        var cahceValue = await CacheProvider.Value.GetAsync(CachingConsts.RoleMenuCodesCacheKey, async () =>
        {
            var result = await GetAllRoleMenuCodesFromDb();
            return result;

        }, TimeSpan.FromSeconds(GeneralConsts.OneYear));

        return cahceValue.Value ?? [];
    }

    internal async Task SetAllRoleMenuCodesToCacheAsync()
    {
        var cacheValue = await GetAllRoleMenuCodesFromDb();
        await CacheProvider.Value.SetAsync(CachingConsts.RoleMenuCodesCacheKey, cacheValue, TimeSpan.FromSeconds(GeneralConsts.OneYear));
    }

    [Obsolete($"use {nameof(GetAllDictOptionsFromCacheAsync)} instead")]
    internal async Task PreheatAllDictOptionsAsync()
    {
        var exists = await CacheProvider.Value.ExistsAsync(CachingConsts.DictOptionsPreheatedKey);
        if (exists)
        {
            return;
        }

        var (Success, LockValue) = await dictributeLocker.Value.LockAsync(CachingConsts.DictOptionsPreheatedKey);
        if (!Success)
        {
            await Task.Delay(500);
            await PreheatAllDictOptionsAsync();
        }

        try
        {
            using var scope = ServiceProvider.Value.CreateScope();
            var dictRepo = scope.ServiceProvider.GetRequiredService<IEfRepository<SysDictionary>>();
            var dictDataRepo = scope.ServiceProvider.GetRequiredService<IEfRepository<SysDictionaryData>>();

            var dicts = dictRepo.GetAll();
            var dictDatas = dictDataRepo.GetAll();
            var queryList = await (from d in dicts
                                   join dd in dictDatas on d.Code equals dd.Dictcode
                                   orderby dd.Ordinal ascending
                                   select new { dd.Dictcode, d.Name, dd.Label, dd.Value, dd.Tagtype }).ToListAsync();

            if (queryList.IsNullOrEmpty())
            {
                return;
            }

            var cahceDictionary = new Dictionary<string, DictOptionDto>();
            var codes = queryList.Select(x => x.Dictcode).Distinct();
            foreach (var code in codes)
            {
                var cacheKey = ConcatCacheKey(CachingConsts.DictOptionSingleKeyPrefix, code);
                var dictOptions = new DictOptionDto
                {
                    Code = code,
                    Name = queryList.First(x => x.Dictcode == code).Name,
                    DictDataList = queryList.Where(x => x.Dictcode == code).Select(x => new DictOptionDto.DictDataOption { Label = x.Label, Value = x.Value, TagType = x.Tagtype }).ToArray()
                };
                cahceDictionary.Add(cacheKey, dictOptions);
            }
            await CacheProvider.Value.SetAllAsync(cahceDictionary, TimeSpan.FromSeconds(GeneralConsts.OneMonth));
            logger.Value.LogInformation("finished({Count}) preheat {DictOptionSingleKeyPrefix}", cahceDictionary.Count, CachingConsts.DictOptionSingleKeyPrefix);
        }
        catch (Exception ex)
        {
            logger.Value.LogError(ex, "{message}", ex.Message);
            await dictributeLocker.Value.SafedUnLockAsync(CachingConsts.DictOptionsPreheatedKey, LockValue);
            throw new InvalidOperationException("PreheatAllCfgsAsync was failure", ex);
        }
        var serverInfo = ServiceProvider.Value.GetRequiredService<IServiceInfo>();
        await CacheProvider.Value.SetAsync(CachingConsts.DictOptionsPreheatedKey, serverInfo.Version, TimeSpan.FromSeconds(GeneralConsts.OneYear));
    }

    internal async Task<List<DictOptionDto>> GetAllDictOptionsFromCacheAsync()
    {
        var cahceValue = await CacheProvider.Value.GetAsync(CachingConsts.DictOptionsListKey, async () =>
        {
            using var scope = ServiceProvider.Value.CreateScope();
            var dictRepo = scope.ServiceProvider.GetRequiredService<IEfRepository<SysDictionary>>();
            var dictDataRepo = scope.ServiceProvider.GetRequiredService<IEfRepository<SysDictionaryData>>();

            var dicts = dictRepo.GetAll();
            var dictDatas = dictDataRepo.GetAll();
            var queryList = await (from d in dicts
                                   join dd in dictDatas on d.Code equals dd.Dictcode
                                   where dd.Status == true
                                   orderby dd.Ordinal ascending
                                   select new { d.Code, d.Name, dd.Label, dd.Value, dd.Tagtype }).ToListAsync();

            var dictOptions = new List<DictOptionDto>();
            var codes = queryList.Select(x => x.Code).Distinct();
            foreach (var code in codes)
            {
                var option = new DictOptionDto
                {
                    Code = code,
                    Name = queryList.First(x => x.Code == code).Name,
                    DictDataList = queryList.Where(x => x.Code == code).Select(x => new DictOptionDto.DictDataOption { Label = x.Label, Value = x.Value, TagType = x.Tagtype }).ToArray()
                };
                dictOptions.Add(option);
            }

            return dictOptions;
        }, TimeSpan.FromSeconds(GeneralConsts.OneYear));

        return cahceValue.Value ?? [];
    }

    internal async Task<List<SysConfigSimpleDto>> GetAllSysConfigsFromCacheAsync()
    {
        var cahceValue = await CacheProvider.Value.GetAsync(CachingConsts.SysConfigListCacheKey, async () =>
        {
            using var scope = ServiceProvider.Value.CreateScope();
            var sysConfigRepo = scope.ServiceProvider.GetRequiredService<IEfRepository<SysConfig>>();
            var simpleConfigs = await sysConfigRepo.GetAll(writeDb: true).Select(x => new SysConfigSimpleDto { Key = x.Key, Name = x.Name, Value = x.Value }).ToListAsync();
            return simpleConfigs;
        }, TimeSpan.FromSeconds(GeneralConsts.OneYear));

        return cahceValue.Value ?? [];
    }

    private async Task<List<RoleMenuCodeDto>> GetAllRoleMenuCodesFromDb()
    {
        using var scope = ServiceProvider.Value.CreateScope();
        var menuRepo = scope.ServiceProvider.GetRequiredService<IEfRepository<SysMenu>>();
        var roleMenuRepo = scope.ServiceProvider.GetRequiredService<IEfRepository<SysRole>>();

        var menuQueryAble = menuRepo.GetAll();
        var roleMenuQueryAble = roleMenuRepo.GetAll();

        var result = new List<RoleMenuCodeDto>();
        List<(long roleid, string perm)> itemsSelect = new List<(long roleid, string perm)>();
        foreach (var menu in menuQueryAble)
        {
            var selectRoles = roleMenuQueryAble.Where(u => u.FkMenu != null && ("," + u.FkMenu + ",").Contains($",{menu.Id},"))
                .ToList();
            foreach (var roleSelect in selectRoles)
            {
                itemsSelect.Add(new(roleSelect.Id, menu.Perm));
            }
        }
        var grouped = itemsSelect
            .GroupBy(x => x.roleid)
             .Select(g => new RoleMenuCodeDto
              {
               RoleId = g.Key,
               Perms = g.Select(x => x.perm).ToArray()
              })
            .ToList();

        result.AddRange(grouped);

        //var roleCodes = await (from r in roleMenuQueryAble
        //                       join m in menuQueryAble on r.MenuId equals m.Id
        //                       select new { r.RoleId, m.Perm, m.RoutePath }
        //                        ).ToListAsync();


        //var roleIds = roleCodes.Select(x => x.RoleId).Distinct();
        //foreach (var roleId in roleIds)
        //{
        //    var perms = roleCodes.Where(x => x.RoleId == roleId).Select(x => x.Perm.IsNullOrWhiteSpace() ? x.RoutePath : x.Perm).ToArray() ?? [];
        //    result.Add(new RoleMenuCodeDto { RoleId = roleId, Perms = perms });
        //}
        return result;
    }

    
}
