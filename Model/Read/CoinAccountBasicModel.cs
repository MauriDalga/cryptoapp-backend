using Domain;

namespace Model.Read;

public class CoinAccountBasicModel
{
    public int Id { get; set; }
    public int CoinId { get; set; }
    public decimal Balance { get; set; }
    public int UserId { get; set; }

    public CoinAccountBasicModel(CoinAccount coinAccount)
    {
        Id = coinAccount.Id;
        CoinId = coinAccount.CoinId;
        Balance = coinAccount.Balance;
        UserId = coinAccount.UserId;
    }
}