namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// User search criteria
/// </summary>
public class UserSearchPagedDto : SearchPagedDto
{
    /// <summary>
    /// User status
    /// </summary>
    public bool? Status { get; set; }

    /// <summary>
    /// Department ID
    /// </summary>
    public long? DeptId { get; set; }
}
