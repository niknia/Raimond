    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curteachingmethods  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curteachingmethodss")]
    [ApiController]
    public class CurTeachingMethodsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurTeachingMethodsAppService  _curteachingmethodsappservice;
     private readonly ILogger<CurTeachingMethodsController> _logger;

    public CurTeachingMethodsController(
        UserContext userContext,
        ICurTeachingMethodsAppService curteachingmethodsappservice,
        ILogger<CurTeachingMethodsController> logger
        )
    {
        _userContext = userContext;
        _curteachingmethodsappservice = curteachingmethodsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurTeachingMethods
    /// </summary>
    /// <param name="input">CurTeachingMethods information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurTeachingMethods.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurTeachingMethodsCreationDto input)
        => CreatedResult(await _curteachingmethodsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurTeachingMethods
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurTeachingMethods information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurTeachingMethods.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurTeachingMethodsUpdationDto input)
        => Result(await _curteachingmethodsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurTeachingMethods
    /// </summary>
    /// <param name="id">CurTeachingMethods ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurTeachingMethods.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curteachingmethodsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurTeachingMethods pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurTeachingMethods.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurTeachingMethodsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurTeachingMethodsDto>>> GetPagedAsync([FromQuery] CurTeachingMethodsSearchPagedDto search)
        => await _curteachingmethodsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurTeachingMethods data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurTeachingMethods.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurTeachingMethodsDto>> GetAsync([FromRoute] long id)
    {
        var _curteachingmethods = await _curteachingmethodsappservice.GetAsync(id);
        if (_curteachingmethods is not null)
            return _curteachingmethods;

        return NotFound();
    }
   }
    