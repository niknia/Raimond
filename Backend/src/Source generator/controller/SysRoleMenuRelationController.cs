    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysrolemenurelation  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysrolemenurelations")]
    [ApiController]
    public class SysRoleMenuRelationController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysRoleMenuRelationAppService  _sysrolemenurelationappservice;
     private readonly ILogger<SysRoleMenuRelationController> _logger;

    public SysRoleMenuRelationController(
        UserContext userContext,
        ISysRoleMenuRelationAppService sysrolemenurelationappservice,
        ILogger<SysRoleMenuRelationController> logger
        )
    {
        _userContext = userContext;
        _sysrolemenurelationappservice = sysrolemenurelationappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysRoleMenuRelation
    /// </summary>
    /// <param name="input">SysRoleMenuRelation information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysRoleMenuRelation.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysRoleMenuRelationCreationDto input)
        => CreatedResult(await _sysrolemenurelationappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysRoleMenuRelation
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysRoleMenuRelation information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysRoleMenuRelation.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysRoleMenuRelationUpdationDto input)
        => Result(await _sysrolemenurelationappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysRoleMenuRelation
    /// </summary>
    /// <param name="id">SysRoleMenuRelation ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysRoleMenuRelation.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysrolemenurelationappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysRoleMenuRelation pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysRoleMenuRelation.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysRoleMenuRelationDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysRoleMenuRelationDto>>> GetPagedAsync([FromQuery] SysRoleMenuRelationSearchPagedDto search)
        => await _sysrolemenurelationappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysRoleMenuRelation data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysRoleMenuRelation.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysRoleMenuRelationDto>> GetAsync([FromRoute] long id)
    {
        var _sysrolemenurelation = await _sysrolemenurelationappservice.GetAsync(id);
        if (_sysrolemenurelation is not null)
            return _sysrolemenurelation;

        return NotFound();
    }
   }
    