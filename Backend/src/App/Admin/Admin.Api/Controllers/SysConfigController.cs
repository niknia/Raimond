namespace Dkd.App.Admin.Api.Controllers;

/// <summary>
/// Configuration Management
/// </summary>
[Route($"{RouteConsts.AdminRoot}/sysconfigs")]
[ApiController]
public class SysConfigController(ISysConfigService sysConfigService) : AdncControllerBase
{
    /// <summary>
    /// Add new configuration
    /// </summary>
    /// <param name="input"><see cref="SysConfigCreationDto"/></param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.ConfigSys.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IdDto>> CreateAsync([FromBody] SysConfigCreationDto input)
        => CreatedResult(await sysConfigService.CreateAsync(input));

    /// <summary>
    /// Update configuration
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input"><see cref="SysConfigUpdationDto"/></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.ConfigSys.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<long>> UpdateAsync([FromRoute] long id, [FromBody] SysConfigUpdationDto input)
        => Result(await sysConfigService.UpdateAsync(id, input));

    /// <summary>
    /// Delete configuration node
    /// </summary>
    /// <param name="ids">Node ID</param>
    /// <returns></returns>
    [HttpDelete("{ids}")]
    [AdncAuthorize(PermissionConsts.ConfigSys.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] string ids)
    {
        var idArr = ids.Split(',').Select(long.Parse).ToArray();
        return Result(await sysConfigService.DeleteAsync(idArr));
    }

    /// <summary>
    /// Get single configuration node
    /// </summary>
    /// <param name="id">Node ID</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize([PermissionConsts.ConfigSys.Get, PermissionConsts.ConfigSys.Update])]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SysConfigDto>> GetAsync([FromRoute] long id)
    {
        var cfg = await sysConfigService.GetAsync(id);
        return cfg is null ? NotFound() : cfg;
    }

    /// <summary>
    /// Get configuration list
    /// </summary>
    /// <param name="input"><see cref="SearchPagedDto"/></param>
    /// <returns><see cref="PageModelDto{SysConfigDto}"/></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.ConfigSys.Search)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysConfigDto>>> GetPagedAsync([FromQuery] SearchPagedDto input)
      => await sysConfigService.GetPagedAsync(input);

    /// <summary>
    /// Get configuration list by keys
    /// </summary>
    /// <param name="keys"></param>
    /// <returns><see cref="List{SysConfigSimpleDto}"/></returns>
    [HttpGet()]
    [AdncAuthorize(PermissionConsts.ConfigSys.Search, AdncAuthorizeAttribute.JwtWithBasicSchemes)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<SysConfigSimpleDto>>> GetListAsync([FromQuery] string keys)
        => await sysConfigService.GetListAsync(keys);
}
