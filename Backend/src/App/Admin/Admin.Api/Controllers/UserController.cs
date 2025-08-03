namespace Dkd.App.Admin.Api.Controllers;

/// <summary>
/// User management
/// </summary>
[Route($"{RouteConsts.AdminRoot}/users")]
[ApiController]
public class UserController(IUserService userService) : AdncControllerBase
{
    /// <summary>
    /// Add a new user
    /// </summary>
    /// <param name="input">User information</param>
    /// <returns></returns>
    [HttpPost]
    [AdncAuthorize(PermissionConsts.User.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<IdDto>> CreateAsync([FromBody] UserCreationDto input)
        => CreatedResult(await userService.CreateAsync(input));

    /// <summary>
    /// Modify user information
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">User information</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [AdncAuthorize(PermissionConsts.User.Update)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> UpdateAsync([FromRoute] long id, [FromBody] UserUpdationDto input)
        => Result(await userService.UpdateAsync(id, input));

    /// <summary>
    /// Delete user
    /// </summary>
    /// <param name="ids">User ID</param>
    /// <returns></returns>
    [HttpDelete("{ids}")]
    [AdncAuthorize(PermissionConsts.User.Delete)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync([FromRoute] string ids)
    {
        var idArr = ids.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        return Result(await userService.DeleteAsync(idArr));
    }

    /// <summary>
    /// Reset password
    /// </summary>
    /// <param name="id"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    [HttpPatch("{id}/password")]
    [AdncAuthorize(PermissionConsts.User.ResetPassword)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> ResetPasswordAsync([FromRoute] long id, string password)
        => Result(await userService.ResetPasswordAsync(id, password));

    /// <summary>
    /// Get user information
    /// </summary>
    /// <param name="id">User ID</param>
    /// <returns><see cref="UserDto"/></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [AdncAuthorize([PermissionConsts.User.Get, PermissionConsts.User.Update])]
    public async Task<ActionResult<UserDto>> GetAsync([FromRoute] long id)
    {
        var user = await userService.GetAsync(id);
        return user is null ? NotFound() : user;
    }

    /// <summary>
    /// Get user paged list
    /// </summary>
    /// <param name="input">Search criteria</param>
    /// <returns><see cref="PageModelDto{UserDto}"/></returns>
    [HttpGet("page")]
    [AdncAuthorize(PermissionConsts.User.Search)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PageModelDto<UserDto>>> GetPagedAsync([FromQuery] UserSearchPagedDto input)
        => await userService.GetPagedAsync(input);
}
