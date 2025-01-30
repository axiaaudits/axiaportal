using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Update.v1;
public sealed record UpdateFirmCommand(
    Guid Id,
    string? FirmName,
    string? PostalAddress = null,
    string? Suburb = null,
    string? State = null,
    string? PostalCode = null,
    string? Fascimile = null,
    string? Phone = null,
    string? FirmCode = null
) : IRequest<UpdateFirmResponse>;
