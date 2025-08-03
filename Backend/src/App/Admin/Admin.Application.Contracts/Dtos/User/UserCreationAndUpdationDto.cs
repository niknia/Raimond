namespace Dkd.App.Admin.Application.Contracts.Dtos;

public abstract class UserCreationAndUpdationDto : InputDto
{
    ///// <summary>
    ///// Avatar
    ///// </summary>
    ////public string Avatar { get; set; }

    /// <summary>
    /// Birthday
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// Department ID
    /// </summary>
    public long DeptId { get; set; }

    /// <summary>
    /// Email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Mobile number
    /// </summary>
    public string Mobile { get; set; } = string.Empty;

    // <summary>
    // Role IDs
    // </summary>
    public long[] RoleIds { get; set; } = [];

    /// <summary>
    /// Gender
    /// </summary>
    public int Gender { get; set; }

    /// <summary>
    /// Account status
    /// </summary>
    public bool Status { get; set; }
}
