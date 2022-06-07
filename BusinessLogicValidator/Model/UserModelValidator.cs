using FluentValidation;
using Model.Write;

namespace BusinessLogicValidator.Model;
public class UserModelValidator : BaseValidator<UserModel>
{
    public UserModelValidator()
    {
        RuleFor(user => user.Name)
        .NotEmpty()
        .WithMessage("Property 'name' can't be empty.");

        RuleFor(user => user.Lastname)
        .NotEmpty()
        .WithMessage("Property 'lastname' can't be empty.");

        RuleFor(user => user.Email)
        .EmailAddress()
        .WithMessage("Property 'email' has incorrect format.");

        RuleFor(user => user.Password)
        .MinimumLength(7)
        .WithMessage("Property 'password' should have 7 characters or more.");
    }
}