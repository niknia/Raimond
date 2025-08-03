    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curmaritalstatuses  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curmaritalstatusess")]
    [ApiController]
    public class CurMaritalStatusesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurMaritalStatusesAppService  _curmaritalstatusesappservice;
     private readonly ILogger<CurMaritalStatusesController> _logger;

    public CurMaritalStatusesController(
        UserContext userContext,
        ICurMaritalStatusesAppService curmaritalstatusesappservice,
        ILogger<CurMaritalStatusesController> logger
        )
    {
        _userContext = userContext;
        _curmaritalstatusesappservice = curmaritalstatusesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurMaritalStatuses
    /// </summary>
    /// <param name="input">CurMaritalStatuses information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurMaritalStatuses.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurMaritalStatusesCreationDto input)
        => CreatedResult(await _curmaritalstatusesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurMaritalStatuses
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurMaritalStatuses information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurMaritalStatuses.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurMaritalStatusesUpdationDto input)
        => Result(await _curmaritalstatusesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurMaritalStatuses
    /// </summary>
    /// <param name="id">CurMaritalStatuses ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurMaritalStatuses.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curmaritalstatusesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurMaritalStatuses pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurMaritalStatuses.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurMaritalStatusesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurMaritalStatusesDto>>> GetPagedAsync([FromQuery] CurMaritalStatusesSearchPagedDto search)
        => await _curmaritalstatusesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurMaritalStatuses data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurMaritalStatuses.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurMaritalStatusesDto>> GetAsync([FromRoute] long id)
    {
        var _curmaritalstatuses = await _curmaritalstatusesappservice.GetAsync(id);
        if (_curmaritalstatuses is not null)
            return _curmaritalstatuses;

        return NotFound();
    }
   }
