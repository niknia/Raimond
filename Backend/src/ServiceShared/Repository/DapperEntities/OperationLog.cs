namespace Dkd.Shared.Repository.DapperEntities;

/// <summary>
/// Operation logs
/// </summary>
public class OperationLog : Entity
{
    /// <summary>
    /// Controller class name
    /// </summary>
    public string ClassName { get; set; } = string.Empty;

    /// <summary>
    /// Log business name
    /// </summary>
    public string LogName { get; set; } = string.Empty;

    /// <summary>
    /// Log type
    /// </summary>
    public string LogType { get; set; } = string.Empty;

    /// <summary>
    /// Detailed information
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Controller method
    /// </summary>
    public string Method { get; set; } = string.Empty;

    /// <summary>
    /// Whether the operation was successful
    /// </summary>
    public bool Succeed { get; set; }

    /// <summary>
    /// Operating user ID
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Account
    /// </summary>
    public string Account { get; set; } = string.Empty;

    /// <summary>
    /// Operating username
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// IP address
    /// </summary>
    public string RemoteIpAddress { get; set; } = string.Empty;

    /// <summary>
    /// Execution time
    /// </summary>
    public int ExecutionTime { get; set; }

    /// <summary>
    /// Operation time
    /// </summary>
    public DateTime CreateTime { get; set; }
}
