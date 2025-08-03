    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curanswers  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curanswerss")]
    [ApiController]
    public class CurAnswersController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurAnswersAppService  _curanswersappservice;
     private readonly ILogger<CurAnswersController> _logger;

    public CurAnswersController(
        UserContext userContext,
        ICurAnswersAppService curanswersappservice,
        ILogger<CurAnswersController> logger
        )
    {
        _userContext = userContext;
        _curanswersappservice = curanswersappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurAnswers
    /// </summary>
    /// <param name="input">CurAnswers information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurAnswers.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurAnswersCreationDto input)
        => CreatedResult(await _curanswersappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurAnswers
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurAnswers information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurAnswers.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurAnswersUpdationDto input)
        => Result(await _curanswersappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurAnswers
    /// </summary>
    /// <param name="id">CurAnswers ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurAnswers.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curanswersappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurAnswers pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurAnswers.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurAnswersDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurAnswersDto>>> GetPagedAsync([FromQuery] CurAnswersSearchPagedDto search)
        => await _curanswersappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurAnswers data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurAnswers.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurAnswersDto>> GetAsync([FromRoute] long id)
    {
        var _curanswers = await _curanswersappservice.GetAsync(id);
        if (_curanswers is not null)
            return _curanswers;

        return NotFound();
    }
   }
    