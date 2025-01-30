using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Application.Firms.Update.v1;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Update.v1;
public sealed class UpdateFirmHandler(
    ILogger<UpdateFirmHandler> logger,
    [FromKeyedServices("catalog:firms")] IRepository<Firm> repository)
    : IRequestHandler<UpdateFirmCommand, UpdateFirmResponse>
{
    public async Task<UpdateFirmResponse> Handle(UpdateFirmCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        // Get the firm by Id
        var firm = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = firm ?? throw new FirmNotFoundException(request.Id);

        // Update firm details
        var updatedFirm = firm.Update(
            request.FirmName,
            request.PostalAddress,
            request.Suburb,
            request.State,
            request.PostalCode,
            request.Fascimile,
            request.Phone,
            request.FirmCode);

        // Save the updated firm
        await repository.UpdateAsync(updatedFirm, cancellationToken);
        logger.LogInformation("Firm with id : {FirmId} updated.", firm.Id);

        return new UpdateFirmResponse(firm.Id);
    }
}

