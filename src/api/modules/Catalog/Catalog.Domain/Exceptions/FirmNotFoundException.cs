using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class FirmNotFoundException : NotFoundException
{
    public FirmNotFoundException(Guid id)
        : base($"Firm with id {id} not found")
    {
    }
}
