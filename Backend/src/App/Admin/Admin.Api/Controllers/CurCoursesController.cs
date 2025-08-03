    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curcourses  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curcoursess")]
    [ApiController]
    public class CurCoursesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurCoursesAppService  _curcoursesappservice;
     private readonly ILogger<CurCoursesController> _logger;

    public CurCoursesController(
        UserContext userContext,
        ICurCoursesAppService curcoursesappservice,
        ILogger<CurCoursesController> logger
        )
    {
        _userContext = userContext;
        _curcoursesappservice = curcoursesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurCourses
    /// </summary>
    /// <param name="input">CurCourses information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurCourses.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurCoursesCreationDto input)
        => CreatedResult(await _curcoursesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurCourses
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurCourses information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourses.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurCoursesUpdationDto input)
        => Result(await _curcoursesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurCourses
    /// </summary>
    /// <param name="id">CurCourses ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourses.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curcoursesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurCourses pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurCourses.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurCoursesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurCoursesDto>>> GetPagedAsync([FromQuery] CurCoursesSearchPagedDto search)
        => await _curcoursesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurCourses data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourses.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurCoursesDto>> GetAsync([FromRoute] long id)
    {
        var _curcourses = await _curcoursesappservice.GetAsync(id);
        if (_curcourses is not null)
            return _curcourses;

        return NotFound();
    }
   }
