    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curquestions  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curquestionss")]
    [ApiController]
    public class CurQuestionsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurQuestionsAppService  _curquestionsappservice;
     private readonly ILogger<CurQuestionsController> _logger;

    public CurQuestionsController(
        UserContext userContext,
        ICurQuestionsAppService curquestionsappservice,
        ILogger<CurQuestionsController> logger
        )
    {
        _userContext = userContext;
        _curquestionsappservice = curquestionsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurQuestions
    /// </summary>
    /// <param name="input">CurQuestions information</param>
    /// <returns></returns>
    [HttpPost]
    //[AdncAuthorize(PermissionConsts.CurQuestions.Create)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurQuestionsCreationDto input)
        => CreatedResult(await _curquestionsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurQuestions
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurQuestions information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    //[AdncAuthorize(PermissionConsts.CurQuestions.Update)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurQuestionsUpdationDto input)
        => Result(await _curquestionsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurQuestions
    /// </summary>
    /// <param name="id">CurQuestions ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    //[AdncAuthorize(PermissionConsts.CurQuestions.Delete)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curquestionsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurQuestions pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    //[AdncAuthorize(PermissionConsts.CurQuestions.GetList)]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PageModelDto<CurQuestionsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurQuestionsDto>>> GetPagedAsync([FromQuery] CurQuestionsSearchPagedDto search)
        => await _curquestionsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurQuestions data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    //[AdncAuthorize(PermissionConsts.CurQuestions.Get)]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurQuestionsDto>> GetAsync([FromRoute] long id)
    {
        var _curquestions = await _curquestionsappservice.GetAsync(id);
        if (_curquestions is not null)
            return _curquestions;

        return NotFound();
    }
   }
