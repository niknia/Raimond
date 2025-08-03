
namespace Dkd.App.Admin.Application.Services;

public class RoleService(IEfRepository<SysRole> roleRepo, IEfRepository<SysUser> UserRepo, IEfRepository<SysMenu> MenuRepo, CacheService cacheService)
    : AbstractAppService, IRoleService
{
    public async Task<ServiceResult<IdDto>> CreateAsync(RoleCreationDto input)
    {
        input.TrimStringFields();
        var existsCode = await roleRepo.AnyAsync(x => x.Code == input.Code);
        if (existsCode)
        {
            return Problem(HttpStatusCode.BadRequest, "Role code already exists");
        }

        var existsName = await roleRepo.AnyAsync(x => x.Name == input.Name);
        if (existsName)
        {
            return Problem(HttpStatusCode.BadRequest, "Role name already exists");
        }

        var role = Mapper.Map<SysRole>(input, IdGenerater.GetNextId());
        await roleRepo.InsertAsync(role);

        return new IdDto(role.Id);
    }

    public async Task<ServiceResult> UpdateAsync(long id, RoleUpdationDto input)
    {
        input.TrimStringFields();

        var role = await roleRepo.FetchAsync(x => x.Id == id, noTracking: false);
        if (role is null)
        {
            return Problem(HttpStatusCode.BadRequest, "Role ID does not exist");
        }

        var existsCode = await roleRepo.AnyAsync(x => x.Code == input.Code && x.Id != id);
        if (existsCode)
        {
            return Problem(HttpStatusCode.BadRequest, "Role code already exists");
        }

        var existsName = await roleRepo.AnyAsync(x => x.Code == input.Code && x.Id != id);
        if (existsName)
        {
            return Problem(HttpStatusCode.BadRequest, "Role name already exists");
        }

        Mapper.Map(input, role);
        await roleRepo.UpdateAsync(role);
        return ServiceResult();
    }

    public async Task<ServiceResult> DeleteAsync(long[] ids)
    {
        if (ids.Contains(1600000000010))
        {
            return Problem(HttpStatusCode.Forbidden, "Initial role cannot be deleted");
        }

        foreach (var roleId in ids)
        {
            var usersToUpdate = await UserRepo
                .Where(u => u.FkRole != null && ("," + u.FkRole + ",").Contains($",{roleId},"))
                .ToListAsync();

            foreach (var user in usersToUpdate)
            {
                // 2. RolesId را به لیست عددی تبدیل کن
                var roleIds = user.FkRole?
                    .Split(',')
                    .Select(long.Parse)
                    .Where(id => id != roleId)
                    .ToList();

                // 3. دوباره به صورت رشته ذخیره کن
                user.FkRole = string.Join(",", roleIds);
            }

            // 4. تغییرات را ذخیره کن
            if (usersToUpdate.Any())
            {
                await UserRepo.UpdateRangeAsync(usersToUpdate);
            }
        }

        await roleRepo.ExecuteDeleteAsync(x => ids.Contains(x.Id));
        //await roleUserRelationRepo.ExecuteDeleteAsync(x => ids.Contains(x.RoleId));

        await cacheService.SetAllRoleMenuCodesToCacheAsync();

        return ServiceResult();
    }

    public async Task<RoleDto?> GetAsync(long id)
    {
        var role = await roleRepo.FetchAsync(x => x.Id == id);
        return role is null ? null : Mapper.Map<RoleDto>(role);
    }

    public async Task<PageModelDto<RoleDto>> GetPagedAsync(SearchPagedDto input)
    {
        input.TrimStringFields();
        var whereExpression = ExpressionCreator
                                              .New<SysRole>()
                                              .AndIf(input.Keywords.IsNotNullOrWhiteSpace(), x => EF.Functions.Like(x.Name, $"{input.Keywords}%"));

        var total = await roleRepo.CountAsync(whereExpression);
        if (total == 0)
        {
            return new PageModelDto<RoleDto>(input);
        }

        var entities = await roleRepo
                            .Where(whereExpression)
                            .OrderByDescending(x => x.Id)
                            .Skip(input.SkipRows())
                            .Take(input.PageSize)
                            .ToListAsync();
        var dtos = Mapper.Map<List<RoleDto>>(entities);

        return new PageModelDto<RoleDto>(input, dtos, total);
    }

    public async Task<ServiceResult> SetPermissonsAsync(RoleSetPermissonsDto input)
    {
        if (input.RoleId == 1600000000010)
        {
            return Problem(HttpStatusCode.Forbidden, "Initial role permissions cannot be modified");
        }

        //await roleMenuRelationRepo.ExecuteDeleteAsync(x => x.RoleId == input.RoleId);

        //if (input.Permissions.IsNotNullOrEmpty())
        //{
        //    var relations = input.Permissions.Select(x => new RoleMenuRelation { Id = IdGenerater.GetNextId(), RoleId = input.RoleId, MenuId = x });
        //    await roleMenuRelationRepo.InsertRangeAsync(relations);
        //}
        await cacheService.SetAllRoleMenuCodesToCacheAsync();

        return ServiceResult();
    }

    public async Task<long[]> GetMenuIdsAsync(long id)
    {
        var usersToUpdate = await UserRepo
                .Where(u => u.FkRole != null && ("," + u.FkRole + ",").Contains($",{id},"))
                .FirstOrDefaultAsync();

        var menuIds = usersToUpdate?.FkMenu?
                    .Split(',')
                    .Select(long.Parse)
                    .Where(id => id != id)
                    .ToArray();

        //var menuIds = await roleMenuRelationRepo.Where(x => x.RoleId == id).Select(x => x.MenuId).ToArrayAsync();
        return menuIds ?? [];
    }

    public async Task<List<OptionTreeDto>> GetOptionsAsync(bool? status = null)
    {
        var whereExpr = ExpressionCreator
                                      .New<SysRole>()
                                      .AndIf(status is not null, x => x.Status);
        var options = await roleRepo.Where(whereExpr).Select(x => new OptionTreeDto { Label = x.Name, Value = x.Id }).ToListAsync();

        return options ?? [];
    }
}
