namespace Dkd.Infra.Core.Configuration;
public interface IValidatableOptions
{
    IEnumerable<ConfigurationError> Validate();
}
