namespace Dkd.Shared.Application.Contracts.ResultModels;

/// <summary>
/// Error information class
/// </summary>
[Serializable]
public sealed class ProblemDetails
{
    public ProblemDetails()
    { }

    public ProblemDetails(HttpStatusCode? statusCode, string? detail = null, string? title = null, string? instance = null, string? type = null)
    {
        var status = statusCode.HasValue ? (int)statusCode.Value : (int)HttpStatusCode.BadRequest;
        Status = status;
        Title = title ?? "Parameter Error";
        Detail = detail ?? string.Empty;
        Instance = instance ?? string.Empty;
        Type = type ?? string.Concat("https://httpstatuses.com/", status);
    }

    [JsonPropertyName("detail")]
    public string Detail { get; set; } = string.Empty;

    [JsonExtensionData]
    public IDictionary<string, object> Extensions { get; } = new Dictionary<string, object>();

    [JsonPropertyName("instance")]
    public string Instance { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    public override string ToString() => JsonSerializer.Serialize(this, SystemTextJson.GetAdncDefaultOptions());
}
