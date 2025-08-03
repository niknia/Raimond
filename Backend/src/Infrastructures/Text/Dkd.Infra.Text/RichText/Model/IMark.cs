namespace Dkd.Infra.Text.RichText.Model;

public interface IMark : IAttributed
{
    MarkType Type { get; }
}
