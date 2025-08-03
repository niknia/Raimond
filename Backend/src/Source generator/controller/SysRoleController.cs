    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysrole  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysroles")]
    [ApiController]
    public class SysRoleController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysRoleAppService  _sysroleappservice;
     private readonly ILogger<SysRoleController> _logger;

    public SysRoleController(
        UserContext userContext,
        ISysRoleAppService sysroleappservice,
        ILogger<SysRoleController> logger
        )
    {
        _userContext = userContext;
        _sysroleappservice = sysroleappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysRole
    /// </summary>
    /// <param name="input">SysRole information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysRole.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysRoleCreationDto input)
        => CreatedResult(await _sysroleappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysRole
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysRole information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysRole.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysRoleUpdationDto input)
        => Result(await _sysroleappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysRole
    /// </summary>
    /// <param name="id">SysRole ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysRole.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysroleappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysRole pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysRole.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysRoleDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysRoleDto>>> GetPagedAsync([FromQuery] SysRoleSearchPagedDto search)
        => await _sysroleappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysRole data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysRole.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysRoleDto>> GetAsync([FromRoute] long id)
    {
        var _sysrole = await _sysroleappservice.GetAsync(id);
        if (_sysrole is not null)
            return _sysrole;

        return NotFound();
    }
   }
    