using FluentValidation;

namespace Librarian.Application.Features.Member.Commands._Shared;

public class BaseMemberRequestValidator : AbstractValidator<BaseMemberRequest>
{
    public BaseMemberRequestValidator()
    {
        
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^[1-9]{2}[0-9]{9}$").WithMessage("Invalid phone number format.");

        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal code is required.")
            .Matches(@"^\d{5}(-\d{3})?$").WithMessage("Invalid postal code format.");
    }
}
