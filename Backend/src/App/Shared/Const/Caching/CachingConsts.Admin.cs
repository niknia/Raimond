using Dkd.Shared;

namespace Dkd.App.Const.Caching.Admin;

public class CachingConsts
{
    //cache key
    public const string MenuListCacheKey = "Raimond:menus:list";
    public const string RoleMenuCodesCacheKey = GeneralConsts.RoleMenuCodesCacheKey;
    public const string DetpListCacheKey = "Raimond:depts:list";
    public const string DictOptionsListKey = "Raimond:dictoptions:list";
    public const string OwnerTrainListKey = "Raimond:ownertrain:list";
    public const string StationTrainListKey = "Raimond:ownertrain:list";
    public const string SysConfigListCacheKey = "Raimond:sysconfigs:list";

    public const string StationListKey = "Raimond:Station:list";

    public const string DictOptionsPreheatedKey = "Raimond:dictoptions:preheated";
    public const string SysConfigPreheatedKey = "Raimond:sysconfigs:preheated";

    //cache prefix
    public const string UserValidatedInfoKeyPrefix = GeneralConsts.UserValidatedInfoKeyPrefix;
    public const string UserFailCountKeyPrefix = "Raimond:users:validatedinfo:failcount";
    public const string DictOptionSingleKeyPrefix = "Raimond:dictoptions:single";

    //bloomfilter
    public const string BloomfilterOfAccountsKey = "Raimond:bloomfilter:accouts";
    public const string BloomfilterOfCacheKey = "Raimond:bloomfilter:cachekeys";
}
