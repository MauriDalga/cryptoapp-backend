using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using ServicesInterface;

namespace BusinessLogic;

public class TransactionLogic : BaseLogic
{
    private readonly IRepository<CoinAccount> _coinAccountRepository;
    private readonly IRepository<Transaction> _transactionRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Coin> _coinRepository;
    private readonly IBusinessValidator<Transaction> _transactionValidator;
    private readonly INotificationService _notificationService;

    public TransactionLogic(
        IBusinessValidator<Transaction> transactionValidator,
        INotificationService notificationService,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _coinAccountRepository = unitOfWork.GetRepository<CoinAccount>();
        _transactionRepository = unitOfWork.GetRepository<Transaction>();
        _userRepository = unitOfWork.GetRepository<User>();
        _coinRepository = unitOfWork.GetRepository<Coin>();
        _transactionValidator = transactionValidator;
        _notificationService = notificationService;
    }

    public async Task Add(Transaction transaction)
    {
        try
        {
            _transactionValidator.ValidateWalletAddress(transaction.WalletAddress);
            User receiver = _userRepository.Get(user => user.WalletAddress == transaction.WalletAddress);
            Coin coin = _coinRepository.Get(coin => coin.Id == transaction.CoinId);

            transaction.ReceiverId = receiver.Id;

            _transactionValidator.CreationValidation(transaction);
            _transactionRepository.InsertAndSave(transaction);
            HandleTransactionAmount(transaction);

            string deviceToken = receiver.DeviceToken;
            string notificationBody = $"Has recibido {transaction.Amount}{coin.ShortName}";

            await _notificationService.SendNotification(deviceToken, notificationBody);
        }
        catch (ArgumentException err)
        {
            throw new ArgumentException(err.Message);
        }
    }

    public IEnumerable<Transaction> GetCollection(IDictionary<string, string> queryParams)
    {
        if (!string.IsNullOrEmpty(queryParams["userid"]))
        {
            int userId = int.Parse(queryParams["userid"]);

            if(_userRepository.Exist(user => user.Id == userId))
            {
                return _transactionRepository
                    .GetCollection(
                        condition: t => t.SenderId == userId || t.ReceiverId == userId,
                        orderBy: t => t.OrderByDescending(t => t.Date),
                        include: t => t.Include(t => t.Coin));
            }

            throw new KeyNotFoundException($"ID: {userId} not found.");
        }

        throw new ArgumentException("Missing user ID on query params.");
    }

    public void HandleTransactionAmount(Transaction transaction)
    {
        CoinAccount senderAccount = _coinAccountRepository
            .Get(account => account.UserId == transaction.SenderId && account.CoinId == transaction.CoinId);

        CoinAccount receiverAccount = _coinAccountRepository
            .Get(account => account.UserId == transaction.ReceiverId && account.CoinId == transaction.CoinId);

        senderAccount.Balance -= transaction.Amount;
        receiverAccount.Balance += transaction.Amount;

        _coinAccountRepository.UpdateAndSave(senderAccount);
        _coinAccountRepository.UpdateAndSave(receiverAccount);
    }
}