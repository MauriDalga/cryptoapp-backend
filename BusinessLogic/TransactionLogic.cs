using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic;

public class TransactionLogic : BaseLogic
{
    private readonly IRepository<CoinAccount> _coinAccountRepository;
    private readonly IRepository<Transaction> _transactionRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IBusinessValidator<Transaction> _transactionValidator;

    public TransactionLogic(
        IBusinessValidator<Transaction> transactionValidator,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _coinAccountRepository = unitOfWork.GetRepository<CoinAccount>();
        _transactionRepository = unitOfWork.GetRepository<Transaction>();
        _userRepository = unitOfWork.GetRepository<User>();
        _transactionValidator = transactionValidator;
    }

    public void Add(Transaction transaction)
    {
        _transactionValidator.CreationValidation(transaction);
        _transactionRepository.InsertAndSave(transaction);
        HandleTransactionAmount(transaction);
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