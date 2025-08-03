    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curcoursecontents  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curcoursecontentss")]
    [ApiController]
    public class CurCourseContentsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurCourseContentsAppService  _curcoursecontentsappservice;
     private readonly ILogger<CurCourseContentsController> _logger;

    public CurCourseContentsController(
        UserContext userContext,
        ICurCourseContentsAppService curcoursecontentsappservice,
        ILogger<CurCourseContentsController> logger
        )
    {
        _userContext = userContext;
        _curcoursecontentsappservice = curcoursecontentsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurCourseContents
    /// </summary>
    /// <param name="input">CurCourseContents information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurCourseContents.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurCourseContentsCreationDto input)
        => CreatedResult(await _curcoursecontentsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurCourseContents
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurCourseContents information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourseContents.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurCourseContentsUpdationDto input)
        => Result(await _curcoursecontentsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurCourseContents
    /// </summary>
    /// <param name="id">CurCourseContents ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourseContents.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curcoursecontentsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurCourseContents pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurCourseContents.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurCourseContentsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurCourseContentsDto>>> GetPagedAsync([FromQuery] CurCourseContentsSearchPagedDto search)
        => await _curcoursecontentsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurCourseContents data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourseContents.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurCourseContentsDto>> GetAsync([FromRoute] long id)
    {
        var _curcoursecontents = await _curcoursecontentsappservice.GetAsync(id);
        if (_curcoursecontents is not null)
            return _curcoursecontents;

        return NotFound();
    }
   }
