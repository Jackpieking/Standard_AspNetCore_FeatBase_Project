using FastEndpoints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TestFeatApp.RestfulApi;

internal static class WebApiServiceRegistration
{
    internal static void AddWebApi(this IServiceCollection services)
    {
        // Clear default log.
        services.AddLogging(config =>
        {
            config.ClearProviders();
            config.AddConsole();
        });

        // WebApi endpoint handler by fastendpoints.
        services.AddFastEndpoints();
    }
}
