    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curusers  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curuserss")]
    [ApiController]
    public class CurUsersController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurUsersAppService  _curusersappservice;
     private readonly ILogger<CurUsersController> _logger;

    public CurUsersController(
        UserContext userContext,
        ICurUsersAppService curusersappservice,
        ILogger<CurUsersController> logger
        )
    {
        _userContext = userContext;
        _curusersappservice = curusersappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurUsers
    /// </summary>
    /// <param name="input">CurUsers information</param>
    /// <returns></returns>
    [HttpPost]
    // [AdncAuthorize(PermissionConsts.CurUsers.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurUsersCreationDto input)
        => CreatedResult(await _curusersappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurUsers
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurUsers information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //  [AdncAuthorize(PermissionConsts.CurUsers.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurUsersUpdationDto input)
        => Result(await _curusersappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurUsers
    /// </summary>
    /// <param name="id">CurUsers ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //  [AdncAuthorize(PermissionConsts.CurUsers.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curusersappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurUsers pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    // [AdncAuthorize(PermissionConsts.CurUsers.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurUsersDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurUsersDto>>> GetPagedAsync([FromQuery] CurUsersSearchPagedDto search)
        => await _curusersappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurUsers data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    // [AdncAuthorize(PermissionConsts.CurUsers.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurUsersDto>> GetAsync([FromRoute] long id)
    {
        var _curusers = await _curusersappservice.GetAsync(id);
        if (_curusers is not null)
            return _curusers;

        return NotFound();
    }
   }
