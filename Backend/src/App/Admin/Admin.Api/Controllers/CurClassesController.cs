    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curclasses  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curclassess")]
    [ApiController]
    public class CurClassesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurClassesAppService  _curclassesappservice;
     private readonly ILogger<CurClassesController> _logger;

    public CurClassesController(
        UserContext userContext,
        ICurClassesAppService curclassesappservice,
        ILogger<CurClassesController> logger
        )
    {
        _userContext = userContext;
        _curclassesappservice = curclassesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurClasses
    /// </summary>
    /// <param name="input">CurClasses information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurClasses.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurClassesCreationDto input)
        => CreatedResult(await _curclassesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurClasses
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurClasses information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurClasses.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurClassesUpdationDto input)
        => Result(await _curclassesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurClasses
    /// </summary>
    /// <param name="id">CurClasses ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurClasses.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curclassesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurClasses pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurClasses.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurClassesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurClassesDto>>> GetPagedAsync([FromQuery] CurClassesSearchPagedDto search)
        => await _curclassesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurClasses data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurClasses.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurClassesDto>> GetAsync([FromRoute] long id)
    {
        var _curclasses = await _curclassesappservice.GetAsync(id);
        if (_curclasses is not null)
            return _curclasses;

        return NotFound();
    }
   }
    