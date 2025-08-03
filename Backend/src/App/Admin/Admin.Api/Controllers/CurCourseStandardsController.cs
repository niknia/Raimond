    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curcoursestandards  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curcoursestandardss")]
    [ApiController]
    public class CurCourseStandardsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurCourseStandardsAppService  _curcoursestandardsappservice;
     private readonly ILogger<CurCourseStandardsController> _logger;

    public CurCourseStandardsController(
        UserContext userContext,
        ICurCourseStandardsAppService curcoursestandardsappservice,
        ILogger<CurCourseStandardsController> logger
        )
    {
        _userContext = userContext;
        _curcoursestandardsappservice = curcoursestandardsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurCourseStandards
    /// </summary>
    /// <param name="input">CurCourseStandards information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurCourseStandards.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurCourseStandardsCreationDto input)
        => CreatedResult(await _curcoursestandardsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurCourseStandards
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurCourseStandards information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourseStandards.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurCourseStandardsUpdationDto input)
        => Result(await _curcoursestandardsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurCourseStandards
    /// </summary>
    /// <param name="id">CurCourseStandards ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourseStandards.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curcoursestandardsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurCourseStandards pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurCourseStandards.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurCourseStandardsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurCourseStandardsDto>>> GetPagedAsync([FromQuery] CurCourseStandardsSearchPagedDto search)
        => await _curcoursestandardsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurCourseStandards data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourseStandards.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurCourseStandardsDto>> GetAsync([FromRoute] long id)
    {
        var _curcoursestandards = await _curcoursestandardsappservice.GetAsync(id);
        if (_curcoursestandards is not null)
            return _curcoursestandards;

        return NotFound();
    }
   }
