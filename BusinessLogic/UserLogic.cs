using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic;

public class UserLogic : BaseLogic
{
    private const int InitialBalance = 10;

    private readonly IRepository<User> _userRepository;
    private readonly IRepository<CoinAccount> _coinAccountRepository;
    private readonly IBusinessValidator<User> _userValidator;

    public UserLogic(
        IBusinessValidator<User> userValidator,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _userRepository = unitOfWork.GetRepository<User>();
        _coinAccountRepository = unitOfWork.GetRepository<CoinAccount>();
        _userValidator = userValidator;
    }

    public User Add(User user)
    {
        _userValidator.CreationValidation(user);

        _userRepository.InsertAndSave(user);

        user.Token = user.Id + "_" + Guid.NewGuid().ToString();

        _userRepository.UpdateAndSave(user);

        // Mocking UserAccounts for testing purpose.
        CreateInitialAccount(user.Id, 1);
        CreateInitialAccount(user.Id, 2);
        CreateInitialAccount(user.Id, 3);

        return user;
    }

    private void CreateInitialAccount(int userId, int coinId)
    {
        _coinAccountRepository.InsertAndSave(new CoinAccount()
        {
            UserId = userId,
            CoinId = coinId,
            Balance = InitialBalance
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

        _userRepository.UpdateAndSave(user);
    }

    public User Get(int id)
    {
        _userValidator.ValidateIdentifier(id);

        return _userRepository.Get(users => users.Id == id);
    }

    public bool IsValidToken(string token, string? id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return _userRepository.Exist(users => users.Token == token);
        }

        return _userRepository.Exist(users => users.Id == int.Parse(id) && users.Token == token);
    }

    public IEnumerable<CoinAccount> GetAccountsFromUser(int id)
    {
        _userValidator.ValidateIdentifier(id);

        return _coinAccountRepository.GetCollection(condition: account => account.UserId == id,
            include: accounts => accounts.Include(account => account.Coin)!);
    }

    public User GetUserFromLogIn(string email, string password)
    {
        _userValidator.ValidateEmailPassword(email, password);

        return _userRepository.Get(
            users => users.Email == email && users.Password == password
            );
    }
}