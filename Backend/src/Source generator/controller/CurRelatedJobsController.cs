    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// currelatedjobs  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/currelatedjobss")]
    [ApiController]
    public class CurRelatedJobsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurRelatedJobsAppService  _currelatedjobsappservice;
     private readonly ILogger<CurRelatedJobsController> _logger;

    public CurRelatedJobsController(
        UserContext userContext,
        ICurRelatedJobsAppService currelatedjobsappservice,
        ILogger<CurRelatedJobsController> logger
        )
    {
        _userContext = userContext;
        _currelatedjobsappservice = currelatedjobsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurRelatedJobs
    /// </summary>
    /// <param name="input">CurRelatedJobs information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurRelatedJobs.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurRelatedJobsCreationDto input)
        => CreatedResult(await _currelatedjobsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurRelatedJobs
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurRelatedJobs information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurRelatedJobs.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurRelatedJobsUpdationDto input)
        => Result(await _currelatedjobsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurRelatedJobs
    /// </summary>
    /// <param name="id">CurRelatedJobs ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurRelatedJobs.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _currelatedjobsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurRelatedJobs pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurRelatedJobs.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurRelatedJobsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurRelatedJobsDto>>> GetPagedAsync([FromQuery] CurRelatedJobsSearchPagedDto search)
        => await _currelatedjobsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurRelatedJobs data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurRelatedJobs.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurRelatedJobsDto>> GetAsync([FromRoute] long id)
    {
        var _currelatedjobs = await _currelatedjobsappservice.GetAsync(id);
        if (_currelatedjobs is not null)
            return _currelatedjobs;

        return NotFound();
    }
   }
    