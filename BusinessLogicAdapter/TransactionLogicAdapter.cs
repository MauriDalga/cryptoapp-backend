using AutoMapper;
using BusinessLogic;
using BusinessLogicValidatorInterface;
using Domain;
using Model.Read;
using Model.Write;

namespace BusinessLogicAdapter;

public class TransactionLogicAdapter : BaseLogicAdapter
{
    private readonly TransactionLogic _transactionLogic;
    private readonly IBusinessValidator<TransactionModel> _transactionModelValidator;

    public TransactionLogicAdapter(
        TransactionLogic transactionLogic,
        IBusinessValidator<TransactionModel> transactionModelValidator,
        IMapper mapper) : base(mapper)
    {
        _transactionLogic = transactionLogic;
        _transactionModelValidator = transactionModelValidator;
    }

    public async Task Create(TransactionModel transaction)
    {
        _transactionModelValidator.CreationValidation(transaction);

        try
        {
            Transaction transactionEntity = new()
            {
                Amount = transaction.Amount,
                CoinId = transaction.CoinId,
                SenderId = transaction.SenderId,
                ReceiverId = 0,
                WalletAddress = transaction.ReceiverWalletAddress
            };

            await _transactionLogic.Add(transactionEntity);
        }
        catch(ArgumentException err)
        {
            throw new ArgumentException(err.Message);
        }
    }

    public IEnumerable<TransactionBasicModel> GetCollection(IDictionary<string, string> queryParams)
    {
        var transactions = _transactionLogic.GetCollection(queryParams);

        return _mapper.Map<IEnumerable<TransactionBasicModel>>(transactions);
    }
}

