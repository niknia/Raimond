    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curteachers  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curteacherss")]
    [ApiController]
    public class CurTeachersController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurTeachersAppService  _curteachersappservice;
     private readonly ILogger<CurTeachersController> _logger;

    public CurTeachersController(
        UserContext userContext,
        ICurTeachersAppService curteachersappservice,
        ILogger<CurTeachersController> logger
        )
    {
        _userContext = userContext;
        _curteachersappservice = curteachersappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurTeachers
    /// </summary>
    /// <param name="input">CurTeachers information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurTeachers.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurTeachersCreationDto input)
        => CreatedResult(await _curteachersappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurTeachers
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurTeachers information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurTeachers.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurTeachersUpdationDto input)
        => Result(await _curteachersappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurTeachers
    /// </summary>
    /// <param name="id">CurTeachers ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurTeachers.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curteachersappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurTeachers pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurTeachers.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurTeachersDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurTeachersDto>>> GetPagedAsync([FromQuery] CurTeachersSearchPagedDto search)
        => await _curteachersappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurTeachers data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurTeachers.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurTeachersDto>> GetAsync([FromRoute] long id)
    {
        var _curteachers = await _curteachersappservice.GetAsync(id);
        if (_curteachers is not null)
            return _curteachers;

        return NotFound();
    }
   }
