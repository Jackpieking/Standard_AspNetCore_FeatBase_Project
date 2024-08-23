using Microsoft.Extensions.DependencyInjection;
using TestFeatApp.App.F1.Contract;
using TestFeatApp.Infra.F1.Implementations;

namespace TestFeatApp.Infra.F1;

public static class F1Register
{
    public static void Execute(this IServiceCollection services)
    {
        services.AddSingleton<ITest, TestImpl>();
    }
}
