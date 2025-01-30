using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Search.v1;

public class SearchFirmsCommand : PaginationFilter, IRequest<PagedList<FirmResponse>>
{
    public string? FirmName { get; set; }
    public string? PostalAddress { get; set; }
    public string? Suburb { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Fascimile { get; set; }
    public string? Phone { get; set; }
    public string? FirmCode { get; set; }
}
