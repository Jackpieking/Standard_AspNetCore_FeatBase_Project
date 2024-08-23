namespace TestFeatApp.App.FAppCommon.Features;

public interface IFeatureRequest<TResponse>
    where TResponse : IFeatureResponse { }
