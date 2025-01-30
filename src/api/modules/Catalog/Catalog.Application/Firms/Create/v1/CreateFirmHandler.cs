using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.Brands.Create.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Create.v1;
public sealed class CreateFirmHandler(
    ILogger<CreateFirmHandler> logger,
    [FromKeyedServices("catalog:firms")] IRepository<Firm> repository)
    : IRequestHandler<CreateFirmCommand, CreateFirmResponse>
{
    public async Task<CreateFirmResponse> Handle(CreateFirmCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var firm = Firm.Create(
            request.FirmName, request.PostalAddress, request.Suburb, request.State,
            request.PostalCode, request.Fascimile, request.Phone, request.FirmCode);

        await repository.AddAsync(firm, cancellationToken);

        logger.LogInformation("Firm created {FirmId}", firm.Id);

        return new CreateFirmResponse(firm.Id);
    }
}

