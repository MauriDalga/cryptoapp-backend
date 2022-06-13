using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic;

public class UserLogic : BaseLogic
{
    private static decimal RandomDecimal(float min, float max)
    {
        Random random = new();
        double val = (random.NextDouble() * (max - min) + min);
        return (decimal)val;
    }

    private readonly IRepository<Coin> _coinRepository;
    private readonly IRepository<CoinAccount> _coinAccountRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IBusinessValidator<User> _userValidator;

    public UserLogic(
        IBusinessValidator<User> userValidator,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _coinRepository = unitOfWork.GetRepository<Coin>();
        _coinAccountRepository = unitOfWork.GetRepository<CoinAccount>();
        _userRepository = unitOfWork.GetRepository<User>();
        _userValidator = userValidator;
    }

    public User Add(User user)
    {
        _userValidator.CreationValidation(user);

        _userRepository.InsertAndSave(user);

        // Mocking UserAccounts for testing purpose.
        CreateInitialAccount(user.Id, 1);
        CreateInitialAccount(user.Id, 2);
        CreateInitialAccount(user.Id, 3);
        CreateInitialAccount(user.Id, 4);
        CreateInitialAccount(user.Id, 5);
        CreateInitialAccount(user.Id, 6);
        CreateInitialAccount(user.Id, 7);
        CreateInitialAccount(user.Id, 8);
        CreateInitialAccount(user.Id, 9);
        CreateInitialAccount(user.Id, 10);

        user.CoinAccounts.ForEach(ca =>
            ca.Coin = _coinRepository.Get(coin => coin.Id == ca.CoinId));

        return user;
    }

    private void CreateInitialAccount(int userId, int coinId)
    {
        _coinAccountRepository.InsertAndSave(
            new CoinAccount()
            {
                UserId = userId,
                CoinId = coinId,
                Balance = RandomDecimal(0, 10)
            });
    }

    public void Delete(int id)
    {
        _userValidator.ValidateIdentifier(id);
        _userRepository.DeleteByIdAndSave(id);
    }

    public void Edit(int id, User user)
    {
        _userValidator.ValidateIdentifier(id);
        _userValidator.EditionValidation(id, user);

        User savedUser = Get(id);
        user.Password = savedUser.Password;
        user.Token = savedUser.Token;

        _userRepository.UpdateAndSave(user);
    }

    public User Get(int id)
    {
        _userValidator.ValidateIdentifier(id);

        User user = _userRepository.Get(
            condition: users => users.Id == id,
            include: users => users.Include(user => user.CoinAccounts));

        user.CoinAccounts.ForEach(ca =>
            ca.Coin = _coinRepository.Get(coin => coin.Id == ca.CoinId));

        return user;
    }

    public bool IsValidToken(string token, string? id, string? queryUserId)
    {
        if (string.IsNullOrEmpty(queryUserId) && string.IsNullOrEmpty(id))
        {
            return _userRepository.Exist(users => users.Token == token);
        }

        int userId = !string.IsNullOrEmpty(queryUserId)
            ? int.Parse(queryUserId)
            : int.Parse(id);

        return _userRepository.Exist(users => users.Id == userId && users.Token == token);
    }

    public User GetUserFromLogIn(string email, string password)
    {
        _userValidator.ValidateEmailPassword(email, password);

        return _userRepository.Get(
            users => users.Email == email && users.Password == password
            );
    }

    public User GetUserFromWalletAddress(string walletAddress)
    {
        _userValidator.ValidateWalletAddress(walletAddress);

        return _userRepository.Get(users => users.WalletAddress == walletAddress);
    }
}