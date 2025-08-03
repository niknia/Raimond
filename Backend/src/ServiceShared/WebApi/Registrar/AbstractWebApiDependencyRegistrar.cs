using Dkd.Shared.WebApi.Authentication.Processors;
using Dkd.Shared.WebApi.Authorization.Handlers;

namespace Dkd.Shared.WebApi.Registrar;

/// <summary>
/// WebApi dependency registrar
/// </summary>
public abstract partial class AbstractWebApiDependencyRegistrar
{
    public AbstractWebApiDependencyRegistrar(IServiceCollection services, IServiceInfo serviceInfo, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services, $"{nameof(IServiceCollection)} is null.");
        ArgumentNullException.ThrowIfNull(serviceInfo, $"{nameof(IServiceInfo)} is null.");
        ArgumentNullException.ThrowIfNull(configuration, $"{nameof(IConfiguration)} is null.");

        Services = services;
        ServiceInfo = serviceInfo;
        Configuration = configuration;
    }

    public string Name => "webapi";
    protected IConfiguration Configuration { get; init; }
    protected IServiceCollection Services { get; init; }
    protected IServiceInfo ServiceInfo { get; init; }

    public abstract void AddAdncServices();

    /// <summary>
    /// Register WebApi common services
    /// </summary>
    public void AddWebApiDefaultServices()
        => AddWebApiDefaultServices<BearerAuthenticationCacheProcessor, PermissionCacheHandler>();

    /// <summary>
    /// Register WebApi common services
    /// </summary>
    /// <typeparam name="TAuthenticationProcessor"><see cref="AbstractAuthenticationProcessor"/></typeparam>
    /// <typeparam name="TAuthorizationHandler"><see cref="AbstractPermissionHandler"/></typeparam>
    public void AddWebApiDefaultServices<TAuthenticationProcessor, TAuthorizationHandler>()
        where TAuthenticationProcessor : AbstractAuthenticationProcessor
        where TAuthorizationHandler : AbstractPermissionHandler
    {
        Services
            .Configure<ThreadPoolSettings>(Configuration.GetSection(NodeConsts.ThreadPoolSettings))
            .AddHttpContextAccessor()
            .AddMemoryCache();

        AddControllers();
        AddAuthentication<TAuthenticationProcessor>();
        AddAuthorization<TAuthorizationHandler>();
        AddCors();

        var enableSwaggerUI = Configuration.GetValue(NodeConsts.SwaggerUI_Enable, true);
        if (enableSwaggerUI)
        {
            AddSwaggerGen();
            AddMiniProfiler();
        }
    }
}
