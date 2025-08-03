    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysdictionary  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysdictionarys")]
    [ApiController]
    public class SysDictionaryController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysDictionaryAppService  _sysdictionaryappservice;
     private readonly ILogger<SysDictionaryController> _logger;

    public SysDictionaryController(
        UserContext userContext,
        ISysDictionaryAppService sysdictionaryappservice,
        ILogger<SysDictionaryController> logger
        )
    {
        _userContext = userContext;
        _sysdictionaryappservice = sysdictionaryappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysDictionary
    /// </summary>
    /// <param name="input">SysDictionary information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysDictionary.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysDictionaryCreationDto input)
        => CreatedResult(await _sysdictionaryappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysDictionary
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysDictionary information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysDictionary.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysDictionaryUpdationDto input)
        => Result(await _sysdictionaryappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysDictionary
    /// </summary>
    /// <param name="id">SysDictionary ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysDictionary.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysdictionaryappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysDictionary pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysDictionary.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysDictionaryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysDictionaryDto>>> GetPagedAsync([FromQuery] SysDictionarySearchPagedDto search)
        => await _sysdictionaryappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysDictionary data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysDictionary.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysDictionaryDto>> GetAsync([FromRoute] long id)
    {
        var _sysdictionary = await _sysdictionaryappservice.GetAsync(id);
        if (_sysdictionary is not null)
            return _sysdictionary;

        return NotFound();
    }
   }
    