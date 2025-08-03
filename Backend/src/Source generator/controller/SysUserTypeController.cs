    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysusertype  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysusertypes")]
    [ApiController]
    public class SysUserTypeController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysUserTypeAppService  _sysusertypeappservice;
     private readonly ILogger<SysUserTypeController> _logger;

    public SysUserTypeController(
        UserContext userContext,
        ISysUserTypeAppService sysusertypeappservice,
        ILogger<SysUserTypeController> logger
        )
    {
        _userContext = userContext;
        _sysusertypeappservice = sysusertypeappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysUserType
    /// </summary>
    /// <param name="input">SysUserType information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysUserType.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysUserTypeCreationDto input)
        => CreatedResult(await _sysusertypeappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysUserType
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysUserType information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysUserType.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysUserTypeUpdationDto input)
        => Result(await _sysusertypeappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysUserType
    /// </summary>
    /// <param name="id">SysUserType ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysUserType.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysusertypeappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysUserType pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysUserType.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysUserTypeDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysUserTypeDto>>> GetPagedAsync([FromQuery] SysUserTypeSearchPagedDto search)
        => await _sysusertypeappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysUserType data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysUserType.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysUserTypeDto>> GetAsync([FromRoute] long id)
    {
        var _sysusertype = await _sysusertypeappservice.GetAsync(id);
        if (_sysusertype is not null)
            return _sysusertype;

        return NotFound();
    }
   }
    