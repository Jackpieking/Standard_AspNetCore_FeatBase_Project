using System;

namespace TestFeatApp.BuildingBlocks.AppDependencyRegister.Features;

internal sealed class FeatureHandlerDefinition
{
    internal Type HandlerType { get; set; }

    internal FeatureHandlerDefinition(Type handlerType)
    {
        HandlerType = handlerType;
    }
}
