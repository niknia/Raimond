using System.Diagnostics.CodeAnalysis;

namespace Dkd.Infra.Text;

internal sealed class ReadOnlyMemoryCharComparer(StringComparison comparison) : IEqualityComparer<ReadOnlyMemory<char>>
{
    public static readonly ReadOnlyMemoryCharComparer Ordinal = new(StringComparison.Ordinal);

    public static readonly ReadOnlyMemoryCharComparer OrdinalIgnoreCase = new(StringComparison.OrdinalIgnoreCase);

    public static readonly ReadOnlyMemoryCharComparer InvariantCulture = new(StringComparison.InvariantCulture);

    public static readonly ReadOnlyMemoryCharComparer InvariantCultureIgnoreCase
        = new(StringComparison.InvariantCultureIgnoreCase);

    public static readonly ReadOnlyMemoryCharComparer CurrentCulture = new(StringComparison.CurrentCulture);

    public static readonly ReadOnlyMemoryCharComparer CurrentCultureIgnoreCase
        = new(StringComparison.CurrentCultureIgnoreCase);

    public bool Equals(ReadOnlyMemory<char> x, ReadOnlyMemory<char> y)
    {
        return x.Span.Equals(y.Span, comparison);
    }

    public int GetHashCode([DisallowNull] ReadOnlyMemory<char> obj)
    {
        return string.GetHashCode(obj.Span, comparison);
    }
}
