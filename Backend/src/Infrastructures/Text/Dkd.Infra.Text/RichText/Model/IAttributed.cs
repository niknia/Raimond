namespace Dkd.Infra.Text.RichText.Model;

public interface IAttributed
{
    int GetIntAttr(string name, int defaultValue = 0);

    string GetStringAttr(string name, string defaultValue = "");
}
