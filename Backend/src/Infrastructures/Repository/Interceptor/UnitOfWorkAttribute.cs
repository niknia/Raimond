namespace Dkd.Infra.Repository.Interceptor;

[AttributeUsage(AttributeTargets.Method, Inherited = true)]
public class UnitOfWorkAttribute : Attribute
{
    /// <summary>
    /// Need to share the transaction with CAP
    /// </summary>
    public bool Distributed { get; set; }
}
