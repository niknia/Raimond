namespace Dkd.App.Admin.Api.Controllers;

/// <summary>
/// Dictionary Management
/// </summary>
[Route($"{RouteConsts.AdminRoot}/dicts")]
[ApiController]
public class DictController(IDictService dictService) : AdncControllerBase
{
    /// <summary>
    /// Create Dictionary
    /// </summary>
    /// <param name="input"><see cref="DictCreationDto"/></param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.Dict.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IdDto>> CreateAsync([FromBody] DictCreationDto input)
        => CreatedResult(await dictService.CreateAsync(input));

    /// <summary>
    /// Update Dictionary
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input"><see cref="DictUpdationDto"/></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.Dict.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<long>> UpdateAsync([FromRoute] long id, [FromBody] DictUpdationDto input)
        => Result(await dictService.UpdateAsync(id, input));

    /// <summary>
    /// Delete Dictionary
    /// </summary>
    /// <param name="ids">Dictionary IDs</param>
    /// <returns></returns>
    [HttpDelete("{ids}")]
    [AdncAuthorize(PermissionConsts.Dict.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] string ids)
    {
        var idArr = ids.Split(',').Select(long.Parse).ToArray();
        return Result(await dictService.DeleteAsync(idArr));
    }

    /// <summary>
    /// Get Dictionary Paged List
    /// </summary>
    /// <param name="input"></param>
    /// <returns><see cref="PageModelDto{DictDto}"/></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.Dict.Search)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<DictDto>>> GetPagedAsync([FromQuery] SearchPagedDto input)
        => await dictService.GetPagedAsync(input);

    /// <summary>
    /// Get Single Dictionary
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize([PermissionConsts.Dict.Get, PermissionConsts.Dict.Update])]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DictDto>> GetAsync([FromRoute] long id)
    {
        var dict = await dictService.GetAsync(id);
        return dict is null ? NotFound() : dict;
    }

    /// <summary>
    /// Get Dictionary Data Options List
    /// </summary>
    /// <param name="codes">Dictionary Code</param>
    /// <returns><see cref="List{DictOption}"/></returns>
    [HttpGet("options")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DictOptionDto>>> GetOptionsAsync([FromQuery] string codes)
        => await dictService.GetOptionsAsync(codes);
}
