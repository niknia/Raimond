using static Dkd.App.Const.Permissions.Admin.PermissionConsts;

namespace Dkd.App.Admin.Application.Services;

public class MenuService(IEfRepository<SysMenu> menuRepo, IEfRepository<SysRole> roleRepo, CacheService cacheService) : AbstractAppService, IMenuService
{
    public async Task<ServiceResult<IdDto>> CreateAsync(MenuCreationDto input)
    {
        input.TrimStringFields();
        if (input.Perm.IsNotNullOrEmpty())
        {
            var existsCode = await menuRepo.AnyAsync(x => x.Perm == input.Perm);
            if (existsCode)
            {
                return Problem(HttpStatusCode.BadRequest, "Menu code already exists");
            }
        }

        var existsName = await menuRepo.AnyAsync(x => x.Name == input.Name);
        if (existsName)
        {
            return Problem(HttpStatusCode.BadRequest, "Menu name already exists");
        }

        var menuEntity = Mapper.Map<SysMenu>(input, IdGenerater.GetNextId());
        if (input.Type == MenuType.CATALOG.ToString())
        {
            menuEntity.Component = "Layout";
        }
        menuEntity.Parentids = await GetParentIds(menuEntity.Parentid);

        await menuRepo.InsertAsync(menuEntity);

        return new IdDto(menuEntity.Id);
    }

    public async Task<ServiceResult> UpdateAsync(long id, MenuUpdationDto input)
    {
        input.TrimStringFields();
        if (input.Perm.IsNotNullOrEmpty())
        {
            var existsCode = await menuRepo.AnyAsync(x => x.Perm == input.Perm && x.Id != id);
            if (existsCode)
            {
                return Problem(HttpStatusCode.BadRequest, "Menu code already exists");
            }
        }

        var existsName = await menuRepo.AnyAsync(x => x.Name == input.Name && x.Id != id);
        if (existsName)
        {
            return Problem(HttpStatusCode.BadRequest, "Menu name already exists");
        }

        var menuEntity = await menuRepo.FetchAsync(x => x.Id == id, noTracking: false);
        if (menuEntity is null)
        {
            return Problem(HttpStatusCode.NotFound, "Menu does not exist");
        }

        Mapper.Map(input, menuEntity);
        menuEntity.Parentids = await GetParentIds(menuEntity.Parentid);

        await menuRepo.UpdateAsync(menuEntity);

        return ServiceResult();
    }

    public async Task<ServiceResult> DeleteAsync(long id)
    {
        var menuEnity = await menuRepo.FetchAsync(x => new { x.Id, x.Parentids }, x => x.Id == id);
        if (menuEnity is null)
        {
            return ServiceResult();
        }

        var needDeletedParentIds = $"{menuEnity.Parentids}[{menuEnity.Id}]";
        await menuRepo.ExecuteDeleteAsync(x => x.Parentids.Contains(needDeletedParentIds) || x.Id == id);
        return ServiceResult();
    }

    public async Task<List<MenuTreeDto>> GetTreelistAsync(string? keywords = null)
    {
        var whereExpr = ExpressionCreator.New<MenuDto>().AndIf(keywords is not null, x => x.Name == keywords);
        var menus = (await cacheService.GetAllMenusFromCacheAsync()).Where(whereExpr.Compile()).OrderBy(x => x.ParentId).ThenBy(x => x.Ordinal).ToArray();

        var exists = await cacheService.CacheProvider.Value.ExistsAsync(CachingConsts.RoleMenuCodesCacheKey);
        if (!exists)
        {
            _ = await cacheService.GetAllRoleMenuCodesFromCacheAsync();
        }

        List<MenuTreeDto> GetChildren(long id)
        {
            var menuTree = new List<MenuTreeDto>();
            var parentMenuDtos = menus.Where(x => x.ParentId == id);
            foreach (var menuDto in parentMenuDtos)
            {
                var menuNode = Mapper.Map<MenuTreeDto>(menuDto);
                menuNode.Children = GetChildren(menuDto.Id);
                menuTree.Add(menuNode);
            }
            return menuTree;
        }

        var rootId = menus.First().ParentId;
        return GetChildren(rootId);
    }

    public async Task<MenuDto?> GetAsync(long id)
    {
        var allMenus = await cacheService.GetAllMenusFromCacheAsync();
        var menuDto = allMenus.FirstOrDefault(x => x.Id == id);
        return menuDto;
    }

    public async Task<List<RouterTreeDto>> GetMenusForRouterAsync(IEnumerable<long> roleIds)
    {
        //All menus
        var allMenus = await cacheService.GetAllMenusFromCacheAsync();

        var selectMenuAcess = await roleRepo.Where(x=> roleIds.Contains(x.Id)).Select(role => role.FkMenu).ToArrayAsync();

        var roleIdselect = selectMenuAcess
          .Where(x => !string.IsNullOrEmpty(x))
          .SelectMany(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
          .Select(long.Parse)
          .ToArray();

        //Menu IDs owned by roles
        var menusIds = await menuRepo.Where(x => roleIdselect.Contains(x.Id)).Select(x => x.Id).Distinct().ToArrayAsync();
        //Get menu entities by menu ID
        var menus = allMenus.Where(x => menusIds.Contains(x.Id) && x.Type != MenuType.BUTTON.ToString());
        if (menus.IsNullOrEmpty())
        {
            return [];
        }

        List<RouterTreeDto> GetChildren(long id)
        {
            var routerTree = new List<RouterTreeDto>();
            var parentMenuDtos = menus.Where(x => x.ParentId == id);
            foreach (var menuDto in parentMenuDtos)
            {
                var router = new RouterTreeDto
                {
                    Name = menuDto.RouteName,
                    Path = menuDto.RoutePath,
                    Component = menuDto.Component,
                    Redirect = menuDto.Redirect,
                    Meta = new RouterTreeDto.RouteMeta
                    {
                        Icon = menuDto.Icon,
                        Title = menuDto.Name,
                        Hidden = !menuDto.Visible,
                        KeepAlive = menuDto.KeepAlive,
                        AlwaysShow = menuDto.AlwaysShow
                    },
                    Children = GetChildren(menuDto.Id)
                };
                routerTree.Add(router);
            }
            return routerTree;
        }

        return GetChildren(0);
    }

    public async Task<List<OptionTreeDto>> GetMenuOptionsAsync(bool? onlyParent)
    {
        var whereExpression = ExpressionCreator.New<MenuDto>().AndIf(onlyParent is not null, x => x.Type != MenuType.BUTTON.ToString());

        var menus = (await cacheService.GetAllMenusFromCacheAsync()).Where(whereExpression.Compile()).ToArray();

        List<OptionTreeDto> GetChildren(long id)
        {
            var optionTree = new List<OptionTreeDto>();
            var parentMenuDtos = menus.Where(x => x.ParentId == id);
            foreach (var menuDto in parentMenuDtos)
            {
                var optionNode = new OptionTreeDto
                {
                    Label = menuDto.Name,
                    Value = menuDto.Id,
                    Children = GetChildren(menuDto.Id)
                };
                optionTree.Add(optionNode);
            }
            return optionTree;
        }

        return GetChildren(0);
    }

    private async Task<string> GetParentIds(long parentId)
    {
        var parentIds = "[0]";
        var parentMenuEntity = await menuRepo.FetchAsync(x => new { x.Id, x.Parentids }, y => y.Id == parentId);
        if (parentMenuEntity is not null)
        {
            parentIds = $"{parentMenuEntity.Parentids}[{parentMenuEntity.Id}]";
        }
        return parentIds;
    }
}
