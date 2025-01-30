using Ardalis.Specification;
using FSH.Framework.Core.Paging;
using FSH.Framework.Core.Specifications;
using FSH.Starter.WebApi.Catalog.Application.Brands.Search.v1;
using FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;
using FSH.Starter.WebApi.Catalog.Domain;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Search.v1;
public class SearchFirmSpecs : EntitiesByPaginationFilterSpec<Firm, FirmResponse>
{
    public SearchFirmSpecs(SearchFirmsCommand command)
        : base(command)
    {
        Query
            .OrderBy(f => f.FirmName, !command.HasOrderBy())
            .Where(f => f.FirmName.Contains(command.FirmName), !string.IsNullOrEmpty(command.FirmName))
            .Where(f => f.PostalAddress.Contains(command.PostalAddress), !string.IsNullOrEmpty(command.PostalAddress))
            .Where(f => f.Suburb.Contains(command.Suburb), !string.IsNullOrEmpty(command.Suburb))
            .Where(f => f.State.Contains(command.State), !string.IsNullOrEmpty(command.State))
            .Where(f => f.PostalCode.Contains(command.PostalCode), !string.IsNullOrEmpty(command.PostalCode))
            .Where(f => f.Fascimile.Contains(command.Fascimile), !string.IsNullOrEmpty(command.Fascimile))
            .Where(f => f.Phone.Contains(command.Phone), !string.IsNullOrEmpty(command.Phone))
            .Where(f => f.FirmCode.Contains(command.FirmCode), !string.IsNullOrEmpty(command.FirmCode));
    }
}

