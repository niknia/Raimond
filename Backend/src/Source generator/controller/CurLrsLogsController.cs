    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curlrslogs  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curlrslogss")]
    [ApiController]
    public class CurLrsLogsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurLrsLogsAppService  _curlrslogsappservice;
     private readonly ILogger<CurLrsLogsController> _logger;

    public CurLrsLogsController(
        UserContext userContext,
        ICurLrsLogsAppService curlrslogsappservice,
        ILogger<CurLrsLogsController> logger
        )
    {
        _userContext = userContext;
        _curlrslogsappservice = curlrslogsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurLrsLogs
    /// </summary>
    /// <param name="input">CurLrsLogs information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurLrsLogs.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurLrsLogsCreationDto input)
        => CreatedResult(await _curlrslogsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurLrsLogs
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurLrsLogs information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurLrsLogs.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurLrsLogsUpdationDto input)
        => Result(await _curlrslogsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurLrsLogs
    /// </summary>
    /// <param name="id">CurLrsLogs ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurLrsLogs.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curlrslogsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurLrsLogs pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurLrsLogs.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurLrsLogsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurLrsLogsDto>>> GetPagedAsync([FromQuery] CurLrsLogsSearchPagedDto search)
        => await _curlrslogsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurLrsLogs data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurLrsLogs.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurLrsLogsDto>> GetAsync([FromRoute] long id)
    {
        var _curlrslogs = await _curlrslogsappservice.GetAsync(id);
        if (_curlrslogs is not null)
            return _curlrslogs;

        return NotFound();
    }
   }
    