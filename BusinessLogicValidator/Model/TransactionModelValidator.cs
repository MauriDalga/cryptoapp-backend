using FluentValidation;
using Model.Write;

namespace BusinessLogicValidator.Model;
public class TransactionModelValidator : BaseValidator<TransactionModel>
{
    public TransactionModelValidator()
    {
        RuleFor(transaction => transaction.Amount)
        .NotEmpty()
        .WithMessage("Property 'amount' can't be empty.");

        RuleFor(transaction => transaction.CoinId)
        .NotEmpty()
        .WithMessage("Property 'coin ID' can't be empty.");

        RuleFor(transaction => transaction.SenderId)
        .NotEmpty()
        .WithMessage("Property 'sender ID' can't be empty.");

        RuleFor(transaction => transaction.ReceiverWalletAddress)
        .NotEmpty()
        .WithMessage("Property 'receiver wallet address' can't be empty.");
    }
}