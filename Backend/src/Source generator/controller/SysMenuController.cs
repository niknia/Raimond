    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysmenu  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysmenus")]
    [ApiController]
    public class SysMenuController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysMenuAppService  _sysmenuappservice;
     private readonly ILogger<SysMenuController> _logger;

    public SysMenuController(
        UserContext userContext,
        ISysMenuAppService sysmenuappservice,
        ILogger<SysMenuController> logger
        )
    {
        _userContext = userContext;
        _sysmenuappservice = sysmenuappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysMenu
    /// </summary>
    /// <param name="input">SysMenu information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysMenu.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysMenuCreationDto input)
        => CreatedResult(await _sysmenuappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysMenu
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysMenu information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysMenu.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysMenuUpdationDto input)
        => Result(await _sysmenuappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysMenu
    /// </summary>
    /// <param name="id">SysMenu ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysMenu.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysmenuappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysMenu pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysMenu.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysMenuDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysMenuDto>>> GetPagedAsync([FromQuery] SysMenuSearchPagedDto search)
        => await _sysmenuappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysMenu data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysMenu.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysMenuDto>> GetAsync([FromRoute] long id)
    {
        var _sysmenu = await _sysmenuappservice.GetAsync(id);
        if (_sysmenu is not null)
            return _sysmenu;

        return NotFound();
    }
   }
    