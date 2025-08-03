namespace Dkd.App.Admin.Api.Controllers;

/// <summary>
/// Dictionary Data Management
/// </summary>
[Route($"{RouteConsts.AdminRoot}/dictdatas")]
[ApiController]
public class DictDataController(IDictDataService dictDataService) : AdncControllerBase
{
    /// <summary>
    /// Add new dictionary data
    /// </summary>
    /// <param name="input"><see cref="DictDataCreationDto"/></param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.DictData.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IdDto>> CreateAsync([FromBody] DictDataCreationDto input)
        => CreatedResult(await dictDataService.CreateAsync(input));

    /// <summary>
    /// Update dictionary data
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input"><see cref="DictDataUpdationDto"/></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.DictData.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<long>> UpdateAsync([FromRoute] long id, [FromBody] DictDataUpdationDto input)
        => Result(await dictDataService.UpdateAsync(id, input));

    /// <summary>
    /// Delete dictionary data
    /// </summary>
    /// <param name="ids">Dictionary ID</param>
    /// <returns></returns>
    [HttpDelete("{ids}")]
    [AdncAuthorize(PermissionConsts.DictData.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] string ids)
    {
        var idArr = ids.Split(',').Select(long.Parse).ToArray();
        return Result(await dictDataService.DeleteAsync(idArr));
    }

    /// <summary>
    /// Get dictionary data list
    /// </summary>
    /// <returns><see cref="PageModelDto{DictDataDto}"/></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.DictData.Search)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<DictDataDto>>> GetPagedAsync([FromQuery] DictDataSearchPagedDto input)
        => await dictDataService.GetPagedAsync(input);

    /// <summary>
    /// Get single dictionary data
    /// </summary>
    /// <returns><see cref="DictDataDto"/></returns>
    [HttpGet("{id}")]
    [AdncAuthorize([PermissionConsts.DictData.Get, PermissionConsts.DictData.Update])]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<DictDataDto>> GetAsync([FromRoute] long id)
    {
        var dictData = await dictDataService.GetAsync(id);
        return dictData is null ? NotFound() : dictData;
    }
}
