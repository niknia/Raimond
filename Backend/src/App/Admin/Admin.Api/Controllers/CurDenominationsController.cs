    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curdenominations  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curdenominationss")]
    [ApiController]
    public class CurDenominationsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurDenominationsAppService  _curdenominationsappservice;
     private readonly ILogger<CurDenominationsController> _logger;

    public CurDenominationsController(
        UserContext userContext,
        ICurDenominationsAppService curdenominationsappservice,
        ILogger<CurDenominationsController> logger
        )
    {
        _userContext = userContext;
        _curdenominationsappservice = curdenominationsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurDenominations
    /// </summary>
    /// <param name="input">CurDenominations information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurDenominations.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurDenominationsCreationDto input)
        => CreatedResult(await _curdenominationsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurDenominations
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurDenominations information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurDenominations.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurDenominationsUpdationDto input)
        => Result(await _curdenominationsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurDenominations
    /// </summary>
    /// <param name="id">CurDenominations ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurDenominations.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curdenominationsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurDenominations pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurDenominations.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurDenominationsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurDenominationsDto>>> GetPagedAsync([FromQuery] CurDenominationsSearchPagedDto search)
        => await _curdenominationsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurDenominations data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurDenominations.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurDenominationsDto>> GetAsync([FromRoute] long id)
    {
        var _curdenominations = await _curdenominationsappservice.GetAsync(id);
        if (_curdenominations is not null)
            return _curdenominations;

        return NotFound();
    }
   }
    