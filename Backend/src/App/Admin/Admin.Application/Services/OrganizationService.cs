namespace Dkd.App.Admin.Application.Services;

public class OrganizationService(IEfRepository<SysOrganization> organizationRepo, CacheService cacheService)
    : AbstractAppService, IOrganizationService
{
    public async Task<ServiceResult<IdDto>> CreateAsync(OrganizationCreationDto input)
    {
        input.TrimStringFields();
        var exists = await organizationRepo.AnyAsync(x => x.Name == input.Name);
        if (exists)
        {
            return Problem(HttpStatusCode.BadRequest, "Organization name already exists");
        }

        var organization = Mapper.Map<SysOrganization>(input, IdGenerater.GetNextId());
        organization.Parentids = await GetParentIdsAsync(organization.Parentid);
        await organizationRepo.InsertAsync(organization);

        return new IdDto(organization.Id);
    }

    public async Task<ServiceResult> UpdateAsync(long id, OrganizationUpdationDto input)
    {
        input.TrimStringFields();

        var organization = await organizationRepo.FetchAsync(x => x.Id == id, noTracking: false);
        if (organization is null)
        {
            return Problem(HttpStatusCode.NotFound, "Organization does not exist");
        }

        var exists = await organizationRepo.AnyAsync(x => x.Name == input.Name && x.Id != id);
        if (exists)
        {
            return Problem(HttpStatusCode.BadRequest, "Organization name already exists");
        }

        if (organization.Parentid == 0 && input.ParentId > 0)
        {
            return Problem(HttpStatusCode.BadRequest, "Top-level organization cannot change level");
        }

        var oldParentId = organization.Parentid;

        var newOrganization = Mapper.Map(input, organization);
        if (oldParentId != input.ParentId)
        {
            var oldPids = $"{organization.Parentids}";
            var newPids = await GetParentIdsAsync(input.ParentId);
            newOrganization.Parentid = input.ParentId;
            newOrganization.Parentids = newPids;
            var oldSubOrgPids = $"{oldPids}[{id}]";
            var newSubOrgPids = $"{newPids}[{id}]";
            await organizationRepo.ExecuteUpdateAsync(x => x.Parentids.StartsWith(oldSubOrgPids), setters => setters.SetProperty(x => x.Parentids, y => y.Parentids.Replace(oldSubOrgPids, newSubOrgPids)));
        }
        await organizationRepo.UpdateAsync(newOrganization);

        return ServiceResult();
    }

    public async Task<ServiceResult> DeleteAsync(long[] ids)
    {
        foreach (var id in ids)
        {
            var organization = await organizationRepo.FetchAsync(x => new { x.Id, x.Parentids }, x => x.Id == id);
            if (organization is not null)
            {
                var needDeletedPids = $"{organization.Parentids}[{id}]";
                await organizationRepo.ExecuteDeleteAsync(d => d.Parentids.StartsWith(needDeletedPids) || d.Id == organization.Id);
            }
        }
        return ServiceResult();
    }

    public async Task<OrganizationDto?> GetAsync(long Id)
    {
        var org = (await cacheService.GetAllOrganizationsFromCacheAsync()).FirstOrDefault(x => x.Id == Id);
        return org;
    }

    public async Task<List<OrganizationTreeDto>> GetTreeListAsync(string? name = null, bool? status = null)
    {
        var whereExpr = ExpressionCreator
            .New<OrganizationDto>()
            .AndIf(name.IsNotNullOrEmpty(), x => x.Name == name)
            .AndIf(status is not null, x => x.Status == status);
        var orgs = (await cacheService.GetAllOrganizationsFromCacheAsync()).Where(whereExpr.Compile()).OrderBy(x => x.ParentId).ThenBy(x => x.Ordinal);
        if (orgs.IsNullOrEmpty())
        {
            return [];
        }

        List<OrganizationTreeDto> GetChildren(long id)
        {
            var orgTree = new List<OrganizationTreeDto>();
            var parentOrgDtos = orgs.Where(x => x.ParentId == id);
            foreach (var orgDto in parentOrgDtos)
            {
                var orgNode = Mapper.Map<OrganizationTreeDto>(orgDto);
                orgNode.Children = GetChildren(orgDto.Id);
                orgTree.Add(orgNode);
            }
            return orgTree;
        }

        var rootId = orgs.First().ParentId;
        return GetChildren(rootId);
    }

    public async Task<List<OptionTreeDto>> GetOrgOptionsAsync(bool? status = null)
    {
        var orgTree = await GetTreeListAsync(null, status);
        return Mapper.Map<List<OptionTreeDto>>(orgTree);
    }

    private async Task<string> GetParentIdsAsync(long pid)
    {
        var rootPids = "[0]";
        var superiorPids = await organizationRepo.FetchAsync(x => x.Parentids, x => x.Id == pid) ?? rootPids;
        if (superiorPids == rootPids)
        {
            return rootPids;
        }
        else
        {
            return $"{superiorPids}[{pid}]";
        }
    }
}
