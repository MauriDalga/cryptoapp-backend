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
    private readonly UserLogic _userLogic;
    private readonly IBusinessValidator<TransactionModel> _transactionModelValidator;

    public TransactionLogicAdapter(
        TransactionLogic transactionLogic,
        UserLogic userLogic,
        IBusinessValidator<TransactionModel> transactionModelValidator,
        IMapper mapper) : base(mapper)
    {
        _transactionLogic = transactionLogic;
        _userLogic = userLogic;
        _transactionModelValidator = transactionModelValidator;
    }

    public void Create(TransactionModel transaction)
    {
        _transactionModelValidator.CreationValidation(transaction);

        try
        {
            User receiver = _userLogic.GetUserFromWalletAddress(transaction.ReceiverWalletAddress);
            Transaction transactionEntity = new()
            {
                Amount = transaction.Amount,
                CoinId = transaction.CoinId,
                SenderId = transaction.SenderId,
                ReceiverId = receiver.Id
            };

            _transactionLogic.Add(transactionEntity);
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

