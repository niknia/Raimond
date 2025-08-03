    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curreligions  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curreligionss")]
    [ApiController]
    public class CurReligionsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurReligionsAppService  _curreligionsappservice;
     private readonly ILogger<CurReligionsController> _logger;

    public CurReligionsController(
        UserContext userContext,
        ICurReligionsAppService curreligionsappservice,
        ILogger<CurReligionsController> logger
        )
    {
        _userContext = userContext;
        _curreligionsappservice = curreligionsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurReligions
    /// </summary>
    /// <param name="input">CurReligions information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurReligions.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurReligionsCreationDto input)
        => CreatedResult(await _curreligionsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurReligions
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurReligions information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //  [AdncAuthorize(PermissionConsts.CurReligions.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurReligionsUpdationDto input)
        => Result(await _curreligionsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurReligions
    /// </summary>
    /// <param name="id">CurReligions ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurReligions.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curreligionsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurReligions pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    // [AdncAuthorize(PermissionConsts.CurReligions.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurReligionsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurReligionsDto>>> GetPagedAsync([FromQuery] CurReligionsSearchPagedDto search)
        => await _curreligionsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurReligions data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurReligions.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurReligionsDto>> GetAsync([FromRoute] long id)
    {
        var _curreligions = await _curreligionsappservice.GetAsync(id);
        if (_curreligions is not null)
            return _curreligions;

        return NotFound();
    }
   }
