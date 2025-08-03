    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysuser  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysusers")]
    [ApiController]
    public class SysUserController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysUserAppService  _sysuserappservice;
     private readonly ILogger<SysUserController> _logger;

    public SysUserController(
        UserContext userContext,
        ISysUserAppService sysuserappservice,
        ILogger<SysUserController> logger
        )
    {
        _userContext = userContext;
        _sysuserappservice = sysuserappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysUser
    /// </summary>
    /// <param name="input">SysUser information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysUser.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysUserCreationDto input)
        => CreatedResult(await _sysuserappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysUser
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysUser information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysUser.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysUserUpdationDto input)
        => Result(await _sysuserappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysUser
    /// </summary>
    /// <param name="id">SysUser ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysUser.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysuserappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysUser pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysUser.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysUserDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysUserDto>>> GetPagedAsync([FromQuery] SysUserSearchPagedDto search)
        => await _sysuserappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysUser data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysUser.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysUserDto>> GetAsync([FromRoute] long id)
    {
        var _sysuser = await _sysuserappservice.GetAsync(id);
        if (_sysuser is not null)
            return _sysuser;

        return NotFound();
    }
   }
    