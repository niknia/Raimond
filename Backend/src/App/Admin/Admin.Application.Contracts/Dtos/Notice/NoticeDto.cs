namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Notice
/// </summary>
[Serializable]
public class NoticeDto
{
    public long Id { get; set; }

    /// <summary>
    /// Notice title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Notice content
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// Notice type
    /// </summary>
    public int? Type { get; set; }

    /// <summary>
    /// Publisher
    /// </summary>
    public long? PublisherId { get; set; }

    /// <summary>
    /// Priority (0-Low 1-Medium 2-High)
    /// </summary>
    public int? Priority { get; set; }

    /// <summary>
    /// Target type (0-All 1-Specified)
    /// </summary>
    public int? TargetType { get; set; }

    /// <summary>
    /// Publish status (0-Unpublished 1-Published 2-Revoked)
    /// </summary>
    public int? PublishStatus { get; set; }

    /// <summary>
    /// Publish time
    /// </summary>
    public DateTime? PublishTime { get; set; }

    /// <summary>
    /// Revoke time
    /// </summary>
    public DateTime? RevokeTime { get; set; }
}
