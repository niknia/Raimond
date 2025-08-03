
namespace Dkd.Infra.Core;
public interface ISystem
{
    string Name => GetType().Name;

    int Order => 0;
}
