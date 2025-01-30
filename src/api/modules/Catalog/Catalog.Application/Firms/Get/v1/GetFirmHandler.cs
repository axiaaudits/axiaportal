using Microsoft.Extensions.DependencyInjection;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using FSH.Framework.Core.Persistence;
using FSH.Framework.Core.Caching;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;
public sealed class GetFirmHandler(
    [FromKeyedServices("catalog:firms")] IReadRepository<Firm> repository,
    ICacheService cache)
    : IRequestHandler<GetFirmRequest, FirmResponse>
{
    public async Task<FirmResponse> Handle(GetFirmRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var item = await cache.GetOrSetAsync(
            $"firm:{request.Id}",
            async () =>
            {
                var firmItem = await repository.GetByIdAsync(request.Id, cancellationToken);
                if (firmItem == null) throw new FirmNotFoundException(request.Id);

                return new FirmResponse(
                    firmItem.Id,
                    firmItem.FirmName,
                    firmItem.PostalAddress,
                    firmItem.Suburb,
                    firmItem.State,
                    firmItem.PostalCode,
                    firmItem.Fascimile,
                    firmItem.Phone,
                    firmItem.FirmCode);
            },
            cancellationToken: cancellationToken);

        return item!;
    }
}

