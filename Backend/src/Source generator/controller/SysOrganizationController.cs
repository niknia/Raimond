    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysorganization  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysorganizations")]
    [ApiController]
    public class SysOrganizationController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysOrganizationAppService  _sysorganizationappservice;
     private readonly ILogger<SysOrganizationController> _logger;

    public SysOrganizationController(
        UserContext userContext,
        ISysOrganizationAppService sysorganizationappservice,
        ILogger<SysOrganizationController> logger
        )
    {
        _userContext = userContext;
        _sysorganizationappservice = sysorganizationappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysOrganization
    /// </summary>
    /// <param name="input">SysOrganization information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysOrganization.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysOrganizationCreationDto input)
        => CreatedResult(await _sysorganizationappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysOrganization
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysOrganization information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysOrganization.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysOrganizationUpdationDto input)
        => Result(await _sysorganizationappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysOrganization
    /// </summary>
    /// <param name="id">SysOrganization ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysOrganization.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysorganizationappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysOrganization pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysOrganization.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysOrganizationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysOrganizationDto>>> GetPagedAsync([FromQuery] SysOrganizationSearchPagedDto search)
        => await _sysorganizationappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysOrganization data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysOrganization.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysOrganizationDto>> GetAsync([FromRoute] long id)
    {
        var _sysorganization = await _sysorganizationappservice.GetAsync(id);
        if (_sysorganization is not null)
            return _sysorganization;

        return NotFound();
    }
   }
    