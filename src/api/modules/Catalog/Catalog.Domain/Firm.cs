using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class Firm : AuditableEntity, IAggregateRoot
{
    public string FirmName { get; private set; } = default!;
    public string PostalAddress { get; private set; }
    public string Suburb { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Fascimile { get; private set; }
    public string Phone { get; private set; }
    public string FirmCode { get; private set; }

    public static Firm Create(
    string firmName, string postalAddress, string suburb, string state, string postalCode,
    string fascimile, string phone,string firmcode)
    {
        var firm = new Firm{
            FirmName = firmName,
            PostalAddress = postalAddress,
            Suburb = suburb,
            State = state,
            PostalCode=postalCode,
            Fascimile=fascimile,
            Phone=phone,
            FirmCode=firmcode
        };

        firm.QueueDomainEvent(new FirmCreated { Firm = firm });

        return firm;
    }

    public Firm Update(
    string? firmName, string? postalAddress, string? suburb, string? state,
    string? postalCode, string? fascimile, string? phone, string? firmCode)
    {
        if (firmName is not null && !FirmName.Equals(firmName, StringComparison.OrdinalIgnoreCase))
            FirmName = firmName;

        if (postalAddress is not null && !PostalAddress.Equals(postalAddress, StringComparison.OrdinalIgnoreCase))
            PostalAddress = postalAddress;

        if (suburb is not null && !Suburb.Equals(suburb, StringComparison.OrdinalIgnoreCase))
            Suburb = suburb;

        if (state is not null && !State.Equals(state, StringComparison.OrdinalIgnoreCase))
            State = state;

        if (postalCode is not null && !PostalCode.Equals(postalCode, StringComparison.OrdinalIgnoreCase))
            PostalCode = postalCode;

        if (fascimile is not null && !Fascimile.Equals(fascimile, StringComparison.OrdinalIgnoreCase))
            Fascimile = fascimile;

        if (phone is not null && !Phone.Equals(phone, StringComparison.OrdinalIgnoreCase))
            Phone = phone;

        if (firmCode is not null && !FirmCode.Equals(firmCode, StringComparison.OrdinalIgnoreCase))
            FirmCode = firmCode;

        this.QueueDomainEvent(new FirmUpdated { Firm = this });

        return this;
    }

    public static Firm Update(
    Guid id, string firmName, string postalAddress, string suburb, string state,
    string postalCode, string fascimile, string phone, string firmCode)
    {
        var firm = new Firm
        {
            Id = id,
            FirmName = firmName,
            PostalAddress = postalAddress,
            Suburb = suburb,
            State = state,
            PostalCode = postalCode,
            Fascimile = fascimile,
            Phone = phone,
            FirmCode = firmCode
        };

        firm.QueueDomainEvent(new FirmUpdated { Firm = firm });

        return firm;
    }
}
