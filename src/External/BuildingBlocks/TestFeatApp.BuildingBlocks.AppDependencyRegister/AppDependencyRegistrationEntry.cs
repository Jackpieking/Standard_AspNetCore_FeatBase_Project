using Microsoft.Extensions.DependencyInjection;
using TestFeatApp.BuildingBlocks.AppDependencyRegister.Features;
using TestFeatApp.Infra.F1;

namespace TestFeatApp.BuildingBlocks.AppDependencyRegister;

public static class AppDependencyRegistrationEntry
{
    public static void AddAppDependency(this IServiceCollection services)
    {
        FeatureHandlerDefinitionPreRegistration.Execute();
        F1Register.Execute(services);
    }
}
