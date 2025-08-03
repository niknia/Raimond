    namespace Dkd.App.Admin.Api.Controllers;
    /// <summary>
    /// sysdictionarydata  controllers
    /// </summary>
    [Route($"{RouteConsts.AdminRoot}/sysdictionarydatas")]
    [ApiController]
    public class SysDictionaryDataController : AdncControllerBase
     {
     private readonly UserContext _userContext;
     private readonly ISysDictionaryDataAppService  _sysdictionarydataappservice;
     private readonly ILogger<SysDictionaryDataController> _logger;

    public SysDictionaryDataController(
        UserContext userContext,
        ISysDictionaryDataAppService sysdictionarydataappservice,
        ILogger<SysDictionaryDataController> logger
        )
    {
        _userContext = userContext;
        _sysdictionarydataappservice = sysdictionarydataappservice;
        _logger = logger;
    }
    /// <summary>
    /// New SysDictionaryData
    /// </summary>
    /// <param name="input">SysDictionaryData information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.SysDictionaryData.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IDto>> CreateAsync([FromBody] SysDictionaryDataCreationDto input)
        => CreatedResult(await _sysdictionarydataappservice.CreateAsync(input));

    /// <summary>
    /// Modify SysDictionaryData
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">SysDictionaryData information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.SysDictionaryData.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] SysDictionaryDataUpdationDto input)
        => Result(await _sysdictionarydataappservice.UpdateAsync(id, input));

    /// <summary>
    /// delete SysDictionaryData
    /// </summary>
    /// <param name="id">SysDictionaryData ID</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [AdncAuthorize(PermissionConsts.SysDictionaryData.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] long id)
        => Result(await _sysdictionarydataappservice.DeleteAsync(id));
     
    /// <summary>
    /// Get SysDictionaryData pagination list
    /// </summary>
    /// <param name="search">Query criteria</param>
    /// <returns></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.SysDictionaryData.GetList)]    
    [ProducesResponseType(typeof(PageModelDto<SysDictionaryDataDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<SysDictionaryDataDto>>> GetPagedAsync([FromQuery] SysDictionaryDataSearchPagedDto search)
        => await _sysdictionarydataappservice.GetPagedAsync(search);

    /// <summary>
    /// Get a single SysDictionaryData data
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    [AdncAuthorize(PermissionConsts.SysDictionaryData.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SysDictionaryDataDto>> GetAsync([FromRoute] long id)
    {
        var _sysdictionarydata = await _sysdictionarydataappservice.GetAsync(id);
        if (_sysdictionarydata is not null)
            return _sysdictionarydata;

        return NotFound();
    }
   }
    