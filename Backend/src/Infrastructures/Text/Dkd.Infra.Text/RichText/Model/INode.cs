namespace Dkd.Infra.Text.RichText.Model;

public interface INode : IAttributed
{
    NodeType Type { get; }

    string? Text { get; }

    IMark? GetNextMark();

    void IterateContent<T>(T state, Action<INode, T, bool, bool> action);

    public void Reset()
    {
    }
}
