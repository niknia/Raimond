    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curquizzes  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curquizzess")]
    [ApiController]
    public class CurQuizzesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurQuizzesAppService  _curquizzesappservice;
     private readonly ILogger<CurQuizzesController> _logger;

    public CurQuizzesController(
        UserContext userContext,
        ICurQuizzesAppService curquizzesappservice,
        ILogger<CurQuizzesController> logger
        )
    {
        _userContext = userContext;
        _curquizzesappservice = curquizzesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurQuizzes
    /// </summary>
    /// <param name="input">CurQuizzes information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurQuizzes.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurQuizzesCreationDto input)
        => CreatedResult(await _curquizzesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurQuizzes
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurQuizzes information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurQuizzes.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurQuizzesUpdationDto input)
        => Result(await _curquizzesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurQuizzes
    /// </summary>
    /// <param name="id">CurQuizzes ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurQuizzes.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curquizzesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurQuizzes pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurQuizzes.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurQuizzesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurQuizzesDto>>> GetPagedAsync([FromQuery] CurQuizzesSearchPagedDto search)
        => await _curquizzesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurQuizzes data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurQuizzes.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurQuizzesDto>> GetAsync([FromRoute] long id)
    {
        var _curquizzes = await _curquizzesappservice.GetAsync(id);
        if (_curquizzes is not null)
            return _curquizzes;

        return NotFound();
    }
   }
    