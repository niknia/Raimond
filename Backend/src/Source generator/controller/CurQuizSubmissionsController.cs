    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curquizsubmissions  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curquizsubmissionss")]
    [ApiController]
    public class CurQuizSubmissionsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurQuizSubmissionsAppService  _curquizsubmissionsappservice;
     private readonly ILogger<CurQuizSubmissionsController> _logger;

    public CurQuizSubmissionsController(
        UserContext userContext,
        ICurQuizSubmissionsAppService curquizsubmissionsappservice,
        ILogger<CurQuizSubmissionsController> logger
        )
    {
        _userContext = userContext;
        _curquizsubmissionsappservice = curquizsubmissionsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurQuizSubmissions
    /// </summary>
    /// <param name="input">CurQuizSubmissions information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurQuizSubmissions.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurQuizSubmissionsCreationDto input)
        => CreatedResult(await _curquizsubmissionsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurQuizSubmissions
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurQuizSubmissions information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurQuizSubmissions.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurQuizSubmissionsUpdationDto input)
        => Result(await _curquizsubmissionsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurQuizSubmissions
    /// </summary>
    /// <param name="id">CurQuizSubmissions ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurQuizSubmissions.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curquizsubmissionsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurQuizSubmissions pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurQuizSubmissions.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurQuizSubmissionsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurQuizSubmissionsDto>>> GetPagedAsync([FromQuery] CurQuizSubmissionsSearchPagedDto search)
        => await _curquizsubmissionsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurQuizSubmissions data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurQuizSubmissions.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurQuizSubmissionsDto>> GetAsync([FromRoute] long id)
    {
        var _curquizsubmissions = await _curquizsubmissionsappservice.GetAsync(id);
        if (_curquizsubmissions is not null)
            return _curquizsubmissions;

        return NotFound();
    }
   }
    