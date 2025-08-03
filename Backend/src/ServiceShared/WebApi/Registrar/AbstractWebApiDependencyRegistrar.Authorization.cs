using Dkd.Shared.WebApi.Authorization;
using Dkd.Shared.WebApi.Authorization.Handlers;

namespace Dkd.Shared.WebApi.Registrar;

public abstract partial class AbstractWebApiDependencyRegistrar
{
    /// <summary>
    /// Register authorization component
    /// PermissionHandlerRemote Cross-service authorization
    /// PermissionHandlerLocal Local authorization, adnc.usr uses local authorization, other services use Rpc authorization
    /// </summary>
    /// <typeparam name="TAuthorizationHandler"></typeparam>
    protected virtual void AddAuthorization<TAuthorizationHandler>() where TAuthorizationHandler : AbstractPermissionHandler
    {
        var policyName = AuthorizePolicy.Default;
        Services
            .AddScoped<IAuthorizationHandler, TAuthorizationHandler>()
            .AddAuthorization(options =>
            {
                options.AddPolicy(policyName, policy =>
                {
                    policy.Requirements.Add(new PermissionRequirement());
                });
            });
    }
}
