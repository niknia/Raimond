    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curorganizations  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curorganizationss")]
    [ApiController]
    public class CurOrganizationsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurOrganizationsAppService  _curorganizationsappservice;
     private readonly ILogger<CurOrganizationsController> _logger;

    public CurOrganizationsController(
        UserContext userContext,
        ICurOrganizationsAppService curorganizationsappservice,
        ILogger<CurOrganizationsController> logger
        )
    {
        _userContext = userContext;
        _curorganizationsappservice = curorganizationsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurOrganizations
    /// </summary>
    /// <param name="input">CurOrganizations information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurOrganizations.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurOrganizationsCreationDto input)
        => CreatedResult(await _curorganizationsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurOrganizations
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurOrganizations information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurOrganizations.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurOrganizationsUpdationDto input)
        => Result(await _curorganizationsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurOrganizations
    /// </summary>
    /// <param name="id">CurOrganizations ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurOrganizations.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curorganizationsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurOrganizations pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurOrganizations.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurOrganizationsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurOrganizationsDto>>> GetPagedAsync([FromQuery] CurOrganizationsSearchPagedDto search)
        => await _curorganizationsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurOrganizations data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurOrganizations.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurOrganizationsDto>> GetAsync([FromRoute] long id)
    {
        var _curorganizations = await _curorganizationsappservice.GetAsync(id);
        if (_curorganizations is not null)
            return _curorganizations;

        return NotFound();
    }
   }
    