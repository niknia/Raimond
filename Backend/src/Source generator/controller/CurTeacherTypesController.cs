    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curteachertypes  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curteachertypess")]
    [ApiController]
    public class CurTeacherTypesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurTeacherTypesAppService  _curteachertypesappservice;
     private readonly ILogger<CurTeacherTypesController> _logger;

    public CurTeacherTypesController(
        UserContext userContext,
        ICurTeacherTypesAppService curteachertypesappservice,
        ILogger<CurTeacherTypesController> logger
        )
    {
        _userContext = userContext;
        _curteachertypesappservice = curteachertypesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurTeacherTypes
    /// </summary>
    /// <param name="input">CurTeacherTypes information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurTeacherTypes.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurTeacherTypesCreationDto input)
        => CreatedResult(await _curteachertypesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurTeacherTypes
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurTeacherTypes information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurTeacherTypes.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurTeacherTypesUpdationDto input)
        => Result(await _curteachertypesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurTeacherTypes
    /// </summary>
    /// <param name="id">CurTeacherTypes ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurTeacherTypes.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curteachertypesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurTeacherTypes pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurTeacherTypes.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurTeacherTypesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurTeacherTypesDto>>> GetPagedAsync([FromQuery] CurTeacherTypesSearchPagedDto search)
        => await _curteachertypesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurTeacherTypes data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurTeacherTypes.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurTeacherTypesDto>> GetAsync([FromRoute] long id)
    {
        var _curteachertypes = await _curteachertypesappservice.GetAsync(id);
        if (_curteachertypes is not null)
            return _curteachertypes;

        return NotFound();
    }
   }
    