namespace Dkd.Shared.Application.Contracts.ResultModels;

/// <summary>
/// Application result wrapper class, no return type (void, task)
/// </summary>
[Obsolete($"use {nameof(ServiceResult)} instead")]
[Serializable]
public sealed class AppSrvResult
{
    public AppSrvResult()
    {
    }

    public AppSrvResult(ProblemDetails problemDetails) => ProblemDetails = problemDetails;

    public bool IsSuccess => ProblemDetails == null;

    public ProblemDetails ProblemDetails { get; set; } = default!;

    public static implicit operator AppSrvResult(ProblemDetails problemDetails)
    {
        return new()
        {
            ProblemDetails = problemDetails
        };
    }
}

/// <summary>
/// Application result wrapper class, with return type
/// </summary>
[Obsolete($"use {nameof(ServiceResult)} instead")]
[Serializable]
public sealed class AppSrvResult<TValue>
{
    public AppSrvResult()
    {
    }

    public AppSrvResult(TValue value) => Content = value;

    public AppSrvResult(ProblemDetails problemDetails) => ProblemDetails = problemDetails;

    public bool IsSuccess => ProblemDetails == null && Content != null;
    public TValue Content { get; set; } = default!;

    public ProblemDetails ProblemDetails { get; set; } = default!;

    public static implicit operator AppSrvResult<TValue>(AppSrvResult result)
    {
        return new()
        {
            ProblemDetails = result.ProblemDetails
        };
    }

    public static implicit operator AppSrvResult<TValue>(ProblemDetails problemDetails)
    {
        return new()
        {
            ProblemDetails = problemDetails
        };
    }

    public static implicit operator AppSrvResult<TValue>(TValue value) => new(value);
}
