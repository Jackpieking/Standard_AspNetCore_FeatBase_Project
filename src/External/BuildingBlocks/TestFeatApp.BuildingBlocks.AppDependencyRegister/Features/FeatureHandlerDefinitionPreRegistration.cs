using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestFeatApp.App.FAppCommon.Features;

namespace TestFeatApp.BuildingBlocks.AppDependencyRegister.Features;

internal static class FeatureHandlerDefinitionPreRegistration
{
    const string FeatAssemblyPrefixName = "TestFeatApp.App.F";
    const int StartFeatOrder = 1;
    const int EndFeatOrder = 7;

    // Entry point.
    internal static void Execute()
    {
        for (int featOrder = StartFeatOrder; featOrder <= EndFeatOrder; featOrder++)
        {
            var featHandlerDefinitions = LoadFeatureHandlerDefinitions(featOrder);

            RegisterFeatureHandlers(featHandlerDefinitions);
        }
    }

    private static IEnumerable<(
        Type HandlerType,
        Type HandlerInterfaceType
    )> LoadFeatureHandlerDefinitions(int featOrder)
    {
        return Assembly
            .Load($"{FeatAssemblyPrefixName}{featOrder}")
            .GetTypes()
            .Select(GetFeatureHandlerDefinition);

        static (Type HandlerType, Type HandlerInterfaceType) GetFeatureHandlerDefinition(Type type)
        {
            // Find interface is the IFeatureHandler<,> interface.
            var selectedTInterface = Array.Find(
                type.GetInterfaces(),
                tInterface =>
                    tInterface.IsGenericType
                    && tInterface.GetGenericTypeDefinition().Equals(typeof(IFeatureHandler<,>))
            );

            // construct new an object containing the handler type and the interface type.
            return !Equals(selectedTInterface, default) ? (type, selectedTInterface) : default;
        }
    }

    private static void RegisterFeatureHandlers(
        IEnumerable<(Type HandlerType, Type HandlerInterfaceType)> handlerDefinitions
    )
    {
        /*
        * Add the feature handler definition to the container.
        *
        * <==> Key: the request type.
        * <==> Value: new feature handler definition.
        */
        foreach (var (handlerType, handlerInterfaceType) in handlerDefinitions)
        {
            if (!Equals(handlerType, default))
            {
                var requestType = handlerInterfaceType.GetGenericArguments()[0];

                FeatureExtensions.FeatureHandlerRegistry.TryAdd(requestType, new(handlerType));
            }
        }
    }
}
