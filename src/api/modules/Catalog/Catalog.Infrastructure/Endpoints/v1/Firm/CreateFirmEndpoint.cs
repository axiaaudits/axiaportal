using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Firms.Create.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class CreateFirmEndpoint
{
    internal static RouteHandlerBuilder MapFirmCreationEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/", async (CreateFirmCommand request, ISender mediator) =>
            {
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(CreateFirmEndpoint))
            .WithSummary("creates a Firm")
            .WithDescription("creates a Firm")
            .Produces<CreateFirmResponse>()
            .RequirePermission("Permissions.Firms.Create")
            .MapToApiVersion(1);
    }
}
