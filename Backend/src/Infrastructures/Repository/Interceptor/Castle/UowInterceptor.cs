using Castle.DynamicProxy;

namespace Dkd.Infra.Repository.Interceptor.Castle;

/// <summary>
/// Unit of work interceptor
/// </summary>
public class UowInterceptor(UowAsyncInterceptor uowAsyncInterceptor) : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        uowAsyncInterceptor.ToInterceptor().Intercept(invocation);
    }
}
