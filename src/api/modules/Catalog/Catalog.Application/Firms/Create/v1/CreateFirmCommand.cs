using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Application.Brands.Create.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Create.v1;
public sealed record CreateFirmCommand(
    [property: DefaultValue("Sample Firm")] string FirmName,
    [property: DefaultValue("123 Main St")] string PostalAddress,
    [property: DefaultValue("Sample Suburb")] string Suburb,
    [property: DefaultValue("Sample State")] string State,
    [property: DefaultValue("12345")] string PostalCode,
    [property: DefaultValue("123-456-7890")] string Fascimile,
    [property: DefaultValue("987-654-3210")] string Phone,
    [property: DefaultValue("FIRM123")] string FirmCode
) : IRequest<CreateFirmResponse>;

