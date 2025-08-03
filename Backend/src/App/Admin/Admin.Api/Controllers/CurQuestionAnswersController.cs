    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curquestionanswers  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curquestionanswerss")]
    [ApiController]
    public class CurQuestionAnswersController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurQuestionAnswersAppService  _curquestionanswersappservice;
     private readonly ILogger<CurQuestionAnswersController> _logger;

    public CurQuestionAnswersController(
        UserContext userContext,
        ICurQuestionAnswersAppService curquestionanswersappservice,
        ILogger<CurQuestionAnswersController> logger
        )
    {
        _userContext = userContext;
        _curquestionanswersappservice = curquestionanswersappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurQuestionAnswers
    /// </summary>
    /// <param name="input">CurQuestionAnswers information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurQuestionAnswers.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurQuestionAnswersCreationDto input)
        => CreatedResult(await _curquestionanswersappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurQuestionAnswers
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurQuestionAnswers information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurQuestionAnswers.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurQuestionAnswersUpdationDto input)
        => Result(await _curquestionanswersappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurQuestionAnswers
    /// </summary>
    /// <param name="id">CurQuestionAnswers ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurQuestionAnswers.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curquestionanswersappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurQuestionAnswers pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurQuestionAnswers.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurQuestionAnswersDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurQuestionAnswersDto>>> GetPagedAsync([FromQuery] CurQuestionAnswersSearchPagedDto search)
        => await _curquestionanswersappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurQuestionAnswers data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurQuestionAnswers.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurQuestionAnswersDto>> GetAsync([FromRoute] long id)
    {
        var _curquestionanswers = await _curquestionanswersappservice.GetAsync(id);
        if (_curquestionanswers is not null)
            return _curquestionanswers;

        return NotFound();
    }
   }
