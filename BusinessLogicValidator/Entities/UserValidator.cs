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
        .NotEmpty()
        .WithMessage("Property 'name' can't be empty.");

        RuleFor(user => user.Lastname)
        .NotEmpty()
        .WithMessage("Property 'lastname' can't be empty.");

        RuleFor(user => user.Email)
        .EmailAddress()
        .WithMessage("Property 'email' has incorrect format.");
    }


    protected override void BusinessValidation(User user)
    {
        bool existUserWithThatEmail = _userRepository.Exist(userSaved => userSaved.Email == user.Email);

        if (existUserWithThatEmail)
        {
            throw new ArgumentException($"Email: {user.Email} is already in use.");
        }
    }

    protected override void BusinessEditionValidation(int id, User user)
    {
        var existingUser = _userRepository.Get(user => user.Id == id);

        if (existingUser.Email != user.Email)
        {
            throw new Exception("Email must remain the same.");
        }
    }

    protected override void BusinesIdentifierValidation(int id)
    {
        bool existUserWithThatId = _userRepository.Exist(userSaved => userSaved.Id == id);

        if (!existUserWithThatId)
        {
            throw new KeyNotFoundException($"ID: {id} not found.");
        }
    }

    protected override void BusinessLogInValidation(string email, string password)
    {
        bool existUserWithThatEmailAndPassword = _userRepository
            .Exist(userSaved => userSaved.Email == email && userSaved.Password == password);

        if (!existUserWithThatEmailAndPassword)
        {
            throw new ArgumentException("Invalid credentials.");
        }
    }

    protected override void BusinessWalletAddressValidation(string walletAddress)
    {
        bool existUserWithWalletAddress = _userRepository
            .Exist(userSaved => userSaved.WalletAddress == walletAddress);

        if (!existUserWithWalletAddress)
        {
            throw new ArgumentException("Invalid Wallet Address.");
        }
    }
}