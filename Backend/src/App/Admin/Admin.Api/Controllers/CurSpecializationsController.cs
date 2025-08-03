    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// curspecializations  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/curspecializationss")]
    [ApiController]
    public class CurSpecializationsController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ICurSpecializationsAppService  _curspecializationsappservice;
     private readonly ILogger<CurSpecializationsController> _logger;

    public CurSpecializationsController(
        UserContext userContext,
        ICurSpecializationsAppService curspecializationsappservice,
        ILogger<CurSpecializationsController> logger
        )
    {
        _userContext = userContext;
        _curspecializationsappservice = curspecializationsappservice;
        _logger = logger;
    }
    /// <summary>
    /// New CurSpecializations
    /// </summary>
    /// <param name="input">CurSpecializations information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.CurSpecializations.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] CurSpecializationsCreationDto input)
        => CreatedResult(await _curspecializationsappservice.CreateAsync(input));

    /// <summary>
    /// Modify CurSpecializations
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">CurSpecializations information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.CurSpecializations.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] CurSpecializationsUpdationDto input)
        => Result(await _curspecializationsappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete CurSpecializations
    /// </summary>
    /// <param name="id">CurSpecializations ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.CurSpecializations.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _curspecializationsappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get CurSpecializations pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.CurSpecializations.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<CurSpecializationsDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<CurSpecializationsDto>>> GetPagedAsync([FromQuery] CurSpecializationsSearchPagedDto search)
        => await _curspecializationsappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single CurSpecializations data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.CurSpecializations.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CurSpecializationsDto>> GetAsync([FromRoute] long id)
    {
        var _curspecializations = await _curspecializationsappservice.GetAsync(id);
        if (_curspecializations is not null)
            return _curspecializations;

        return NotFound();
    }
   }
    