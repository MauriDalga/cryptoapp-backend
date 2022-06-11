using BusinessLogicValidatorInterface;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic;

public class TransactionLogic : BaseLogic
{
    private readonly IRepository<CoinAccount> _coinAccountRepository;
    private readonly IRepository<Transaction> _transactionRepository;
    private readonly IBusinessValidator<Transaction> _transactionValidator;

    public TransactionLogic(
        IBusinessValidator<Transaction> transactionValidator,
        IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _coinAccountRepository = unitOfWork.GetRepository<CoinAccount>();
        _transactionRepository = unitOfWork.GetRepository<Transaction>();
        _transactionValidator = transactionValidator;
    }

    public void Add(Transaction transaction)
    {
        _transactionValidator.CreationValidation(transaction);
        _transactionRepository.InsertAndSave(transaction);
        HandleTransactionAmount(transaction);
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