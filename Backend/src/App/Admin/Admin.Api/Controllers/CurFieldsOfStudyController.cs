    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curfieldsofstudy  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curfieldsofstudys")]
    [ApiController]
    public class CurFieldsOfStudyController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurFieldsOfStudyAppService  _curfieldsofstudyappservice;
     private readonly ILogger<CurFieldsOfStudyController> _logger;

    public CurFieldsOfStudyController(
        UserContext userContext,
        ICurFieldsOfStudyAppService curfieldsofstudyappservice,
        ILogger<CurFieldsOfStudyController> logger
        )
    {
        _userContext = userContext;
        _curfieldsofstudyappservice = curfieldsofstudyappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurFieldsOfStudy
    /// </summary>
    /// <param name="input">CurFieldsOfStudy information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurFieldsOfStudy.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurFieldsOfStudyCreationDto input)
        => CreatedResult(await _curfieldsofstudyappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurFieldsOfStudy
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurFieldsOfStudy information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurFieldsOfStudy.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurFieldsOfStudyUpdationDto input)
        => Result(await _curfieldsofstudyappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurFieldsOfStudy
    /// </summary>
    /// <param name="id">CurFieldsOfStudy ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurFieldsOfStudy.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curfieldsofstudyappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurFieldsOfStudy pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurFieldsOfStudy.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurFieldsOfStudyDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurFieldsOfStudyDto>>> GetPagedAsync([FromQuery] CurFieldsOfStudySearchPagedDto search)
        => await _curfieldsofstudyappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurFieldsOfStudy data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurFieldsOfStudy.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurFieldsOfStudyDto>> GetAsync([FromRoute] long id)
    {
        var _curfieldsofstudy = await _curfieldsofstudyappservice.GetAsync(id);
        if (_curfieldsofstudy is not null)
            return _curfieldsofstudy;

        return NotFound();
    }
   }
    