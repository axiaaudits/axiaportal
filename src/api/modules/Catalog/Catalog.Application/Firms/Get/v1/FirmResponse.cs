namespace FSH.Starter.WebApi.Catalog.Application.Firms.Get.v1;
public sealed record FirmResponse(
    Guid? Id,
    string FirmName,
    string PostalAddress,
    string Suburb,
    string State,
    string PostalCode,
    string Fascimile,
    string Phone,
    string FirmCode
);
