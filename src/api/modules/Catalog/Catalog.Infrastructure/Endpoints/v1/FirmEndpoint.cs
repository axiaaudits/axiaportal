using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.Firms.Delete.v1;
using FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;
public static class FirmEndpoint
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
    internal static RouteHandlerBuilder MapGetFirmListEndpoint(this IEndpointRouteBuilder endpoints)
    {
        return endpoints
            .MapPost("/search", async (ISender mediator, [FromBody] SearchFirmsCommand command) =>
            {
                var response = await mediator.Send(command);
                return Results.Ok(response);
            })
            .WithName(nameof(SearchFirmsEndpoint))
            .WithSummary("Gets a list of Firms")
            .WithDescription("Gets a list of Firms with pagination and filtering support")
            .Produces<PagedList<FirmResponse>>()
            .RequirePermission("Permissions.Firms.View")
            .MapToApiVersion(1);
    }
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
