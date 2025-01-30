using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Delete.v1;
public sealed class DeleteFirmHandler(
    ILogger<DeleteFirmHandler> logger,
    [FromKeyedServices("catalog:firms")] IRepository<Firm> repository)
    : IRequestHandler<DeleteFirmCommand>
{
    public async Task Handle(DeleteFirmCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var firm = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = firm ?? throw new FirmNotFoundException(request.Id);
        await repository.DeleteAsync(firm, cancellationToken);
        logger.LogInformation("Firm with id : {FirmId} deleted", firm.Id);
    }
}
