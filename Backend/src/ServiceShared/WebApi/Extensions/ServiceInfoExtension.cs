using Dkd.Infra.Consul.Configuration;

namespace Dkd.Shared.WebApi;

public static class ServiceInfoExtension
{
    /*
    private static readonly object lockObj = new();
    private static readonly Assembly? appAssembly;
    */

    /// <summary>
    /// Get navigation homepage content
    /// </summary>
    /// <param name="serviceInfo"></param>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public static string GetDefaultPageContent(this IServiceInfo serviceInfo, IServiceProvider serviceProvider)
    {
        var swaggerUrl = $"/{serviceInfo.RelativeRootPath}/index.html";
        var consulOptions = serviceProvider.GetRequiredService<IOptions<ConsulOptions>>();
        var healthCheckUrl = consulOptions?.Value?.HealthCheckUrl ?? $"/{serviceInfo.RelativeRootPath}/health-24b01005-a76a-4b3b-8fb1-5e0f2e9564fb";
        var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var content = $"<div align='center'><a href='https://github.com/alphayu/adnc' target='_blank'><img src='https://aspdotnetcore.net/wp-content/uploads/2023/04/adnc-topics.png'/></a><br>" +
            $"ASPNETCORE_ENVIRONMENT = {envName} <br> " +
            $"Version = {serviceInfo.Version} <br> " +
            $"ServiceName = {serviceInfo.ServiceName} <br> " +
            $"ShortName = {serviceInfo.ShortName} <br> " +
            $"RelativeRootPath = {serviceInfo.RelativeRootPath} <br> " +
            $"<br><a href='{swaggerUrl}'>swagger UI</a> | <a href='{healthCheckUrl}'>healthy checking</a><br>" +
            $"<br>{DateTime.Now}</div>";
        return content;
    }

    /*
    /// <summary>
    /// Get WebApiAssembly assembly
    /// </summary>
    /// <returns></returns>
    //public static Assembly GetWebApiAssembly(this IServiceInfo serviceInfo) => serviceInfo.StartAssembly;

    /// <summary>
    /// Get Application assembly
    /// </summary>
    /// <returns></returns>
    //[Obsolete(".NET8 version is obsolete, .NET8 version AppDomain.CurrentDomain.GetAssemblies() can only get directly referenced assemblies and the result set is different from .NET6")]
    //public static Assembly GetApplicationAssembly(this IServiceInfo serviceInfo)
    */
}
