namespace Dkd.Infra.Flows;

public static class FlowConsole
{
    private static readonly AsyncLocal<Action<string, object?>?> CurrentOutput = new();

    public static Action<string, object?>? Output
    {
        get => CurrentOutput.Value;
        set => CurrentOutput.Value = value;
    }

    public static void Out(string message, object? dump = null)
    {
        Output?.Invoke(message, dump);
    }
}
