using FluentValidation;
using Model.Write;

namespace BusinessLogicValidator.Model;
public class UserEditModelValidator : BaseValidator<UserEditModel>
{
    public UserEditModelValidator()
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
    }
}