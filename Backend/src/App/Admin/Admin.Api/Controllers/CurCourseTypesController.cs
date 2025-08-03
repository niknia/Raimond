    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curcoursetypes  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curcoursetypess")]
    [ApiController]
    public class CurCourseTypesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurCourseTypesAppService  _curcoursetypesappservice;
     private readonly ILogger<CurCourseTypesController> _logger;

    public CurCourseTypesController(
        UserContext userContext,
        ICurCourseTypesAppService curcoursetypesappservice,
        ILogger<CurCourseTypesController> logger
        )
    {
        _userContext = userContext;
        _curcoursetypesappservice = curcoursetypesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurCourseTypes
    /// </summary>
    /// <param name="input">CurCourseTypes information</param>
    /// <returns></returns>
    [HttpPost]
    // [AdncAuthorize(PermissionConsts.CurCourseTypes.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurCourseTypesCreationDto input)
        => CreatedResult(await _curcoursetypesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurCourseTypes
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurCourseTypes information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourseTypes.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurCourseTypesUpdationDto input)
        => Result(await _curcoursetypesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurCourseTypes
    /// </summary>
    /// <param name="id">CurCourseTypes ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurCourseTypes.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curcoursetypesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurCourseTypes pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurCourseTypes.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurCourseTypesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurCourseTypesDto>>> GetPagedAsync([FromQuery] CurCourseTypesSearchPagedDto search)
        => await _curcoursetypesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurCourseTypes data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    // [AdncAuthorize(PermissionConsts.CurCourseTypes.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurCourseTypesDto>> GetAsync([FromRoute] long id)
    {
        var _curcoursetypes = await _curcoursetypesappservice.GetAsync(id);
        if (_curcoursetypes is not null)
            return _curcoursetypes;

        return NotFound();
    }
   }
