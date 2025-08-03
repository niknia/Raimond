namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Notice
/// </summary>
public class NoticeSearchPagedDto : SearchPagedDto
{
    public string? Title { get; set; }

    public int? PublishStatus { get; set; }

    public int? IsRead { get; set; }
}
