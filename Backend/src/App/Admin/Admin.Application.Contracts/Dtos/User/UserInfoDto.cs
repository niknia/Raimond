namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// User information
/// </summary>
public class UserInfoDto : OutputDto
{
    /// <summary>
    /// Avatar
    /// </summary>
    private string _avatar = string.Empty;

    /// <summary>
    /// Username
    /// </summary>
    public string Account { get; set; } = string.Empty;

    /// <summary>
    /// Name/Nickname
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public string Avatar
    {
        set { _avatar = value; }
        get
        {
            if (_avatar.IsNullOrEmpty())
            {
                _avatar = "https://foruda.gitee.com/images/1723603502796844527/03cdca2a_716974.gif";
            }
            return _avatar;
        }
    }

    /// <summary>
    /// Role code collection
    /// </summary>
    public string[] Roles { get; set; } = [];

    /// <summary>
    /// Permission collection
    /// </summary>
    public string[] Perms { get; set; } = [];
}
