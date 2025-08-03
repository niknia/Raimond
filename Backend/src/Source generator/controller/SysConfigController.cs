    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysconfig  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysconfigs")]
    [ApiController]
    public class SysConfigController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysConfigAppService  _sysconfigappservice;
     private readonly ILogger<SysConfigController> _logger;

    public SysConfigController(
        UserContext userContext,
        ISysConfigAppService sysconfigappservice,
        ILogger<SysConfigController> logger
        )
    {
        _userContext = userContext;
        _sysconfigappservice = sysconfigappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysConfig
    /// </summary>
    /// <param name="input">SysConfig information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysConfig.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysConfigCreationDto input)
        => CreatedResult(await _sysconfigappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysConfig
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysConfig information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysConfig.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysConfigUpdationDto input)
        => Result(await _sysconfigappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysConfig
    /// </summary>
    /// <param name="id">SysConfig ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysConfig.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysconfigappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysConfig pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysConfig.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysConfigDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysConfigDto>>> GetPagedAsync([FromQuery] SysConfigSearchPagedDto search)
        => await _sysconfigappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysConfig data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysConfig.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysConfigDto>> GetAsync([FromRoute] long id)
    {
        var _sysconfig = await _sysconfigappservice.GetAsync(id);
        if (_sysconfig is not null)
            return _sysconfig;

        return NotFound();
    }
   }
    