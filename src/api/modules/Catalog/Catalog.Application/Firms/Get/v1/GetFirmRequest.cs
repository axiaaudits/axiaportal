using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;
public class GetFirmRequest : IRequest<FirmResponse>
{
    public Guid Id { get; set; }

    public GetFirmRequest(Guid id) => Id = id;
}
