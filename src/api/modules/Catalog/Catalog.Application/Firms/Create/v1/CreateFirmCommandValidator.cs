using FluentValidation;
using FSH.Starter.WebApi.Catalog.Application.Firms.Create.v1;

namespace FSH.Starter.WebApi.Catalog.Application.Brands.Create.v1;
public class CreateFirmCommandValidator : AbstractValidator<CreateFirmCommand>
{
    public CreateFirmCommandValidator()
    {
        RuleFor(f => f.FirmName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(f => f.PostalAddress)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(f => f.Suburb)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(f => f.State)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(f => f.PostalCode)
            .NotEmpty()
            .Matches(@"^\d{4,6}$") // Adjust regex based on postal code format
            .WithMessage("Postal code must be between 4 and 6 digits.");

        RuleFor(f => f.Fascimile)
            .MaximumLength(20);

        RuleFor(f => f.Phone)
            .NotEmpty()
            .Matches(@"^\+?\d{7,15}$") // Adjust regex based on phone number format
            .WithMessage("Phone number must be valid.");

        RuleFor(f => f.FirmCode)
            .NotEmpty()
            .MaximumLength(50);
    }
}

