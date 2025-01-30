using FSH.Framework.Core.Paging;
using FSH.Framework.Infrastructure.Auth.Policy;
using FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;
using FSH.Starter.WebApi.Catalog.Application.Firms.Search.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace FSH.Starter.WebApi.Catalog.Infrastructure.Endpoints.v1;

public static class SearchFirmsEndpoint
{
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
}
