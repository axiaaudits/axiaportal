using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Delete.v1;
public sealed record DeleteFirmCommand(
    Guid Id) : IRequest;
