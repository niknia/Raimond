    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curqualifications  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curqualificationss")]
    [ApiController]
    public class CurQualificationsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurQualificationsAppService  _curqualificationsappservice;
     private readonly ILogger<CurQualificationsController> _logger;

    public CurQualificationsController(
        UserContext userContext,
        ICurQualificationsAppService curqualificationsappservice,
        ILogger<CurQualificationsController> logger
        )
    {
        _userContext = userContext;
        _curqualificationsappservice = curqualificationsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurQualifications
    /// </summary>
    /// <param name="input">CurQualifications information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurQualifications.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurQualificationsCreationDto input)
        => CreatedResult(await _curqualificationsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurQualifications
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurQualifications information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurQualifications.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurQualificationsUpdationDto input)
        => Result(await _curqualificationsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurQualifications
    /// </summary>
    /// <param name="id">CurQualifications ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurQualifications.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curqualificationsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurQualifications pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurQualifications.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurQualificationsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurQualificationsDto>>> GetPagedAsync([FromQuery] CurQualificationsSearchPagedDto search)
        => await _curqualificationsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurQualifications data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurQualifications.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurQualificationsDto>> GetAsync([FromRoute] long id)
    {
        var _curqualifications = await _curqualificationsappservice.GetAsync(id);
        if (_curqualifications is not null)
            return _curqualifications;

        return NotFound();
    }
   }
