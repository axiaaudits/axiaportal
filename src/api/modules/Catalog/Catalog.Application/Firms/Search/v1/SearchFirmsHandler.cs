using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.Brands.Search.v1;
using FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Search.v1;
public sealed class SearchFirmsHandler(
    [FromKeyedServices("catalog:firms")] IReadRepository<Firm> repository)
    : IRequestHandler<SearchFirmsCommand, PagedList<FirmResponse>>
{
    public async Task<PagedList<FirmResponse>> Handle(SearchFirmsCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var spec = new SearchFirmSpecs(request);

        var items = await repository.ListAsync(spec, cancellationToken).ConfigureAwait(false);
        var totalCount = await repository.CountAsync(spec, cancellationToken).ConfigureAwait(false);

        return new PagedList<FirmResponse>(items, request.PageNumber, request.PageSize, totalCount);
    }
}

