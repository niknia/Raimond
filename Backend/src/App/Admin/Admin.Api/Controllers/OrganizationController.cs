namespace Dkd.App.Admin.Api.Controllers;

/// <summary>
/// Organization Management
/// </summary>
[Route($"{RouteConsts.AdminRoot}/organizations")]
[ApiController]
public class OrganizationController(IOrganizationService organizationService) : AdncControllerBase
{
    /// <summary>
    /// Create Organization
    /// </summary>
    /// <param name="input">Organization</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.Org.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IdDto>> CreateAsync([FromBody] OrganizationCreationDto input)
        => CreatedResult(await organizationService.CreateAsync(input));

    /// <summary>
    /// Update Organization
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">Organization</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.Org.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<long>> UpdateAsync([FromRoute] long id, [FromBody] OrganizationUpdationDto input)
        => Result(await organizationService.UpdateAsync(id, input));

    /// <summary>
    /// Delete Organization
    /// </summary>
    /// <param name="ids">Organization IDs</param>
    /// <returns></returns>
    [HttpDelete("{ids}")]
    [AdncAuthorize(PermissionConsts.Org.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete([FromRoute] string ids)
    {
        var idArr = ids.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        return Result(await organizationService.DeleteAsync(idArr));
    }

    /// <summary>
    /// Get Organization Information
    /// </summary>
    /// <param name="id">Organization ID</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize([PermissionConsts.Org.Get, PermissionConsts.Org.Update])]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrganizationDto>> GetAsync([FromRoute] long id)
    {
        var org = await organizationService.GetAsync(id);
        return org is null ? NotFound() : org;
    }

    /// <summary>
    /// Get Organization List
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    [AdncAuthorize(PermissionConsts.Org.Search, AdncAuthorizeAttribute.JwtWithBasicSchemes)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OrganizationTreeDto>>> GetTreeListAsync(string? keywords = null, bool? status = null)
        => await organizationService.GetTreeListAsync(keywords, status);

    /// <summary>
    /// Get Organization Options
    /// </summary>
    /// <returns></returns>
    [HttpGet("options")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OptionTreeDto>>> GetOrgOptionsAsync()
        => await organizationService.GetOrgOptionsAsync(true);
}
