using System.ComponentModel.DataAnnotations;

namespace Dkd.Shared.Application.Contracts.Dtos;

/// <summary>
/// Used to solve the problem of API receiving basic types like string, int, long through frompost method.
/// </summary>
/// <typeparam name="T"></typeparam>
[Serializable]
public class InputSimpleDto<T> : IDto
    where T : notnull
{
    /// <summary>
    /// Value to be passed
    /// </summary>
    [Required]
    public T Value { get; set; } = default!;
}
