namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// User Profile Information
/// </summary>
public class UserProfileDto : OutputDto
{
    /// <summary>
    /// Avatar
    /// </summary>
    private string _avatar = string.Empty;

    /// <summary>
    /// User Account
    /// </summary>
    public string Account { get; set; } = string.Empty;

    /// <summary>
    /// Department Name
    /// </summary>
    public string DeptName { get; set; } = string.Empty;

    /// <summary>
    /// Gender
    /// </summary>
    public int Gender { get; set; }

    /// <summary>
    /// Email Address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Mobile Number
    /// </summary>
    public string Mobile { get; set; } = string.Empty;

    /// <summary>
    /// Creation Time/Registration Time
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// Multiple Role Names
    /// </summary>
    public string RoleNames { get; set; } = string.Empty;

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
}

public class UserProfileUpdationDto : InputDto
{
    /// <summary>
    /// Gender
    /// </summary>
    public int Gender { get; set; }

    /// <summary>
    /// Name/Nickname
    /// </summary>
    public string Name { get; set; } = string.Empty;
}

public class UserProfileChangePwdDto : InputDto
{
    /// <summary>
    /// Old Password
    /// </summary>
    public string OldPassword { get; set; } = string.Empty;

    /// <summary>
    /// Current Password
    /// </summary>
    public string NewPassword { get; set; } = string.Empty;

    /// <summary>
    /// Confirm Password
    /// </summary>
    public string ConfirmPassword { get; set; } = string.Empty;
}
