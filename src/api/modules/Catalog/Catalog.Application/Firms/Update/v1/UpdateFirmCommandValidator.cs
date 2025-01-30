using FluentValidation;
using FSH.Starter.WebApi.Catalog.Application.Firms.Update.v1;

namespace FSH.Starter.WebApi.Catalog.Application.Firms.Update.v1;
public class UpdateFirmCommandValidator : AbstractValidator<UpdateFirmCommand>
{
    public UpdateFirmCommandValidator()
    {
        RuleFor(f => f.FirmName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(f => f.PostalAddress)
            .MaximumLength(200);

        RuleFor(f => f.Suburb)
            .MaximumLength(100);

        RuleFor(f => f.State)
            .MaximumLength(100);

        RuleFor(f => f.PostalCode)
            .Matches(@"^\d{4,6}$")
            .WithMessage("Postal code must be between 4 and 6 digits.");

        RuleFor(f => f.Fascimile)
            .MaximumLength(20);

        RuleFor(f => f.Phone)
            .Matches(@"^\+?\d{7,15}$")
            .WithMessage("Phone number must be valid.");

        RuleFor(f => f.FirmCode)
            .MaximumLength(50);
    }
}

