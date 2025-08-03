    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curenrollments  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curenrollmentss")]
    [ApiController]
    public class CurEnrollmentsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurEnrollmentsAppService  _curenrollmentsappservice;
     private readonly ILogger<CurEnrollmentsController> _logger;

    public CurEnrollmentsController(
        UserContext userContext,
        ICurEnrollmentsAppService curenrollmentsappservice,
        ILogger<CurEnrollmentsController> logger
        )
    {
        _userContext = userContext;
        _curenrollmentsappservice = curenrollmentsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurEnrollments
    /// </summary>
    /// <param name="input">CurEnrollments information</param>
    /// <returns></returns>
    [HttpPost]
    //  [AdncAuthorize(PermissionConsts.CurEnrollments.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurEnrollmentsCreationDto input)
        => CreatedResult(await _curenrollmentsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurEnrollments
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurEnrollments information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    // [AdncAuthorize(PermissionConsts.CurEnrollments.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurEnrollmentsUpdationDto input)
        => Result(await _curenrollmentsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurEnrollments
    /// </summary>
    /// <param name="id">CurEnrollments ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //  [AdncAuthorize(PermissionConsts.CurEnrollments.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curenrollmentsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurEnrollments pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurEnrollments.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurEnrollmentsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurEnrollmentsDto>>> GetPagedAsync([FromQuery] CurEnrollmentsSearchPagedDto search)
        => await _curenrollmentsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurEnrollments data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //  [AdncAuthorize(PermissionConsts.CurEnrollments.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurEnrollmentsDto>> GetAsync([FromRoute] long id)
    {
        var _curenrollments = await _curenrollmentsappservice.GetAsync(id);
        if (_curenrollments is not null)
            return _curenrollments;

        return NotFound();
    }
   }
