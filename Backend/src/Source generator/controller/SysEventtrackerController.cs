    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// syseventtracker  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/syseventtrackers")]
    [ApiController]
    public class SysEventtrackerController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysEventtrackerAppService  _syseventtrackerappservice;
     private readonly ILogger<SysEventtrackerController> _logger;

    public SysEventtrackerController(
        UserContext userContext,
        ISysEventtrackerAppService syseventtrackerappservice,
        ILogger<SysEventtrackerController> logger
        )
    {
        _userContext = userContext;
        _syseventtrackerappservice = syseventtrackerappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysEventtracker
    /// </summary>
    /// <param name="input">SysEventtracker information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysEventtracker.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysEventtrackerCreationDto input)
        => CreatedResult(await _syseventtrackerappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysEventtracker
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysEventtracker information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysEventtracker.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysEventtrackerUpdationDto input)
        => Result(await _syseventtrackerappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysEventtracker
    /// </summary>
    /// <param name="id">SysEventtracker ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysEventtracker.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _syseventtrackerappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysEventtracker pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysEventtracker.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysEventtrackerDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysEventtrackerDto>>> GetPagedAsync([FromQuery] SysEventtrackerSearchPagedDto search)
        => await _syseventtrackerappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysEventtracker data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysEventtracker.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysEventtrackerDto>> GetAsync([FromRoute] long id)
    {
        var _syseventtracker = await _syseventtrackerappservice.GetAsync(id);
        if (_syseventtracker is not null)
            return _syseventtracker;

        return NotFound();
    }
   }
    