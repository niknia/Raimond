namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// User
/// </summary>
[Serializable]
public class UserDto : UserCreationAndUpdationDto
{
    /// <summary>
    /// User ID
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// User account
    /// </summary>
    public string Account { get; set; } = string.Empty;

    /// <summary>
    /// Department name
    /// </summary>
    public string DeptName { get; set; } = string.Empty;

    /// <summary>
    /// Creation time/Registration time
    /// </summary>
    public DateTime CreateTime { get; set; }
}
