using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessInterface;
using Domain;
using FluentValidation;

namespace BusinessLogicValidator.Entities;
public class UserValidator : BaseValidator<User>
{
    private readonly IRepository<User> _userRepository;

    public UserValidator(IUnitOfWork unitOfWork)
    {
        _userRepository = unitOfWork.GetRepository<User>();

        RuleFor(user => user.Name)
        .NotNull()
        .WithMessage("Property 'name' can't be null")
        .NotEmpty()
        .WithMessage("Property 'name' can't be empty.");

        RuleFor(user => user.Lastname)
        .NotNull()
        .WithMessage("Property 'lastname' can't be null")
        .NotEmpty()
        .WithMessage("Property 'lastname' can't be empty.");

        RuleFor(user => user.Email)
        .NotNull()
        .WithMessage("Property 'email' can't be null")
        .NotEmpty()
        .WithMessage("Property 'email' can't be empty.");
    }


    protected override void BusinessValidation(User user)
    {
        bool existUserWithThatEmail = _userRepository.Exist(userSaved => userSaved.Email == user.Email);

        if (existUserWithThatEmail)
        {
            throw new ArgumentException($"Email: {user.Email} is in use");
        }
    }

    protected override void BusinessEditionValidation(int id, User user)
    {
        var existingUser = _userRepository.Get(user => user.Id == id);

        if (existingUser.Email != user.Email)
        {
            throw new Exception("Email must remain the same");
        }
    }

    protected override void BusinesIdentifierValidation(int id)
    {
        bool existUserWithThatId = _userRepository.Exist(userSaved => userSaved.Id == id);

        if (!existUserWithThatId)
        {
            throw new ArgumentException($"ID: {id} not found");
        }
    }
}