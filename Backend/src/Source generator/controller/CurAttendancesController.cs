    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curattendances  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curattendancess")]
    [ApiController]
    public class CurAttendancesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurAttendancesAppService  _curattendancesappservice;
     private readonly ILogger<CurAttendancesController> _logger;

    public CurAttendancesController(
        UserContext userContext,
        ICurAttendancesAppService curattendancesappservice,
        ILogger<CurAttendancesController> logger
        )
    {
        _userContext = userContext;
        _curattendancesappservice = curattendancesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurAttendances
    /// </summary>
    /// <param name="input">CurAttendances information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurAttendances.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurAttendancesCreationDto input)
        => CreatedResult(await _curattendancesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurAttendances
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurAttendances information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurAttendances.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurAttendancesUpdationDto input)
        => Result(await _curattendancesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurAttendances
    /// </summary>
    /// <param name="id">CurAttendances ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurAttendances.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curattendancesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurAttendances pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurAttendances.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurAttendancesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurAttendancesDto>>> GetPagedAsync([FromQuery] CurAttendancesSearchPagedDto search)
        => await _curattendancesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurAttendances data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurAttendances.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurAttendancesDto>> GetAsync([FromRoute] long id)
    {
        var _curattendances = await _curattendancesappservice.GetAsync(id);
        if (_curattendances is not null)
            return _curattendances;

        return NotFound();
    }
   }
    