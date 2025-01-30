using FSH.Starter.Blazor.Client.Components.EntityTable;
using FSH.Starter.Blazor.Infrastructure.Api;
using FSH.Starter.Shared.Authorization;
using Mapster;
using Microsoft.AspNetCore.Components;

namespace FSH.Starter.Blazor.Client.Pages.Catalog;

public partial class Firms
{
    [Inject]
    protected IApiClient _client { get; set; } = default!;

    protected EntityServerTableContext<FirmResponse, Guid, FirmViewModel> Context { get; set; } = default!;

    private EntityTable<FirmResponse, Guid, FirmViewModel> _table = default!;

    protected override void OnInitialized() =>
        Context = new(
            entityName: "Firm",
            entityNamePlural: "Firms",
            entityResource: FshResources.Firms,
            fields: new()
            {
                new(firm => firm.FirmName, "Firm Name", "FirmName"),
                new(firm => firm.PostalAddress, "Postal Address", "PostalAddress"),
                new(firm => firm.Suburb, "Suburb", "Suburb"),
                new(firm => firm.State, "State", "State"),
                new(firm => firm.PostalCode, "Postal Code", "PostalCode"),
                new(firm => firm.Fascimile, "Fascimile", "Fascimile"),
                new(firm => firm.Phone, "Phone", "Phone"),
                new(firm => firm.FirmCode, "Firm Code", "FirmCode")
            },
            enableAdvancedSearch: true,
            idFunc: firm => firm.Id!.Value,
            searchFunc: async filter =>
            {
                var firmFilter = filter.Adapt<SearchFirmsCommand>();
                var result = await _client.SearchFirmsEndpointAsync("1", firmFilter);
                return result.Adapt<PaginationResponse<FirmResponse>>();
            },
            createFunc: async firm =>
            {
                await _client.CreateFirmEndpointAsync("1", firm.Adapt<CreateFirmCommand>());
            },
            updateFunc: async (id, firm) =>
            {
                await _client.UpdateFirmEndpointAsync("1", id, firm.Adapt<UpdateFirmCommand>());
            },
            deleteFunc: async id => await _client.DeleteFirmEndpointAsync("1", id));
}

public class FirmViewModel : UpdateFirmCommand
{
    // Add any additional logic or overrides for the FirmViewModel, if necessary.
}

