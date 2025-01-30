using FSH.Starter.WebApi.Catalog.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.EventHandlers;

public class FirmCreatedEventHandler(ILogger<FirmCreatedEventHandler> logger) : INotificationHandler<FirmCreated>
{
    public async Task Handle(FirmCreated notification,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("handling firm created domain event..");
        await Task.FromResult(notification);
        logger.LogInformation("finished handling firm created domain event..");
    }
}
