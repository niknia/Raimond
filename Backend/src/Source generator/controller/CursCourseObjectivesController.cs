    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curscourseobjectives  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curscourseobjectivess")]
    [ApiController]
    public class CursCourseObjectivesController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICursCourseObjectivesAppService  _curscourseobjectivesappservice;
     private readonly ILogger<CursCourseObjectivesController> _logger;

    public CursCourseObjectivesController(
        UserContext userContext,
        ICursCourseObjectivesAppService curscourseobjectivesappservice,
        ILogger<CursCourseObjectivesController> logger
        )
    {
        _userContext = userContext;
        _curscourseobjectivesappservice = curscourseobjectivesappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CursCourseObjectives
    /// </summary>
    /// <param name="input">CursCourseObjectives information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CursCourseObjectives.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CursCourseObjectivesCreationDto input)
        => CreatedResult(await _curscourseobjectivesappservice.CreateAsync(input));

    /// <summary>
    /// Modify CursCourseObjectives
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CursCourseObjectives information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CursCourseObjectives.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CursCourseObjectivesUpdationDto input)
        => Result(await _curscourseobjectivesappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CursCourseObjectives
    /// </summary>
    /// <param name="id">CursCourseObjectives ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CursCourseObjectives.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curscourseobjectivesappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CursCourseObjectives pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CursCourseObjectives.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CursCourseObjectivesDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CursCourseObjectivesDto>>> GetPagedAsync([FromQuery] CursCourseObjectivesSearchPagedDto search)
        => await _curscourseobjectivesappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CursCourseObjectives data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CursCourseObjectives.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CursCourseObjectivesDto>> GetAsync([FromRoute] long id)
    {
        var _curscourseobjectives = await _curscourseobjectivesappservice.GetAsync(id);
        if (_curscourseobjectives is not null)
            return _curscourseobjectives;

        return NotFound();
    }
   }
    