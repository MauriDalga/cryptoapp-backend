using Domain;

namespace Model.Read;
public class TransactionBasicModel
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string WalletAddress { get; set; }
    public DateTime Date { get; set; }
    public CoinBasicModel Coin { get; set; }

    public TransactionBasicModel(Transaction transaction)
    {
        Id = transaction.Id;
        Amount = transaction.Amount;
        SenderId = transaction.SenderId;
        ReceiverId = transaction.ReceiverId;
        WalletAddress = transaction.WalletAddress;
        Date = transaction.Date;
        Coin = transaction.Coin != null
            ? new CoinBasicModel(transaction.Coin)
            : new CoinBasicModel(new Coin());
    }

    public override bool Equals(object? obj)
    {
        var result = false;

        if (obj is TransactionBasicModel transaction)
        {
            result = Id == transaction.Id;
        }

        return result;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}