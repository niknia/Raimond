    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curschedules  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curscheduless")]
    [ApiController]
    public class CurSchedulesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurSchedulesAppService  _curschedulesappservice;
     private readonly ILogger<CurSchedulesController> _logger;

    public CurSchedulesController(
        UserContext userContext,
        ICurSchedulesAppService curschedulesappservice,
        ILogger<CurSchedulesController> logger
        )
    {
        _userContext = userContext;
        _curschedulesappservice = curschedulesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurSchedules
    /// </summary>
    /// <param name="input">CurSchedules information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurSchedules.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurSchedulesCreationDto input)
        => CreatedResult(await _curschedulesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurSchedules
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurSchedules information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurSchedules.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurSchedulesUpdationDto input)
        => Result(await _curschedulesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurSchedules
    /// </summary>
    /// <param name="id">CurSchedules ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurSchedules.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curschedulesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurSchedules pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurSchedules.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurSchedulesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurSchedulesDto>>> GetPagedAsync([FromQuery] CurSchedulesSearchPagedDto search)
        => await _curschedulesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurSchedules data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurSchedules.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurSchedulesDto>> GetAsync([FromRoute] long id)
    {
        var _curschedules = await _curschedulesappservice.GetAsync(id);
        if (_curschedules is not null)
            return _curschedules;

        return NotFound();
    }
   }
    