using TestFeatApp.App.FAppCommon.Features;

namespace TestFeatApp.App.F1;

public sealed class F1Request : IFeatureRequest<F1Response>
{
    public string RequestMessage { get; init; } = string.Empty;
}
