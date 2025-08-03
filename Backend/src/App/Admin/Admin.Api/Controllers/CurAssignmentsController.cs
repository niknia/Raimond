    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curassignments  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curassignmentss")]
    [ApiController]
    public class CurAssignmentsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurAssignmentsAppService  _curassignmentsappservice;
     private readonly ILogger<CurAssignmentsController> _logger;

    public CurAssignmentsController(
        UserContext userContext,
        ICurAssignmentsAppService curassignmentsappservice,
        ILogger<CurAssignmentsController> logger
        )
    {
        _userContext = userContext;
        _curassignmentsappservice = curassignmentsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurAssignments
    /// </summary>
    /// <param name="input">CurAssignments information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurAssignments.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurAssignmentsCreationDto input)
        => CreatedResult(await _curassignmentsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurAssignments
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurAssignments information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurAssignments.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurAssignmentsUpdationDto input)
        => Result(await _curassignmentsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurAssignments
    /// </summary>
    /// <param name="id">CurAssignments ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurAssignments.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curassignmentsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurAssignments pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurAssignments.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurAssignmentsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurAssignmentsDto>>> GetPagedAsync([FromQuery] CurAssignmentsSearchPagedDto search)
        => await _curassignmentsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurAssignments data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    // [AdncAuthorize(PermissionConsts.CurAssignments.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurAssignmentsDto>> GetAsync([FromRoute] long id)
    {
        var _curassignments = await _curassignmentsappservice.GetAsync(id);
        if (_curassignments is not null)
            return _curassignments;

        return NotFound();
    }
   }
