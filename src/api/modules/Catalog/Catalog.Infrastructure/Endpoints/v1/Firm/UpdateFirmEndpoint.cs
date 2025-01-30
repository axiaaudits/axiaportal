using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Firms.Update.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class UpdateFirmEndpoint
{
    internal static RouteHandlerBuilder MapFirmUpdateEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPut("/{id:guid}", async (Guid id, UpdateFirmCommand request, ISender mediator) =>
            {
                if (id != request.Id) return Results.BadRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithName(nameof(UpdateFirmEndpoint))
            .WithSummary("update a Firm")
            .WithDescription("update a Firm")
            .Produces<UpdateFirmResponse>()
            .RequirePermission("Permissions.Firms.Update")
            .MapToApiVersion(1);
    }
}
