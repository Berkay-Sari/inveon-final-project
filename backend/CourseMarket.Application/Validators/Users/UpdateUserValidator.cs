using CourseMarket.Application.DTOs.User;
using FluentValidation;

namespace CourseMarket.Application.Validators.Users;

public class UpdateUserValidator : AbstractValidator<UpdateUserProfileRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email can't be empty.")
            .NotNull().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^(\+?[0-9]{10,15})$")
            .WithMessage("Phone number is not valid.")
            .When(x => !string.IsNullOrEmpty(x.PhoneNumber));

    }
}



