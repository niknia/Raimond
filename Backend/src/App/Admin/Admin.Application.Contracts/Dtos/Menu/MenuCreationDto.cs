namespace Dkd.App.Admin.Application.Contracts.Dtos;

/// <summary>
/// Menu
/// </summary>
public class MenuCreationDto : InputDto
{
    /// <summary>
    /// Parent menu ID
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Permission code
    /// </summary>
    public string Perm { get; set; } = string.Empty;

    /// <summary>
    /// Route name
    /// </summary>
    public string RouteName { get; set; } = string.Empty;

    /// <summary>
    /// Route path
    /// </summary>
    public string RoutePath { get; set; } = string.Empty;

    /// <summary>
    /// Menu type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// Component configuration
    /// </summary>
    public string Component { get; set; } = string.Empty;

    /// <summary>
    /// Whether to display
    /// </summary>
    public bool Visible { get; set; }

    /// <summary>
    /// Redirect route path
    /// </summary>
    public string Redirect { get; set; } = string.Empty;

    /// <summary>
    /// Icon
    /// </summary>
    public string Icon { get; set; } = string.Empty;

    /// <summary>
    /// Whether to enable page cache
    /// </summary>
    public bool KeepAlive { get; set; }

    /// <summary>
    /// Whether to always show when there is only one child route
    /// </summary>
    public bool AlwaysShow { get; set; }

    /// <summary>
    /// Route parameters
    /// </summary>
    public List<KeyValuePair<string, string>> Params { get; set; } = [];

    /// <summary>
    /// Order number
    /// </summary>
    public int Ordinal { get; set; }
}
