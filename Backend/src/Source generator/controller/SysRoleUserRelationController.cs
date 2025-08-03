    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysroleuserrelation  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysroleuserrelations")]
    [ApiController]
    public class SysRoleUserRelationController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysRoleUserRelationAppService  _sysroleuserrelationappservice;
     private readonly ILogger<SysRoleUserRelationController> _logger;

    public SysRoleUserRelationController(
        UserContext userContext,
        ISysRoleUserRelationAppService sysroleuserrelationappservice,
        ILogger<SysRoleUserRelationController> logger
        )
    {
        _userContext = userContext;
        _sysroleuserrelationappservice = sysroleuserrelationappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysRoleUserRelation
    /// </summary>
    /// <param name="input">SysRoleUserRelation information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysRoleUserRelation.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysRoleUserRelationCreationDto input)
        => CreatedResult(await _sysroleuserrelationappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysRoleUserRelation
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysRoleUserRelation information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysRoleUserRelation.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysRoleUserRelationUpdationDto input)
        => Result(await _sysroleuserrelationappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysRoleUserRelation
    /// </summary>
    /// <param name="id">SysRoleUserRelation ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysRoleUserRelation.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysroleuserrelationappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysRoleUserRelation pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysRoleUserRelation.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysRoleUserRelationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysRoleUserRelationDto>>> GetPagedAsync([FromQuery] SysRoleUserRelationSearchPagedDto search)
        => await _sysroleuserrelationappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysRoleUserRelation data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysRoleUserRelation.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysRoleUserRelationDto>> GetAsync([FromRoute] long id)
    {
        var _sysroleuserrelation = await _sysroleuserrelationappservice.GetAsync(id);
        if (_sysroleuserrelation is not null)
            return _sysroleuserrelation;

        return NotFound();
    }
   }
    