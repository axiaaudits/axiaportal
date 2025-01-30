using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class GetFirmEndpoint
{
    internal static RouteHandlerBuilder MapGetFirmEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapGet("/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var response = await mediator.Send(new GetFirmRequest(id));
                return Results.Ok(response);
            })
            .WithName(nameof(GetFirmEndpoint))
            .WithSummary("gets Firm by id")
            .WithDescription("gets Firm by id")
            .Produces<FirmResponse>()
            .RequirePermission("Permissions.Firms.View")
            .MapToApiVersion(1);
    }
}
