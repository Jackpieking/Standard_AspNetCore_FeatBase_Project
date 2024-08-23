using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Http;
using TestFeatApp.App.F1;
using TestFeatApp.BuildingBlocks.AppDependencyRegister.Features;

namespace TestFeatApp.RestfulApi.Endpoints;

public sealed class F1Endpoint : Endpoint<F1Request, F1Response>
{
    public override void Configure()
    {
        Get("/test");
        AllowAnonymous();
    }

    public override async Task<F1Response> ExecuteAsync(F1Request req, CancellationToken ct)
    {
        var response = await FeatureExtensions.ExecuteAsync<F1Request, F1Response>(req, ct);

        await SendAsync(response, StatusCodes.Status200OK, ct);

        return response;
    }
}
