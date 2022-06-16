using DataAccessInterface;
using Domain;
using FluentValidation;

namespace BusinessLogicValidator.Entities;
public class TransactionValidator : BaseValidator<Transaction>
{
    private readonly IRepository<Coin> _coinRepository;
    private readonly IRepository<CoinAccount> _coinAccountRepository;
    private readonly IRepository<User> _userRepository;

    public TransactionValidator(IUnitOfWork unitOfWork)
    {
        _coinRepository = unitOfWork.GetRepository<Coin>();
        _coinAccountRepository = unitOfWork.GetRepository<CoinAccount>();
        _userRepository = unitOfWork.GetRepository<User>();

        RuleFor(transaction => transaction.Amount)
        .NotNull()
        .WithMessage("Property 'amount' can't be null.")
        .GreaterThan(0)
        .WithMessage("Property 'amount' must be greater than 0.");

        RuleFor(transaction => transaction.CoinId)
        .NotNull()
        .WithMessage("Property 'coind ID' can't be null.")
        .GreaterThan(0)
        .WithMessage("Property 'coin ID' must be greater than 0.");

        RuleFor(transaction => transaction.SenderId)
        .NotNull()
        .WithMessage("Property 'sender ID' can't be null.")
        .GreaterThan(0)
        .WithMessage("Property 'sender ID' must be greater than 0.");

        RuleFor(transaction => transaction.ReceiverId)
        .NotNull()
        .WithMessage("Property 'receiver ID' can't be null.")
        .GreaterThan(0)
        .WithMessage("Property 'receiver ID' must be greater than 0.");
    }


    protected override void BusinessValidation(Transaction transaction)
    {
        bool existCoinId = _coinRepository.Exist(coinSaved => coinSaved.Id == transaction.CoinId);
        bool existSenderId = _userRepository.Exist(userSaved => userSaved.Id == transaction.SenderId);
        bool existReceiverId = _userRepository.Exist(userSaved => userSaved.Id == transaction.ReceiverId);

        if (!existCoinId || !existSenderId || !existReceiverId || transaction.SenderId == transaction.ReceiverId)
        {
            throw new ArgumentException("Transaction failed. Please try again.");
        }

        if (!CheckFunds(transaction))
        {
            throw new ArgumentException("Insufficient funds to complete this transaction.");
        }
    }

    public bool CheckFunds(Transaction transaction)
    {
        CoinAccount senderAccount = _coinAccountRepository
            .Get(account => account.UserId == transaction.SenderId && account.CoinId == transaction.CoinId);

        return senderAccount.Balance - transaction.Amount >= 0;
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