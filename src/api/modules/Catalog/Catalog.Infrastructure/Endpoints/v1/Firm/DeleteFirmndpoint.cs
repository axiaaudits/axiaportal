using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Firms.Delete.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class DeleteFirmEndpoint
{
    internal static RouteHandlerBuilder MapFirmDeleteEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapDelete("/{id:guid}", async (Guid id, ISender mediator) =>
             {
                 await mediator.Send(new DeleteFirmCommand(id));
                 return Results.NoContent();
             })
            .WithName(nameof(DeleteFirmEndpoint))
            .WithSummary("deletes Firm by id")
            .WithDescription("deletes Firm by id")
            .Produces(StatusCodes.Status204NoContent)
            .RequirePermission("Permissions.Firms.Delete")
            .MapToApiVersion(1);
    }
}
