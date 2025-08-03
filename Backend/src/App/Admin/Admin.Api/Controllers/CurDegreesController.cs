    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curdegrees  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curdegreess")]
    [ApiController]
    public class CurDegreesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurDegreesAppService  _curdegreesappservice;
     private readonly ILogger<CurDegreesController> _logger;

    public CurDegreesController(
        UserContext userContext,
        ICurDegreesAppService curdegreesappservice,
        ILogger<CurDegreesController> logger
        )
    {
        _userContext = userContext;
        _curdegreesappservice = curdegreesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurDegrees
    /// </summary>
    /// <param name="input">CurDegrees information</param>
    /// <returns></returns>
    [HttpPost]
    // [AdncAuthorize(PermissionConsts.CurDegrees.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurDegreesCreationDto input)
        => CreatedResult(await _curdegreesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurDegrees
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurDegrees information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurDegrees.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurDegreesUpdationDto input)
        => Result(await _curdegreesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurDegrees
    /// </summary>
    /// <param name="id">CurDegrees ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    // [AdncAuthorize(PermissionConsts.CurDegrees.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curdegreesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurDegrees pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    // [AdncAuthorize(PermissionConsts.CurDegrees.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurDegreesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurDegreesDto>>> GetPagedAsync([FromQuery] CurDegreesSearchPagedDto search)
        => await _curdegreesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurDegrees data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurDegrees.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurDegreesDto>> GetAsync([FromRoute] long id)
    {
        var _curdegrees = await _curdegreesappservice.GetAsync(id);
        if (_curdegrees is not null)
            return _curdegrees;

        return NotFound();
    }
   }
