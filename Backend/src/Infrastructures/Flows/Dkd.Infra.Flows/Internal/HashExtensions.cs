namespace Dkd.Infra.Flows.Internal;

public static class HashExtensions
{
    public static int GetDeterministicHashCode(this string source)
    {
        var hash = 0x811C9DC5;
        foreach (var c in source)
        {
            hash ^= c;
            hash *= 0x01000193;
        }

        return unchecked((int)hash);
    }
}
