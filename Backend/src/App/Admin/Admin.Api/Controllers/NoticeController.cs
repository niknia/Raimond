namespace Dkd.App.Admin.Api.Controllers;

/// <summary>
/// Notice Management
/// </summary>
[Route($"{RouteConsts.AdminRoot}/notices")]
[ApiController]
public class NoticeController() : AdncControllerBase
{
    /*
    /// <summary>
    /// Create Notice
    /// </summary>
    /// <param name="input"><see cref="SysConfigCreationDto"/></param>
    /// <returns></returns>
    //[HttpPost]
    //[AdncAuthorize(PermissionConsts.SysConfig.Create)]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    //public async Task<ActionResult<long>> CreateAsync([FromBody] SysConfigCreationDto input)
    //    =>  CreatedResult(await sysConfigService.CreateAsync(input));

    /// <summary>
    /// Update Notice
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input"><see cref="SysConfigUpdationDto"/></param>
    /// <returns></returns>
    //[HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.SysConfig.Update)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //public async Task<ActionResult<long>> UpdateAsync([FromRoute] long id, [FromBody] SysConfigUpdationDto input)
    //    => Result(await sysConfigService.UpdateAsync(id, input));

    /// <summary>
    /// Delete Notice
    /// </summary>
    /// <param name="ids">Node ID</param>
    /// <returns></returns>
    //[HttpDelete("{ids}")]
    //[AdncAuthorize(PermissionConsts.SysConfig.Delete)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //public async Task<ActionResult> DeleteAsync([FromRoute] string ids)
    //{
    //    var idArr = ids.Split(',').Select(x => long.Parse(x)).ToArray();
    //    return Result(await sysConfigService.DeleteAsync(idArr));
    //}

    /// <summary>
    /// Get Single Notice
    /// </summary>
    /// <param name="id">Node ID</param>
    /// <returns></returns>
    //[HttpGet("{id}")]
    //// [AdncAuthorize(PermissionConsts.SysConfig.Search, AdncAuthorizeAttribute.JwtWithBasicSchemes)]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<ActionResult<SysConfigDto>> GetAsync([FromRoute] long id)
    //{
    //    var cfg = await sysConfigService.GetAsync(id);
    //    return cfg is null ? NotFound() : cfg;
    //}
    */

    /// <summary>
    /// Get Notice Paged List
    /// </summary>
    /// <param name="input"><see cref="NoticeSearchPagedDto"/></param>
    /// <returns><see cref="PageModelDto{CfgDto}"/></returns>
    [HttpGet("mine")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<NoticeDto>>> GetMinePagedAsync([FromQuery] NoticeSearchPagedDto input)
    {
        await Task.CompletedTask;
        return new PageModelDto<NoticeDto>(input);
    }
}
