using System.Threading;
using System.Threading.Tasks;
using TestFeatApp.App.F1.Contract;
using TestFeatApp.App.FAppCommon.Features;

namespace TestFeatApp.App.F1;

internal sealed class F1Handler : IFeatureHandler<F1Request, F1Response>
{
    public ITest Test { get; init; }

    public F1Handler(ITest test)
    {
        Test = test;
    }

    public Task<F1Response> ExecuteAsync(F1Request request, CancellationToken ct)
    {
        return Task.FromResult<F1Response>(new() { Message = Test.TryMe() });
    }
}
