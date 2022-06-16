using FluentValidation;
using Model.Write;

namespace BusinessLogicValidator.Model;
public class SessionModelValidator : BaseValidator<SessionModel>
{
    public SessionModelValidator()
    {
        RuleFor(user => user.Email)
        .EmailAddress()
        .WithMessage("Property 'email' has incorrect format.");

        RuleFor(user => user.Password)
        .MinimumLength(7)
        .WithMessage("Property 'password' should have 7 characters or more.");

        RuleFor(user => user.DeviceToken)
        .NotEmpty()
        .WithMessage("Property 'device token' can't be empty.");
    }
}