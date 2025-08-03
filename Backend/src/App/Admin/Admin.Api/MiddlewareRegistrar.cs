using Dkd.App.Admin.Api.Grpc;
using Dkd.Shared.WebApi.Registrar;

namespace Dkd.App.Admin.Api;

public sealed class MiddlewareRegistrar(WebApplication app) : AbstractWebApiMiddlewareRegistrar(app)
{
    public override void UseAdnc()
    {
        UseWebApiDefault(endpointRoute: endpoint =>
        {
            endpoint.MapGrpcService<AdminGrpcServer>();
        });
    }
}
