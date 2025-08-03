    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curassignmentsubmissions  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curassignmentsubmissionss")]
    [ApiController]
    public class CurAssignmentSubmissionsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurAssignmentSubmissionsAppService  _curassignmentsubmissionsappservice;
     private readonly ILogger<CurAssignmentSubmissionsController> _logger;

    public CurAssignmentSubmissionsController(
        UserContext userContext,
        ICurAssignmentSubmissionsAppService curassignmentsubmissionsappservice,
        ILogger<CurAssignmentSubmissionsController> logger
        )
    {
        _userContext = userContext;
        _curassignmentsubmissionsappservice = curassignmentsubmissionsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurAssignmentSubmissions
    /// </summary>
    /// <param name="input">CurAssignmentSubmissions information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurAssignmentSubmissions.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurAssignmentSubmissionsCreationDto input)
        => CreatedResult(await _curassignmentsubmissionsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurAssignmentSubmissions
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurAssignmentSubmissions information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurAssignmentSubmissions.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurAssignmentSubmissionsUpdationDto input)
        => Result(await _curassignmentsubmissionsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurAssignmentSubmissions
    /// </summary>
    /// <param name="id">CurAssignmentSubmissions ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //    [AdncAuthorize(PermissionConsts.CurAssignmentSubmissions.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curassignmentsubmissionsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurAssignmentSubmissions pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurAssignmentSubmissions.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurAssignmentSubmissionsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurAssignmentSubmissionsDto>>> GetPagedAsync([FromQuery] CurAssignmentSubmissionsSearchPagedDto search)
        => await _curassignmentsubmissionsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurAssignmentSubmissions data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurAssignmentSubmissions.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurAssignmentSubmissionsDto>> GetAsync([FromRoute] long id)
    {
        var _curassignmentsubmissions = await _curassignmentsubmissionsappservice.GetAsync(id);
        if (_curassignmentsubmissions is not null)
            return _curassignmentsubmissions;

        return NotFound();
    }
   }
